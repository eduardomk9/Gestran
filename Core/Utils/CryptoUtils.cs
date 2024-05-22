using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utils
{
    public static class CryptoUtils
    {
        private static IConfiguration? _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string Encrypt(string plainText)
        {
            //Initialize(_configuration);
            if (_configuration == null)
            {
                throw new InvalidOperationException("Configuration is not initialized. Call Initialize method first.");
            }

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(_configuration["Settings:CryptoKey"] ?? string.Empty);
            aesAlg.GenerateIV();

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msEncrypt = new();
            using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new(csEncrypt))
            {
                swEncrypt.Write(plainText);
            }
            byte[] iv = aesAlg.IV;
            byte[] encrypted = msEncrypt.ToArray();
            byte[] result = new byte[iv.Length + encrypted.Length];
            Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
            Buffer.BlockCopy(encrypted, 0, result, iv.Length, encrypted.Length);
            return Convert.ToBase64String(result);
        }

        public static string Decrypt(string cipherText)
        {
            if (_configuration == null)
            {
                throw new InvalidOperationException("Configuration is not initialized. Call Initialize method first.");
            }

            byte[] fullCipher = Convert.FromBase64String(cipherText);
            byte[] iv = fullCipher.Take(16).ToArray();
            byte[] cipher = fullCipher.Skip(16).ToArray();

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(_configuration["Settings:CryptoKey"] ?? string.Empty);
            aesAlg.IV = iv;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msDecrypt = new(cipher);
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);
            return srDecrypt.ReadToEnd();
        }
    }
}
