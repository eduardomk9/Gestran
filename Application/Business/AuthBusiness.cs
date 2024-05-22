using AutoMapper;
using Core.Business;
using Core.Dtos.Auth;
using Core.Dtos.User;
using Core.Entities.GenericEnterpise;
using Core.Repositories;
using Core.Services;
using Core.Utils;
using Microsoft.EntityFrameworkCore;

namespace Application.Business
{
    public class AuthBusiness(
        IAuthService authService,
        IGenericEnterpriseRepository<GeUser> repositoryGeUser,
        IMapper mapper
        ) : IAuthBusiness
    {
        private readonly IAuthService _authService = authService;
        private readonly IGenericEnterpriseRepository<GeUser> _repositoryGeUser = repositoryGeUser;
        private readonly IMapper _mapper = mapper;

        public async Task<SignInResponseDto> SignInAsync(SignInDto model)
        {
            try
            {
                GeUser user = await _repositoryGeUser.Get(x => x.MailUser == model.Mail,
                     includes: query => query
                    .Include(x => x.IdAuthNavigation)
                    .Include(x => x.GeMemberOfs.Where(w => w.IdProfNavigation.IsActiveProf))
                    .ThenInclude(x => x.IdProfNavigation)) ?? throw new Exception("AuthBusiness | SignInAsync | User not found!");
                bool valid = false;
                
                    if (user.PasswordUser != null && CryptoUtils.Decrypt(user.PasswordUser) == model.Password)
                    {
                        valid = true;
                    }
                

                if (valid)
                {
                    if (!user.IsActiveUser) throw new Exception("Inactive user");
                    TokenDto token = _authService.GenerateJwtToken(model.Mail);
                    return (new() { Profile = _mapper.Map<UserDto>(user), Token = token });
                }
                throw new Exception("AuthBusiness | SignInAsync | Invalid email or password!");
            }
            catch (Exception ex)
            {
                throw new Exception($"AuthBusiness | SignInAsync | {ex.Message}");
            }
        }
    }
}