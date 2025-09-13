using Act_01.Domain;
using Actividad_Facultad.Service.Implement;
using Actividad_Facultad.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB_API_Act_Fac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailsController : ControllerBase
    {
        //AGREGAR VARIABLE CLASE DE LA CLASE
        private readonly IGenericService<InvoiceDetail> _InvoiceDetailService;
        //INYECCION DI POR CTOR
        public InvoiceDetailsController(IGenericService<InvoiceDetail> genericService)
        {
            _InvoiceDetailService = genericService;
        }
        // GET: api/<InvoiceDetailController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_InvoiceDetailService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "ERROR 500" });
            }
        }

        // GET api/<InvoiceDetailController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var obj = _InvoiceDetailService.GetById(id);
                if (obj == null) { return NotFound(); }
                else { return Ok(obj); }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "ERROR 500" });
            }
        }

        // POST api/<InvoiceDetailController>
        [HttpPost]
        public IActionResult Post([FromBody] InvoiceDetail invoiceDetail)
        {
            if (invoiceDetail == null) { return BadRequest(); }
            int result = _InvoiceDetailService.Save(invoiceDetail);
            if (result == 0) { return BadRequest(); }
            else { return Ok(_InvoiceDetailService.Save(invoiceDetail)); }
        }

        // PUT api/<InvoiceDetailController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] InvoiceDetail invoiceDetail)
        {
            if (invoiceDetail == null) { return BadRequest(); }
            int result = _InvoiceDetailService.Save(invoiceDetail);
            if (result == 0) { return BadRequest(); }
            else { return Ok(_InvoiceDetailService.Save(invoiceDetail)); }
        }

        // DELETE api/<InvoiceDetailController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_InvoiceDetailService.GetById(id) == null) { return NotFound(); }
            int result = _InvoiceDetailService.Delete(id);
            if (result == 0) { return BadRequest(); }
            else { return Ok(); }
        }
    }
}
