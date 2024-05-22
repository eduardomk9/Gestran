
using Core.DTOs.Inspection;

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
