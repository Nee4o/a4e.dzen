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
