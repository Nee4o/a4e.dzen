
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
    public class DzenApiController:ControllerBase
    {
        
            private DzenDbContext? _userDB;
            public DzenApiController(DzenDbContext _context)
            {
                _userDB = _context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<User>>> Get()
            {
                return await _userDB._userContext.ToListAsync();
            }


            [HttpGet("{name}/{pass}")]
            public async Task<ActionResult<User>> Get(string name, string pass)
            {
                User model =
                    await _userDB._userContext.FirstOrDefaultAsync(x => x.Login == name && x.Password == pass);
                if (model == null)
                    return NotFound();
                return Ok(model);
            }


            [HttpPost]
            public async Task<ActionResult<User>> Post(User userModel)
            {
                if (userModel == null)
                    return BadRequest();
                if (_userDB._userContext.Any(u => u.Login == userModel.Login))
                    return NotFound();
                _userDB._userContext.Add(userModel);
                await _userDB.SaveChangesAsync();
                return Ok(userModel);
            }


            [HttpPut("{id}")]
            public async Task<ActionResult<User>> Put(User userModel)
            {
                if (userModel == null)
                    return BadRequest();
                if (!_userDB._userContext.Any(x => x.Id == userModel.Id))
                {
                    return NotFound();
                }
                _userDB._userContext.Update(userModel);
                await _userDB.SaveChangesAsync();
                return Ok(userModel);
            }


            [HttpDelete("{id}")]
            public async Task<ActionResult<User>> Delete(int id)
            {
                User user =
                    await _userDB._userContext.FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                    return NotFound();
                _userDB._userContext.Remove(user);
                await _userDB.SaveChangesAsync();
                return Ok(user);
            }
        
    }
}
