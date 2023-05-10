using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Models;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStateController : Controller
    {
        private readonly UserDbContext context;
        public UserStateController(UserDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetState()
        {
            return Ok(context.States.ToList());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserState>> GetStateById(string id)
        {
            int Id = int.Parse(id);
            var state = await context.States.FindAsync(Id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);
        }

    }
}
