using Act_01.Domain;
using Actividad_Facultad.Service.Implement;
using Actividad_Facultad.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB_API_Act_Fac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        //AGREGAR VARIABLE CLASE DE LA CLASE
        private readonly IGenericService<Invoice> _InvoiceService;
        //INYECCION DI POR CTOR
        public InvoicesController(IGenericService<Invoice> genericService)
        {
            _InvoiceService = genericService;
        }

        // GET: api/<InvoiceController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_InvoiceService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "ERROR 500 " });
            }
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var obj = _InvoiceService.GetById(id);
                if (obj == null) { return NotFound(); }
                else { return Ok(obj); }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "ERROR 500 " });
            }
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public IActionResult Post([FromBody] Invoice invoice)
        {
            if (invoice == null) { return BadRequest(); }
            int result = _InvoiceService.Save(invoice);
            if (result == 0) { return BadRequest(); }
            else { return Ok(_InvoiceService.Save(invoice)); }
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Invoice invoice)
        {
            if (invoice == null) { return BadRequest(); }
            int result = _InvoiceService.Save(invoice);
            if (result == 0) { return BadRequest(); }
            else { return Ok(_InvoiceService.Save(invoice)); }
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_InvoiceService.GetById(id) == null) { return NotFound(); }
            int result = _InvoiceService.Delete(id);
            if (result == 0) { return BadRequest(); }
            else { return Ok(); }
        }
    }
}
