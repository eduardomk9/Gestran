
using Core.Dtos.User;

namespace Core.Business
{
    public interface IUserBusiness
    { 
        Task<List<ProfileDto>> GetAllProfilesAsync();
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> GetAsync(int id);
        Task<UserDto> CreateAsync(UserCreateDto model);
        Task<UserDto> UpdateAsync(UserUpdateDto model);
        Task DeleteAsync(bool islogical, int id);
        Task<List<UserDto>> GetAllTrashAsync();
        Task RestoreTrashAsync(int id);
        Task UpdatePhotoAsync(UserPhotoUpdateDto model);
        Task UpdatePasswordAsync(UserPasswordUpdateDto model);
    }
}
