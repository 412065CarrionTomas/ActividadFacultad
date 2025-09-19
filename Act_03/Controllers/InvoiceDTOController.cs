using Act_03.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Act_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDTOController : ControllerBase
    {
        private readonly IInvoiceService _InvoiceService;
        public InvoiceDTOController(IInvoiceService invoiceService)
        {
            _InvoiceService = invoiceService;
        }
        //// GET: api/<InvoiceDTOController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

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

        //// POST api/<InvoiceDTOController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<InvoiceDTOController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<InvoiceDTOController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
