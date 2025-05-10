using ApplicationService.EntityModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GarneyAppSystemAPI.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<user> user { get; set; }
        public DbSet<userlogin> userlogin { get; set; }
    }
}
