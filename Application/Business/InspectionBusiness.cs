using AutoMapper;
using Core.Business;
using Core.DTOs.Inspection;
using Core.Entities.GenericEnterpise;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Business
{
    public class InspectionBusiness(
         IMapper mapper,
         IGenericEnterpriseRepository<GeInspection> repositoryInspection,
         IGenericEnterpriseRepository<GeInspectionDetail> repositoryInspectionDetail,
         IGenericEnterpriseRepository<GeUser> repositoryUser,
         IGenericEnterpriseRepository<GeVehicle> repositoryVehicle
         ) : IInspectionBusiness
    {
        private readonly IMapper _mapper = mapper;
        private readonly IGenericEnterpriseRepository<GeInspection> _repositoryInspection = repositoryInspection;
        private readonly IGenericEnterpriseRepository<GeInspectionDetail> _repositoryInspectionDetail = repositoryInspectionDetail;
        private readonly IGenericEnterpriseRepository<GeUser> _repositoryUser = repositoryUser;
        private readonly IGenericEnterpriseRepository<GeVehicle> _repositoryVehicle = repositoryVehicle;

        public async Task<bool> CreateInspectionAsync(InspectionDTO inspectionDTO)
        {
            try
            {
                int result = 0;
                GeVehicle? geVehicle = await _repositoryVehicle.GetById(inspectionDTO.VehicleId ?? 0);

                if (geVehicle != null)
                {

                    if (geVehicle.IsBeingInspected == false)
                    {
                        geVehicle.IsBeingInspected = true;
                        GeInspection geInspection = _mapper.Map<GeInspection>(inspectionDTO);
                        GeVehicle updateResult = await _repositoryVehicle.Update(geVehicle);
                        result = await _repositoryInspection.Create(geInspection);
                    }
                }

                return result == 1;
            }
            catch (Exception ex)
            {
                throw new Exception($"InspectionBusiness | CreateInspectionAsync | {ex.Message}");
            }
        }
        public async Task<bool> CreateInspectionDetailAsync(List<InspectionDetailDTO> inspectionDetailDTO)
        {
            try
            {
                int inspectionId = inspectionDetailDTO?.FirstOrDefault()?.InspectionId ?? 0;
                List<GeInspectionDetail> geInspectionDetail = _mapper.Map<List<GeInspectionDetail>>(inspectionDetailDTO);
                int resultDel = await _repositoryInspectionDetail.Delete(x => x.InspectionId == inspectionId);
                await _repositoryInspectionDetail.CreateRangeAsync(geInspectionDetail);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"InspectionBusiness | CreateInspectionDetailAsync | {ex.Message}");
            }
        }
        public async Task<bool> ApproveOrRejectInspectionAsync(ApproveOrRejectDTO approveOrRejectDTO)
        {
            try
            {
                bool result = false;
                GeUser? geUser = await _repositoryUser.GetById(approveOrRejectDTO.IdUser) ?? new();

                string jobTitleUser = geUser.JobTitleUser ?? "";
                if (jobTitleUser.ToLower().Equals("supervisor"))
                {
                    GeInspection? geInspection = await _repositoryInspection.GetById(approveOrRejectDTO.IdInspection) ?? throw new ArgumentException("Inspection not found.");
                    geInspection.EndDate = DateTime.Now;
                    geInspection.StatusId = approveOrRejectDTO.StatusInspection;
                    geInspection.Comment += $"\n[{geUser.FirstNameUser}]\n{approveOrRejectDTO.Comment}";

                    GeInspection geInspecUpdResult = await _repositoryInspection.Update(geInspection);
                    GeVehicle? geVehicle = await _repositoryVehicle.GetById(geInspection.VehicleId ?? 0) ?? throw new ArgumentException("Vehicle not found.");
                    if (geInspecUpdResult.InspectionId > 0)
                    {
                        geVehicle.IsBeingInspected = false;
                        GeVehicle updateResult = await _repositoryVehicle.Update(geVehicle);
                        result = true;
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"InspectionBusiness | ApproveOrRejectInspectionAsync | {ex.Message}");
            }
        }
        public async Task<string> DeleteInspectionAsync(int idinspection)
        {
            try
            {

                int insDetails = await _repositoryInspectionDetail.Delete(x => x.InspectionId == idinspection);

                int ins = await _repositoryInspection.Delete(x => x.InspectionId == idinspection);

                return $"{ins} Inspections affecteds and {insDetails} Details affecteds";
            }
            catch (Exception ex)
            {
                throw new Exception($"InspectionBusiness | ApproveOrRejectInspectionAsync | {ex.Message}");
            }
        }
        public async Task<IEnumerable<GeInspection>> GetInspectionByUserIdAsync(int id)
        {
            try
            {
                IEnumerable<GeInspection> inspections = await _repositoryInspection.GetAll(x => x.InspectorId == id,
                            includes: query => query
                            .Include(inspecDetails => inspecDetails.GeInspectionDetails)
                            .Include(vehicle => vehicle.Vehicle)
                            .Include(status => status.Status));

                return inspections;
            }
            catch (Exception ex)
            {
                throw new Exception($"InspectionBusiness | GetInspectionByUserIdAsync | {ex.Message}");
            }
        }

    }
}
