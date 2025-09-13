using Act_01.Domain;
using Actividad_Facultad.Service.Implement;
using Actividad_Facultad.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB_API_Act_Fac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IGenericService<Article> _ArticleService;
        public ArticlesController(IGenericService<Article> genericService)
        {
            _ArticleService = genericService;
        }

        // GET: api/<ArticleController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ArticleService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "ERROR 500" });
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "ERROR 500" });
            }
        }

        // POST api/<ArticleController>
        [HttpPost]
        public IActionResult Post([FromBody] Article article)
        {
            if (article == null) { return BadRequest(); }
            int result = _ArticleService.Save(article);
            if (result == 0) { return BadRequest(); }
            else { return Ok(_ArticleService.Save(article)); }
        }

        // PUT api/<ArticleController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Article article)
        {
            if (article == null) { return BadRequest(); }
            int result = _ArticleService.Save(article);
            if (result == 0) { return BadRequest(); }
            else { return Ok(_ArticleService.Save(article)); }
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_ArticleService.GetById(id) == null) { return NotFound(); }
            int result = _ArticleService.Delete(id);
            if (result == 0) { return BadRequest(); }
            else { return Ok(); }
        }
    }
}
