
using Microsoft.EntityFrameworkCore;
using ToolManagementSystem.Models;

namespace ToolManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tool> Tools { get; set; }
    }
}
