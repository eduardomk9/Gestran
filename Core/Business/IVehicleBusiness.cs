
using Core.DTOs.Vehicle;
using Core.Entities.GenericEnterpise;

namespace Core.Business
{
    public interface IVehicleBusiness
    {
        Task<bool> CreateInspectableAsync(InspectableDTO inspectableDTO);
        Task<bool> CreateRelationInspectableVehicleTypeAsync(RelationInspectableVehicleTypeDTO relationInspectableVehicleTypeDTOs);
        Task<bool> CreateVehicleAsync(VehicleDTO vehicleDTO);
        Task<bool> CreateVehicleTypeAsync(VehicleTypeDTO geVehicleType);
        Task<IEnumerable<GeInspectable>> GetAllInspectableAsync();
        Task<IEnumerable<GeVehicle>> GetAllVehicleAsync();
        Task<IEnumerable<GeVehicleType>> GetAllVehicleTypeAsync();
    }
}
