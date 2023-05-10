using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using UserApi.Data;
using UserApi.Models;
using UserApi.Models.Dto;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
        private readonly UserDbContext context;

        public UserController(UserDbContext context)
        {
            this.context = context;
        }

        [HttpGet("/{page}")]
        public async Task<IActionResult> GetUsers(int page)
        {
            var pageResults = 3f;
            var pageCount = Math.Ceiling(context.Users.Count() / pageResults);
            var users = await context.Users
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();
            var response = new UserResponse
            {
                Users = users,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(string id)
        {
            int Id = int.Parse(id);
            var user = await context.Users.FindAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [Authorize]
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<User>> Create(UserDto userDto)
        {
            User user = new(
                userDto.Id,
                userDto.Login,
                userDto.Password,
                userDto.CreatedDate,
                userDto.UserStateId,
                userDto.UserGroupId
                );
            var searchLogin = await context.Users.FirstOrDefaultAsync(x => x.Login == userDto.Login);
            if (searchLogin != null)
            {
                return NotFound(new { message = "Пользователь с таким логином уже есть." });
            }
            if(userDto.UserGroupId == 1)
            {
                var searchGroup = await context.Users.FirstOrDefaultAsync(x => x.UserGroupId == userDto.UserGroupId);
                if(searchGroup != null)
                {
                    return NotFound(new { message = "Администратор уже есть." });
                }
            }
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return CreatedAtAction("GetUsers", new { id = user.Id }, user);
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, UserDto userDto)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == id);
            if (user == null)
            {
                return NotFound(new { message = "Пользователь не найден" });
            }
            user.Id = userDto.Id;
            user.Login = userDto.Login;
            user.Password = userDto.Password;
            user.CreatedDate = userDto.CreatedDate;
            user.UserGroupId = userDto.UserGroupId;
            user.UserStateId = userDto.UserStateId;
            if (userDto.UserStateId == 2)
            {
                await Delete(id);
                return NoContent();
            }
            await context.SaveChangesAsync();
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            int Id = int.Parse(id);
            var user = await context.Users.FindAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}