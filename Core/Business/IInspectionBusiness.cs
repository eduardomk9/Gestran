
using Core.DTOs.Inspection;
using Core.Entities.GenericEnterpise;

namespace Core.Business
{
    public interface IInspectionBusiness
    {
        Task<bool> ApproveOrRejectInspectionAsync(ApproveOrRejectDTO approveOrRejectDTO);
        Task<bool> CreateInspectionAsync(InspectionDTO inspectionDTO);
        Task<bool> CreateInspectionDetailAsync(List<InspectionDetailDTO> inspectionDTO);
        Task<string> DeleteInspectionAsync(int idinspection);
        Task<IEnumerable<GeInspection>> GetInspectionByUserIdAsync(int id);
    }
}
