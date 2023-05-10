using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Models;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : Controller
    {
        private readonly UserDbContext context;
        public UserGroupController(UserDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetGroup()
        {
            return Ok(context.Groups.ToList());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGroup>> GetGroupById(string id)
        {
            int Id = int.Parse(id);
            var group = await context.Groups.FindAsync(Id);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }
    }
}
