
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
        Task<string> DeleteInspectableAsync(int idInspectable);
        Task<string> DeleteVehicleAsync(int idVehicle);
        Task<string> DeleteVehicleTypeAsync(int idVehicleType);
        Task<IEnumerable<GeInspectable>> GetAllInspectableAsync();
        Task<IEnumerable<GeVehicle>> GetAllVehicleAsync();
        Task<IEnumerable<GeVehicleType>> GetAllVehicleTypeAsync();
        Task<IList<GeInspectable>> GetInspectableByVehichleIdAsync(int id);
    }
}
