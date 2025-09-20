using Act_01.Domain;
using Act_03.Services;
using Act_03.Services.Implement;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Act_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IGenericService<Article> _ArticleService;
        public ArticleController(IGenericService<Article> articleService)
        {
            _ArticleService = articleService;
        }
        // GET: api/<ArticleController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var obj = _ArticleService.GetAll();
                if (obj == null) { return NotFound(); }
                else { return Ok(obj); }
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        // GET api/<ArticleController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var obj = _ArticleService.GetById(id);
                if (obj == null) { return NotFound(); }
                else { return Ok(obj); }
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        // POST api/<ArticleController>
        [HttpPost]
        public IActionResult Post([FromBody] Article value)
        {
            try
            {
                if (value == null) { return NotFound(); }
                var obj = _ArticleService.Insert(value);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Article value)
        {
            try
            {
                if (value == null) { return NotFound(); }
                var obj = _ArticleService.Update(id, value);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var obj = _ArticleService.Delete(id);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return (IActionResult)ex;
            }
        }
    }
}
