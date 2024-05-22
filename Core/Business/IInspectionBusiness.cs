
using Core.DTOs.Inspection;
using Core.DTOs.Vehicle;
using Core.Entities.GenericEnterpise;

namespace Core.Business
{
    public interface IInspectionBusiness
    {
        Task<bool> ApproveOrRejectInspectionAsync(ApproveOrRejectDTO approveOrRejectDTO);
        Task<bool> CreateInspectionAsync(InspectionDTO inspectionDTO);
        Task<bool> CreateInspectionDetailAsync(InspectionDetailDTO inspectionDTO);
        Task<string> DeleteInspection(int idinspection);
    }
}
