using Act_01.Domain;
using Act_03.Services;
using Act_03.Services.Implement;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Act_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly IGenericService<InvoiceDetail> _InvoiceDetailService;
        public InvoiceDetailController(IGenericService<InvoiceDetail> invoiceDetailService)
        {
            _InvoiceDetailService = invoiceDetailService;
        }

        // GET: api/<InvoiceDetailController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var obj = _InvoiceDetailService.GetAll();
                if (obj == null) { return NotFound(); }
                else { return Ok(obj); }
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
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
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        // POST api/<InvoiceDetailController>
        [HttpPost]
        public IActionResult Post([FromBody] InvoiceDetail value)
        {
            try
            {
                if (value == null) { return NotFound(); }
                var obj = _InvoiceDetailService.Insert(value);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        // PUT api/<InvoiceDetailController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] InvoiceDetail value)
        {
            try
            {
                if (value == null) { return NotFound(); }
                var obj = _InvoiceDetailService.Update(id, value);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        // DELETE api/<InvoiceDetailController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var obj = _InvoiceDetailService.Delete(id);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }
    }
}
