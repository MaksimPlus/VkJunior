using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using UserApi.Controllers;
using UserApi.Data;

namespace UnitTest
{
    public class PostUnitTest
    {
        private readonly UserDbContext context;
        public static DbContextOptions<UserDbContext>? dbContextOptions { get; set; }
        public static string connectionString = "Server=localhost;Port=5432;User Id=postgres; Password=5482;Database=DbUserApi";
        static PostUnitTest()
        {

            dbContextOptions = new DbContextOptionsBuilder<UserDbContext>()
                .UseNpgsql(connectionString)
                .Options;
        }
        [Fact]
        public async void Task_GetById()
        {
            var controller = new UserController(context); 

        }
    }
}