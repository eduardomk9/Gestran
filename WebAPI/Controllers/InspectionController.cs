using Core.Business;
using Core.DTOs.Inspection;
using Core.DTOs.Vehicle;
using Core.Entities.GenericEnterpise;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Authorize("Bearer")]
    [Authorize(AuthenticationSchemes = "CustomAuth")]
    [Route("[controller]")]
    [ApiController]
    public class InspectionController(IInspectionBusiness inspectionBusiness) : ControllerBase
    {
        private readonly IInspectionBusiness _InspectionBusiness = inspectionBusiness;

        /// <summary>
        /// Create Inspection
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to Create a new Inspection
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>
        /// <param name="model">Modelo de entrada</param>
        [HttpPost("CreateInspectionAsync")]
        [SwaggerResponse(200, "Informações", typeof(bool))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> CreateInspectionAsync(InspectionDTO model)
        {
            try
            {
                bool result = await _InspectionBusiness.CreateInspectionAsync(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"InspectionController | CreateVehicleTypeAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Create Inspection Detail
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to Create a new Inspection Detail
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>
        /// <param name="model">Modelo de entrada</param>
        [HttpPost("CreateInspectionDetailAsync")]
        [SwaggerResponse(200, "Informações", typeof(bool))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> CreateInspectionDetailAsync(InspectionDetailDTO model)
        {
            try
            {
                bool result = await _InspectionBusiness.CreateInspectionDetailAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"InspectionController | CreateInspectionDetailAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Aprove or Reject a Inspection
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to Aprove or Reject a Inspection
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>
        /// <param name="model">Modelo de entrada</param>
        [HttpPut("ApproveOrRejectInspectionAsync")]
        [SwaggerResponse(200, "Informações", typeof(bool))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> ApproveOrRejectInspectionAsync(ApproveOrRejectDTO model)
        {
            try
            {
                bool result = await _InspectionBusiness.ApproveOrRejectInspectionAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"InspectionController | ApproveOrRejectInspectionAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a Inspection
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to Delete a Inspection and their Inspection Details
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>
        /// <param name="model">Modelo de entrada</param>
        [HttpDelete("DeleteInspection")]
        [SwaggerResponse(200, "Informações", typeof(string))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> DeleteInspection(int model)
        {
            try
            {
                string result = await _InspectionBusiness.DeleteInspection(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"InspectionController | DeleteInspection | {ex.Message}");
            }
        }

    }
}
