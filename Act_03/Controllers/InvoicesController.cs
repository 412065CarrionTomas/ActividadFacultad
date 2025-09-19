using Act_01.Domain;
using Act_03.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Act_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _InvoiceServices;
        public InvoicesController(IInvoiceService invoiceServices)
        {
            _InvoiceServices = invoiceServices;
        }


        // GET: api/<InvoicesController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var objLts = _InvoiceServices.GetAll();
                if (objLts == null) { return NotFound(); }
                else { return Ok(objLts); }
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        // GET api/<InvoicesController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var objLts = _InvoiceServices.GetById(id);
                if (objLts == null) { return NotFound(); }
                else { return Ok(objLts); }
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        // POST api/<InvoicesController>
        [HttpPost]
        public IActionResult Post([FromBody] Invoice invoice)
        {
            try
            {
                if(invoice == null || invoice is not IConvertible) { return BadRequest(); }
                var result = _InvoiceServices.Insert(invoice);
                if(result == true) { return Ok(result); }
                else { return BadRequest(); }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<InvoicesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Invoice invoiceUpdate)
        {
            try
            {
                if (invoiceUpdate == null || invoiceUpdate is not IConvertible) { return BadRequest(); }
                var result = _InvoiceServices.Update(id, invoiceUpdate);
                if (result == false) { return BadRequest(); }
                else { return Ok(result); }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<InvoicesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if(_InvoiceServices.GetById(id) == null) { return NotFound(); }
                else { return Ok(_InvoiceServices.Delete(id)); }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
