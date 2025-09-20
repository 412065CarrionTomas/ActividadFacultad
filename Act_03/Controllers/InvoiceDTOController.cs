using Act_01.Domain;
using Act_03.Models.Domain.DTOs;
using Act_03.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Act_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDTOController : ControllerBase
    {
        private readonly IGenericDTOService<InvoiceDTO> _InvoiceService;
        public InvoiceDTOController(IGenericDTOService<InvoiceDTO> invoiceService)
        {
            _InvoiceService = invoiceService;
        }
        
        // GET api/<InvoiceDTOController>/5
        [HttpGet]
        public IActionResult GetAllDTO()
        {
            try
            {
                var objLts = _InvoiceService.GetAllDTO();
                if (objLts == null) { return NotFound(); }
                else { return Ok(objLts); }
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDTOById(int id)
        {
            try
            {
                InvoiceDTO? invoiceDTO = _InvoiceService.GetDTOById(id);
                if(invoiceDTO == null) { return BadRequest(); }
                return Ok(invoiceDTO);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        
        // POST api/<InvoiceDTOController>
        [HttpPost]
        public IActionResult Post([FromBody] InvoiceDTO value)
        {
            try
            {
                bool result = _InvoiceService.InsertDTO(value);
                if(result == false) { return BadRequest(); }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        // PUT api/<InvoiceDTOController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InvoiceDTO value)
        {
            try
            {
                bool result = _InvoiceService.UpdateDTO(id, value);
                if(_InvoiceService.GetDTOById(id) == null) { return BadRequest(); }
                if(value == null) { return BadRequest(); }
                if(result == false) { return BadRequest(); }
                return Ok(value);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        // DELETE api/<InvoiceDTOController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool result = _InvoiceService.DeleteDTO(id);
                if (_InvoiceService.GetDTOById(id) == null) { return BadRequest(); }
                if (result == false) { return BadRequest(); }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }
    }
}
