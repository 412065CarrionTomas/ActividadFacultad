using Act_04.Models.Domain;
using Act_4.DTOS.ShipmentDTOs;
using Act_4.Services.ShipmentService;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Loader;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Act_4.Controllers.ShipmentControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentDTOsController : ControllerBase
    {
        private readonly IShipmentService _ShipmentService;
        public ShipmentDTOsController(IShipmentService shipmentService)
        {
            _ShipmentService = shipmentService;
        }

        // GET: api/<ShipmentController>/by-address/{addrres}
        [HttpGet]
        public IActionResult GetAllByFilters([FromQuery] string? addrres = null, string? state=null)
        {
            try
            {
                List<ShipmentDTORead>? shipmentsFilterLts = _ShipmentService.GetAllByFilter(state,addrres);
                if(shipmentsFilterLts == null) { return BadRequest(); }
                if(addrres == null && state == null)
                {
                    throw new InvalidOperationException("Tiene que realizar al menos un filtro.");
                }
                return Ok(shipmentsFilterLts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        // DELETE api/<ShipmentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _ShipmentService.Delete(id);
                if(result == false) { BadRequest(); }
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        
    }
}
