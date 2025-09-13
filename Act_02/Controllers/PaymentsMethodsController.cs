using Act_01.Domain;
using Actividad_Facultad.Service.Implement;
using Actividad_Facultad.Service.Interfaces;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB_API_Act_Fac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsMethodsController : ControllerBase
    {
        //AGREGAR VARIABLE CLASE DE LA CLASE
        private readonly IGenericService<PaymentMethod> _PaymentMethodService;
        //INYECCION DI POR CTOR
        public PaymentsMethodsController(IGenericService<PaymentMethod> genericService)
        {
            _PaymentMethodService = genericService;
        }
        // GET: api/<PaymentMethodController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_PaymentMethodService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "ERROR 500 " });
            }
        }

        // GET api/<PaymentMethodController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var obj = _PaymentMethodService.GetById(id);
                if (obj == null) { return NotFound(); }
                else { return Ok(obj); }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "ERROR 500 " });
            }
        }

        // POST api/<PaymentMethodController>
        [HttpPost]
        public IActionResult Post([FromBody] PaymentMethod paymentMethod)
        {
            if (paymentMethod == null) { return BadRequest(); }
            int result = _PaymentMethodService.Save(paymentMethod);
            if (result == 0) { return BadRequest(); }
            else { return Ok(_PaymentMethodService.Save(paymentMethod)); }
        }

        // PUT api/<PaymentMethodController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] PaymentMethod paymentMethod)
        {
            if (paymentMethod == null) { return BadRequest(); }
            int result = _PaymentMethodService.Save(paymentMethod);
            if (result == 0) { return BadRequest(); }
            else { return Ok(_PaymentMethodService.Save(paymentMethod)); }
        }

        // DELETE api/<PaymentMethodController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_PaymentMethodService.GetById(id) == null) { return NotFound(); }
            int result = _PaymentMethodService.Delete(id);
            if (result == 0) { return BadRequest(); }
            else { return Ok(); }
        }
    }
}
