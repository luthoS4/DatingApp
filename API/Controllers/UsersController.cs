using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
      public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() { // IEnumerable provides a pre written list type
            return await _context.Users.ToListAsync();
        }

        [Authorize]
        // api/users/3 - what will shown in the url
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) { // IEnumerable provides a pre written list type
           return await _context.Users.FindAsync(id);
        }
    }
}