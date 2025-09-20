using Act_01.Domain;
using Act_03.Services;
using Act_03.Services.Implement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Act_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IGenericService<PaymentMethod> _PaymentMethodService;
        public PaymentMethodController(IGenericService<PaymentMethod> paymentMethodService)
        {
            _PaymentMethodService = paymentMethodService;
        }
        // GET: api/<PaymentMethodController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var obj = _PaymentMethodService.GetAll();
                if (obj == null) { return NotFound(); }
                else { return Ok(obj); }
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
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
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        // POST api/<PaymentMethodController>
        [HttpPost]
        public IActionResult Post([FromBody] PaymentMethod value)
        {
            try
            {
                if (value == null) { return NotFound(); }
                var obj = _PaymentMethodService.Insert(value);
                return Ok(obj); 
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        // PUT api/<PaymentMethodController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PaymentMethod value)
        {
            try
            {
                if (value == null) { return NotFound(); }
                var obj = _PaymentMethodService.Update(id, value);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        // DELETE api/<PaymentMethodController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var obj = _PaymentMethodService.Delete(id);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }
    }
}
