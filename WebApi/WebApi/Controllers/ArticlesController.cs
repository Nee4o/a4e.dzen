using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private AppDBContext? _db;
        public ArticlesController(AppDBContext appDBContext)
        {
            _db = appDBContext;
        }
        //articles
        [HttpGet]
        [Route("/getArticle")]
        public async Task<ActionResult<IEnumerable<Article>>> Get()
        {
            return await _db.Articles.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> Get(int id)
        {
            Article article = await _db.Articles.FirstOrDefaultAsync(x => x.Id == id);
            if (article == null)
                return NotFound();
            return new ObjectResult(article);
        }

        [HttpPost]
        [Route("/postArticle")]
        public async Task<ActionResult<Article>> Post(Article article)
        {
            if (article == null)
                return BadRequest();
            _db.Articles.Add(article);
            await _db.SaveChangesAsync();
            return Ok(article);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Article>> Put(Article article)
        {
            if (article == null)
            {
                return BadRequest();
            }
            if (!_db.Articles.Any(x => x.Id == article.Id))
            {
                return NotFound();
            }
            _db.Update(article);
            await _db.SaveChangesAsync();
            return Ok(article);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Article>> Delete(int id)
        {
            Article article = _db.Articles.FirstOrDefault(x => x.Id == id);
            if (article == null)
            {
                return NotFound();
            }
            _db.Articles.Remove(article);
            await _db.SaveChangesAsync();
            return Ok(article);
        }
    }  
}
