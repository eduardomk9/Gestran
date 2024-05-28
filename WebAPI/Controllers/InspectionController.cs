﻿using Application.Business;
using Core.Business;
using Core.DTOs.Inspection;
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
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(412, new { message = "Não foi possível criar a inspeção. Este veículo ja está sendo inspecionado." });
                }
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
        public async Task<IActionResult> CreateInspectionDetailAsync(List<InspectionDetailDTO> model)
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
        /// <param name="id">Modelo de entrada</param>
        [HttpDelete("DeleteInspectionAsync")]
        [SwaggerResponse(200, "Informações", typeof(string))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> DeleteInspectionAsync(int id)
        {
            try
            {
                string result = await _InspectionBusiness.DeleteInspectionAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"InspectionController | DeleteInspectionAsync | {ex.Message}");
            }
        }


        /// <summary>
        /// Get inspections for a especific inspector
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to get all Inspectables by vehichle, sou you know what inspectable is needed
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>        
        /// <param name="model"> entrada</param>
        [HttpGet("GetInspectionByUserIdAsync")]
        [SwaggerResponse(200, "Informações", typeof(IEnumerable<GeInspection>))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> GetInspectionByUserIdAsync(int model)
        {
            try
            {
                IEnumerable<GeInspection> result = await _InspectionBusiness.GetInspectionByUserIdAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"VehicleController | GetInspectionByUserIdAsync | {ex.Message}");
            }
        }

    }
}
