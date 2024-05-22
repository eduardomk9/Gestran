using AutoMapper;
using Core.Dtos.Auth;
using Core.Dtos.User;
using Core.DTOs.Inspection;
using Core.DTOs.Vehicle;
using Core.Entities.GenericEnterpise;


namespace WebAPI.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            #region Auth
            CreateMap<GeAuthentication, AuthDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdAuth))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameAuth))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayNameAuth));

            CreateMap<SignUpDto, GeUser>()
                .ForMember(dest => dest.FirstNameUser, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastNameUser, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.JobTitleUser, opt => opt.MapFrom(src => src.JobTitle))
                .ForMember(dest => dest.LoginUser, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.MailUser, opt => opt.MapFrom(src => src.Mail))
                .ForMember(dest => dest.PhoneUser, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.PhotoUser, opt => opt.MapFrom(src => src.Photo))
                .ForMember(dest => dest.PasswordUser, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.IdAuth, opt => opt.MapFrom(src => src.IdAuth))
                .ForMember(dest => dest.IsActiveUser, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.GeMemberOfs, opt => opt.MapFrom(src => new List<GeMemberOf>
                {
                    new ()
                    {
                        IdProf = src.IdProf,
                    }
                }));
            #endregion

            #region User
            CreateMap<GeUser, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdUser))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstNameUser))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastNameUser))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitleUser))
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.LoginUser))
                .ForMember(dest => dest.Mail, opt => opt.MapFrom(src => src.MailUser))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.PhoneUser))
                .ForMember(dest => dest.Photo, opt => opt.MapFrom(src => src.PhotoUser))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActiveUser))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeletedUser))
                .ForMember(dest => dest.Auth, opt => opt.MapFrom(src => src.IdAuthNavigation))
                .ForMember(dest => dest.MemberOf, opt => opt.MapFrom(src => src.GeMemberOfs.Select(m => new MemberOfDto()
                {
                    Id = m.IdProf,
                    IdMeof = m.IdMeof,
                    Name = m.IdProfNavigation.NameProf,
                    DisplayName = m.IdProfNavigation.DisplayNameProf
                })));

            CreateMap<UserCreateDto, GeUser>()
                .ForMember(dest => dest.FirstNameUser, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastNameUser, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.JobTitleUser, opt => opt.MapFrom(src => src.JobTitle))
                .ForMember(dest => dest.LoginUser, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.MailUser, opt => opt.MapFrom(src => src.Mail))
                .ForMember(dest => dest.PhoneUser, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.PhotoUser, opt => opt.MapFrom(src => src.Photo))
                .ForMember(dest => dest.PasswordUser, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.IdAuth, opt => opt.MapFrom(src => src.IdAuth))
                .ForMember(dest => dest.IsActiveUser, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.GeMemberOfs, opt => opt.MapFrom(src => new List<GeMemberOf>
                {
                    new ()
                    {
                        IdProf = src.IdProf,
                    }
                }));

            CreateMap<UserUpdateDto, GeUser>()
                .ForMember(dest => dest.IdUser, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstNameUser, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastNameUser, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.JobTitleUser, opt => opt.MapFrom(src => src.JobTitle))
                .ForMember(dest => dest.LoginUser, opt => opt.MapFrom(src => src.Login))
                .ForMember(dest => dest.MailUser, opt => opt.MapFrom(src => src.Mail))
                .ForMember(dest => dest.PhoneUser, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.PhotoUser, opt => opt.MapFrom(src => src.Photo))
                .ForMember(dest => dest.IsActiveUser, opt => opt.MapFrom(src => src.IsActive));

            #endregion

            #region MemberOf
            CreateMap<GeMemberOf, MemberOfDto>()
                .ForMember(dest => dest.IdMeof, opt => opt.MapFrom(src => src.IdMeof))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdProf));
            #endregion

            #region Profile
            CreateMap<GeProfile, MemberOfDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdProf))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameProf))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayNameProf));
            CreateMap<GeProfile, ProfileDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdProf))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameProf))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayNameProf));
            #endregion


            // Map from VehicleTypeDTO to GeVehicleType
            CreateMap<VehicleTypeDTO, GeVehicleType>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
            .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
            .ForMember(dest => dest.Feature1, opt => opt.MapFrom(src => src.Feature1))
            .ForMember(dest => dest.Feature2, opt => opt.MapFrom(src => src.Feature2))
            .ForMember(dest => dest.Feature3, opt => opt.MapFrom(src => src.Feature3))
            .ForMember(dest => dest.GeVehicles, opt => opt.Ignore())
            .ForMember(dest => dest.VehicleTypeId, opt => opt.Ignore());

            // Map from GeVehicleType to VehicleTypeDTO
            CreateMap<GeVehicleType, VehicleTypeDTO>()
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Feature1, opt => opt.MapFrom(src => src.Feature1))
                .ForMember(dest => dest.Feature2, opt => opt.MapFrom(src => src.Feature2))
                .ForMember(dest => dest.Feature3, opt => opt.MapFrom(src => src.Feature3));

            // Map from VehicleDTO to GeVehicle
            CreateMap<VehicleDTO, GeVehicle>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.LicensePlate, opt => opt.MapFrom(src => src.LicensePlate))
            .ForMember(dest => dest.VehicleTypeId, opt => opt.MapFrom(src => src.VehicleTypeId))
            .ForMember(dest => dest.LastInspection, opt => opt.MapFrom(src => src.LastInspection))
            .ForMember(dest => dest.LastInspectorUserId, opt => opt.MapFrom(src => src.LastInspectorUserId))
            .ForMember(dest => dest.IsBeingInspected, opt => opt.MapFrom(src => src.IsBeingInspected))
            .ForMember(dest => dest.VehicleId, opt => opt.Ignore())
            .ForMember(dest => dest.VehicleType, opt => opt.Ignore());

            // Map from GeVehicle to VehicleDTO
            CreateMap<GeVehicle, VehicleDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LicensePlate, opt => opt.MapFrom(src => src.LicensePlate))
                .ForMember(dest => dest.VehicleTypeId, opt => opt.MapFrom(src => src.VehicleTypeId))
                .ForMember(dest => dest.LastInspection, opt => opt.MapFrom(src => src.LastInspection))
                .ForMember(dest => dest.LastInspectorUserId, opt => opt.MapFrom(src => src.LastInspectorUserId))
                .ForMember(dest => dest.IsBeingInspected, opt => opt.MapFrom(src => src.IsBeingInspected));

            // Map from InspectableDTO to GeInspectable
            CreateMap<InspectableDTO, GeInspectable>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.InspectableId, opt => opt.Ignore())
            .ForMember(dest => dest.GeInspectionDetails, opt => opt.Ignore());

            // Map from GeVehicleType to VehicleTypeDTO
            CreateMap<GeInspectable, InspectableDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            // Map from RelationInspectableVehicleTypeDTO to GeInspectableType
            CreateMap<RelationInspectableVehicleTypeDTO, GeInspectableType>()
            .ForMember(dest => dest.InspectableId, opt => opt.MapFrom(src => src.InspectableId))
            .ForMember(dest => dest.VehicleTypeId, opt => opt.MapFrom(src => src.VehicleTypeId))
            .ForMember(dest => dest.Inspectable, opt => opt.Ignore())
            .ForMember(dest => dest.VehicleType, opt => opt.Ignore());

            // Map from GeInspectableType to RelationInspectableVehicleTypeDTO
            CreateMap<GeInspectableType, RelationInspectableVehicleTypeDTO>()
                .ForMember(dest => dest.InspectableId, opt => opt.MapFrom(src => src.InspectableId))
                .ForMember(dest => dest.VehicleTypeId, opt => opt.MapFrom(src => src.VehicleTypeId));

            // Map from InspectionDTO to GeInspection
            CreateMap<InspectionDTO, GeInspection>()
            .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId))
            .ForMember(dest => dest.InspectorId, opt => opt.MapFrom(src => src.InspectorId))
            .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
            .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
            .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
            .ForMember(dest => dest.Status, opt => opt.Ignore())
            .ForMember(dest => dest.Vehicle, opt => opt.Ignore())
            .ForMember(dest => dest.GeInspectionDetails, opt => opt.Ignore());

            // Map from GeInspection to InspectionDTO
            CreateMap<GeInspection, InspectionDTO>()
                .ForMember(dest => dest.VehicleId, opt => opt.MapFrom(src => src.VehicleId))
                .ForMember(dest => dest.InspectorId, opt => opt.MapFrom(src => src.InspectorId))
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.StatusId))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate));

            // Map from InspectionDetailDTO to GeInspection
            CreateMap<InspectionDetailDTO, GeInspectionDetail>()
            .ForMember(dest => dest.InspectionId, opt => opt.MapFrom(src => src.InspectionId))
            .ForMember(dest => dest.InspectableId, opt => opt.MapFrom(src => src.InspectableId))
            .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result))
            .ForMember(dest => dest.Observation, opt => opt.MapFrom(src => src.Observation))
            .ForMember(dest => dest.InspectionDetailId, opt => opt.Ignore())
            .ForMember(dest => dest.Inspectable, opt => opt.Ignore())
            .ForMember(dest => dest.Inspection, opt => opt.Ignore());

            // Map from GeInspection to InspectionDetailDTO
            CreateMap<GeInspectionDetail, InspectionDetailDTO>()
                .ForMember(dest => dest.InspectionId, opt => opt.MapFrom(src => src.InspectionId))
                .ForMember(dest => dest.InspectableId, opt => opt.MapFrom(src => src.InspectableId))
                .ForMember(dest => dest.Result, opt => opt.MapFrom(src => src.Result))
                .ForMember(dest => dest.Observation, opt => opt.MapFrom(src => src.Observation));
        }

    }
}
