using Application.Business;
using Core.Business;
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
    public class VehicleController(IVehicleBusiness vehicleBusiness) : ControllerBase
    {
        private readonly IVehicleBusiness _vehicleBusiness = vehicleBusiness;

        /// <summary>
        /// Create Vehicle Type
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to Create a new Vehicle Type
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>
        /// <param name="model">Modelo de entrada</param>
        [HttpPost("CreateVehicleTypeAsync")]
        [SwaggerResponse(200, "Informações", typeof(bool))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> CreateVehicleTypeAsync(VehicleTypeDTO model)
        {
            try
            {
                bool result = await _vehicleBusiness.CreateVehicleTypeAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"VehicleController | CreateVehicleTypeAsync | {ex.Message}");
            }
        }


        /// <summary>
        /// Get All Vehicle Type
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to get all Vehicle Types
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>        
        /// <param > Sem entrada</param>
        [HttpGet("GetAllVehicleTypeAsync")]
        [SwaggerResponse(200, "Informações", typeof(IEnumerable<GeVehicleType>))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> GetAllVehicleTypeAsync()
        {
            try
            {
                IEnumerable<GeVehicleType> result = await _vehicleBusiness.GetAllVehicleTypeAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"VehicleController | GetAllVehicleTypeAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Create Vehicle
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to Create a new Vehicle
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>
        /// <param name="model">Modelo de entrada</param>
        [HttpPost("CreateVehicleAsync")]
        [SwaggerResponse(200, "Informações", typeof(bool))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> CreateVehicleAsync(VehicleDTO model)
        {
            try
            {
                bool result = await _vehicleBusiness.CreateVehicleAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"VehicleController | CreateVehicleAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Get All Vehicle
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to get all Vehicles
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>        
        /// <param > Sem entrada</param>
        [HttpGet("GetAllVehicleAsync")]
        [SwaggerResponse(200, "Informações", typeof(IEnumerable<GeVehicle>))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> GetAllVehicleAsync()
        {
            try
            {
                IEnumerable<GeVehicle> result = await _vehicleBusiness.GetAllVehicleAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"VehicleController | GetAllVehicleAsync | {ex.Message}");
            }
        }


        /// <summary>
        /// Create Inspectable
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to Create a new Inspectable
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>
        /// <param name="model">Modelo de entrada</param>
        [HttpPost("CreateInspectableAsync")]
        [SwaggerResponse(200, "Informações", typeof(bool))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> CreateInspectableAsync(InspectableDTO model)
        {
            try
            {
                bool result = await _vehicleBusiness.CreateInspectableAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"VehicleController | CreateInspectableAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Get All Inspectable
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to get all Inspectables
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>        
        /// <param > Sem entrada</param>
        [HttpGet("GetAllInspectableAsync")]
        [SwaggerResponse(200, "Informações", typeof(IEnumerable<GeInspectable>))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> GetAllInspectableAsync()
        {
            try
            {
                IEnumerable<GeInspectable> result = await _vehicleBusiness.GetAllInspectableAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"VehicleController | GetAllInspectableAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Get All Inspectable by Vehicle Id
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
        [HttpGet("GetAllInspectableByVehicleIdAsync")]
        [SwaggerResponse(200, "Informações", typeof(IEnumerable<GeInspectable>))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> GetInspectableByVehicleIdAsync(int model)
        {
            try
            {
                IEnumerable<GeInspectableType> result = await _vehicleBusiness.GetInspectableByVehichleIdAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"VehicleController | GetInspectableByVehicleIdAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Create Relation Inspectable x Vehicle
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to Create a new Inspectable
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>
        /// <param name="model">Modelo de entrada</param>
        [HttpPost("CreateRelationInspectableVehicleTypeAsync")]
        [SwaggerResponse(200, "Informações", typeof(bool))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> CreateRelationInspectableVehicleTypeAsync(RelationInspectableVehicleTypeDTO model)
        {
            try
            {
                bool result = await _vehicleBusiness.CreateRelationInspectableVehicleTypeAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"VehicleController | CreateRelationInspectableVehicleTypeAsync | {ex.Message}");
            }
        }


        /// <summary>
        /// Delete a Vehicle
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to Delete a Vehicle
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>
        /// <param name="id">Modelo de entrada</param>
        [HttpDelete("DeleteVehicleAsync")]
        [SwaggerResponse(200, "Informações", typeof(string))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> DeleteVehicleAsync(int id)
        {
            try
            {
                string result = await _vehicleBusiness.DeleteVehicleAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"InspectionController | DeleteVehicleAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a Vehicle Type and Relations to Inspectables
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to Delete a Vehicle and theis relations to inspectables
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>
        /// <param name="id">Modelo de entrada</param>
        [HttpDelete("DeleteVehicleTypeAsync")]
        [SwaggerResponse(200, "Informações", typeof(string))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> DeleteVehicleTypeAsync(int id)
        {
            try
            {
                string result = await _vehicleBusiness.DeleteVehicleTypeAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"InspectionController | DeleteVehicleAsync | {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a Inspectable
        /// </summary>
        /// <remarks>
        /// This dont method allow anonymous.
        /// 
        /// You have to call this method with a token in the header.
        /// 
        /// You can call this method to Delete a Inspectable
        /// 
        /// Fill correctly all parameters to call this method.
        /// 
        /// </remarks>
        /// <param name="id">Modelo de entrada</param>
        [HttpDelete("DeleteInspectableAsync")]
        [SwaggerResponse(200, "Informações", typeof(string))]
        [SwaggerResponse(400, "Erro", typeof(string))]
        public async Task<IActionResult> DeleteInspectableAsync(int id)
        {
            try
            {
                string result = await _vehicleBusiness.DeleteInspectableAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"InspectionController | DeleteInspectableAsync | {ex.Message}");
            }
        }

    }
}
