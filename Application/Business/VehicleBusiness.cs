using AutoMapper;
using Core.Business;
using Core.DTOs.Vehicle;
using Core.Entities.GenericEnterpise;
using Core.Repositories;

namespace Application.Business
{
    public class VehicleBusiness(
         IMapper mapper,
         IGenericEnterpriseRepository<GeVehicle> repositoryVehicle,
         IGenericEnterpriseRepository<GeVehicleType> repositoryVehicleType,
         IGenericEnterpriseRepository<GeInspectable> repositoryInspectable,
         IGenericEnterpriseRepository<GeInspectableType> repositoryInspectableType
         ) : IVehicleBusiness
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGenericEnterpriseRepository<GeVehicle> _repositoryVehicle = repositoryVehicle;
        private readonly IGenericEnterpriseRepository<GeVehicleType> _repositoryVehicleType = repositoryVehicleType;
        private readonly IGenericEnterpriseRepository<GeInspectable> _repositoryInspectable = repositoryInspectable;
        private readonly IGenericEnterpriseRepository<GeInspectableType> _repositoryInspectableType = repositoryInspectableType;

        public async Task<bool> CreateVehicleTypeAsync(VehicleTypeDTO vehicleTypeDTO) {
            try
            {
                GeVehicleType geVehicleType = _mapper.Map<GeVehicleType>(vehicleTypeDTO);
                int result = await _repositoryVehicleType.Create(geVehicleType);

                return result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception($"VehicleBusiness | CreateVehicleTypeAsync | {ex.Message}");
            }
        }

        public async Task<IEnumerable<GeVehicleType>> GetAllVehicleTypeAsync()
        {
            try
            {

                IEnumerable<GeVehicleType> result = await _repositoryVehicleType.GetAll();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"VehicleBusiness | GetAllVehicleTypeAsync | {ex.Message}");
            }
        }

        public async Task<bool> CreateVehicleAsync(VehicleDTO vehicleDTO)
        {
            try
            {
                GeVehicle geVehicle = _mapper.Map<GeVehicle>(vehicleDTO);
                int result = await _repositoryVehicle.Create(geVehicle);

                return result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception($"VehicleBusiness | CreateVehicleAsync | {ex.Message}");
            }
        }

        public async Task<IEnumerable<GeVehicle>> GetAllVehicleAsync()
        {
            try
            {

                IEnumerable<GeVehicle> result = await _repositoryVehicle.GetAll();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"VehicleBusiness | GetAllVehicleAsync | {ex.Message}");
            }
        }

        public async Task<bool> CreateInspectableAsync(InspectableDTO inspectableDTO)
        {
            try
            {
                GeInspectable geInspectable = _mapper.Map<GeInspectable>(inspectableDTO);
                int result = await _repositoryInspectable.Create(geInspectable);

                return result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception($"VehicleBusiness | CreateInspectableAsync | {ex.Message}");
            }
        }

        public async Task<IEnumerable<GeInspectable>> GetAllInspectableAsync()
        {
            try
            {

                IEnumerable<GeInspectable> result = await _repositoryInspectable.GetAll();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"VehicleBusiness | GetAllInspectableAsync | {ex.Message}");
            }
        }

        public async Task<bool> CreateRelationInspectableVehicleTypeAsync(RelationInspectableVehicleTypeDTO relationInspectableVehicleTypeDTOs)
        {
            try
            {
                GeInspectableType geInspectableType = _mapper.Map<GeInspectableType>(relationInspectableVehicleTypeDTOs);
                int result = await _repositoryInspectableType.CreateNotTracked(geInspectableType);

                return result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception($"VehicleBusiness | CreateRelationInspectableVehicleTypeAsync | {ex.Message}");
            }
        }

    }
}
