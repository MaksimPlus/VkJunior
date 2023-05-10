using Microsoft.EntityFrameworkCore;
using System;
using UserApi.Models;

namespace UserApi.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserGroup> Groups { get; set; } = null!;
        public DbSet<UserState> States { get; set; } = null!;
    }
}
