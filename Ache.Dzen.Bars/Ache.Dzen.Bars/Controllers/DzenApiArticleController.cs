using Ache.Dzen.Bars.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ache.Dzen.Bars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DzenApiArticleController:ControllerBase
    {
        private DzenDbContext? _dbcontext;
        public DzenApiArticleController(DzenDbContext _context)
        {
            _dbcontext = _context;
        }
        [HttpGet]
        public async Task<IEnumerable<Article>> Get()
        {
            return await _dbcontext._articleContext.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> Get(int id)
        {
            var art =
                await _dbcontext._articleContext.FirstOrDefaultAsync(
                    x => x.Id == id);
            if (art == null) return BadRequest();
            return Ok(art);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Article>> Delete(int id)
        {
            var art =
                await _dbcontext._articleContext.FirstOrDefaultAsync(
                    x => x.Id == id);
            if (art == null) return BadRequest();
            _dbcontext._articleContext.Remove(art);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<Article>> Post(Article article)
        {
            if (article == null)
                return BadRequest();
            _dbcontext._articleContext.Add(article);
            await _dbcontext.SaveChangesAsync();
            return Ok(article);
        }
    }
}
