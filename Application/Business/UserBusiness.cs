using AutoMapper;
using Core.Business;
using Core.Dtos.User;
using Core.Entities.GenericEnterpise;
using Core.Repositories;
using Core.Utils;
using Microsoft.EntityFrameworkCore;

namespace Application.Business
{
    public class UserBusiness(
        IGenericEnterpriseRepository<GeUser> repositoryGeUser,
        IGenericEnterpriseRepository<GeMemberOf> repositoryGeMemberOf,
        IGenericEnterpriseRepository<GeProfile> repositoryGeProfile,
        IMapper mapper) : IUserBusiness
    {
        private readonly IGenericEnterpriseRepository<GeUser> _repositoryGeUser = repositoryGeUser;
        private readonly IGenericEnterpriseRepository<GeMemberOf> _repositoryGeMemberOf = repositoryGeMemberOf;
        private readonly IGenericEnterpriseRepository<GeProfile> _repositoryGeProfile = repositoryGeProfile;
        private readonly IMapper _mapper = mapper;

        public async Task<List<ProfileDto>> GetAllProfilesAsync()
        {
            try
            {
                IEnumerable<GeProfile> profiles = await _repositoryGeProfile.GetAll(x => !x.IsDeletedProf && x.IsActiveProf);
                return _mapper.Map<List<ProfileDto>>(profiles);
            }
            catch (Exception ex)
            {
                throw new Exception($"UserBusiness | GetAllProfilesAsync | {ex.Message}");
            }
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            try
            {
                IEnumerable<GeUser> users = await _repositoryGeUser.GetAll(x => !x.IsDeletedUser,
                    includes: query => query
                    .Include(x => x.IdAuthNavigation)
                    .Include(x => x.GeMemberOfs.Where(w => w.IdProfNavigation.IsActiveProf))
                    .ThenInclude(x => x.IdProfNavigation));
                return _mapper.Map<List<UserDto>>(users);
            }
            catch (Exception ex)
            {
                throw new Exception($"UserBusiness | GetAllAsync | {ex.Message}");
            }
        }
        public async Task<UserDto> GetAsync(int id)
        {
            try
            {
                GeUser? user = await _repositoryGeUser.Get(x => x.IdUser == id,
                    includes: query => query
                    .Include(x => x.IdAuthNavigation)
                    .Include(x => x.GeMemberOfs.Where(w => w.IdProfNavigation.IsActiveProf))
                    .ThenInclude(x => x.IdProfNavigation));
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"UserBusiness | GetAsync | {ex.Message}");
            }
        }
        public async Task<UserDto> CreateAsync(UserCreateDto model)
        {
            try
            {
                if (model.IdAuth == 2) // Encrypt Password
                {
                    if (!string.IsNullOrEmpty(model.Password))
                        model.Password = CryptoUtils.Encrypt(model.Password);
                }

                GeUser? user = await _repositoryGeUser.CreateScope(_mapper.Map<GeUser>(model));
                user = await _repositoryGeUser.Get(x => x.IdUser == user.IdUser,
                    includes: query => query
                    .Include(x => x.IdAuthNavigation)
                    .Include(x => x.GeMemberOfs.Where(w => w.IdProfNavigation.IsActiveProf))
                    .ThenInclude(x => x.IdProfNavigation));
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"UserBusiness | CreateAsync | {ex.Message}");
            }
        }

        public async Task<UserDto> UpdateAsync(UserUpdateDto model)
        {
            try
            {
                GeUser? user = await _repositoryGeUser.Get(x => x.IdUser == model.Id,
                    includes: query => query
                    .Include(x => x.IdAuthNavigation)
                    .Include(x => x.GeMemberOfs.Where(w => w.IdProfNavigation.IsActiveProf))
                    .ThenInclude(x => x.IdProfNavigation)
                    ) ?? throw new Exception("User not found");
                _mapper.Map(model, user);
                await _repositoryGeUser.Update(user);

                IEnumerable<GeMemberOf> GeMemberOfs = await _repositoryGeMemberOf.GetAll(x => x.IdUser == user.IdUser);
                await _repositoryGeMemberOf.DeleteRange(GeMemberOfs);
                await _repositoryGeMemberOf.Create(new GeMemberOf()
                {
                    IdUser = model.Id,
                    IdProf = model.IdProf
                });


                user = await _repositoryGeUser.Get(x => x.IdUser == user.IdUser,
                    includes: query => query
                    .Include(x => x.IdAuthNavigation)
                    .Include(x => x.GeMemberOfs.Where(w => w.IdProfNavigation.IsActiveProf))
                    .ThenInclude(x => x.IdProfNavigation));

                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"UserBusiness | UpdateAsync | {ex.Message}");
            }
        }

        public async Task DeleteAsync(bool islogical, int id)
        {
            try
            {
                GeUser? user = await _repositoryGeUser.Get(x => x.IdUser == id) ?? throw new Exception("User not found");
                if (islogical)
                {
                    user.IsActiveUser = false;
                    user.IsDeletedUser = true;
                    await _repositoryGeUser.Update(user);
                }
                else
                {
                    await _repositoryGeUser.Delete(user);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"UserBusiness | DeleteAsync | {ex.Message}");
            }
        }

        public async Task<List<UserDto>> GetAllTrashAsync()
        {
            try
            {
                IEnumerable<GeUser> users = await _repositoryGeUser.GetAll(x => x.IsDeletedUser,
                    includes: query => query
                    .Include(x => x.IdAuthNavigation)
                    .Include(x => x.GeMemberOfs.Where(w => w.IdProfNavigation.IsActiveProf))
                    .ThenInclude(x => x.IdProfNavigation));
                return _mapper.Map<List<UserDto>>(users);
            }
            catch (Exception ex)
            {
                throw new Exception($"UserBusiness | GetAllTrashAsync | {ex.Message}");
            }
        }

        public async Task RestoreTrashAsync(int id)
        {
            try
            {
                GeUser? user = await _repositoryGeUser.Get(x => x.IdUser == id) ?? throw new Exception("User not found");
                user.IsDeletedUser = false;
                await _repositoryGeUser.Update(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"UserBusiness | RestoreTrashAsync | {ex.Message}");
            }
        }

        public async Task UpdatePhotoAsync(UserPhotoUpdateDto model)
        {
            try
            {
                GeUser? user = await _repositoryGeUser.Get(x => x.IdUser == model.Id) ?? throw new Exception("User not found");
                user.PhotoUser = model.Photo;
                await _repositoryGeUser.Update(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"UserBusiness | UpdatePhotoAsync | {ex.Message}");
            }
        }

        public async Task UpdatePasswordAsync(UserPasswordUpdateDto model)
        {
            try
            {
                GeUser? user = await _repositoryGeUser.Get(x => x.IdUser == model.Id) ?? throw new Exception("User not found");
                user.PasswordUser = CryptoUtils.Encrypt(model.Password);
                await _repositoryGeUser.Update(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"UserBusiness | UpdatePasswordAsync | {ex.Message}");
            }
        }
    }
}
