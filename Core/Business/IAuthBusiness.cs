using Core.Dtos.Auth;

namespace Core.Business
{
    public interface IAuthBusiness
    {
        Task<SignInResponseDto> SignInAsync(SignInDto model);
    }
}
