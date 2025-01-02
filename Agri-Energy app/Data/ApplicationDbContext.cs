using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Agri_Energy_app.Models;
using Agri_Energy_APP.Models;

namespace Agri_Energy_app.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Agri_Energy_app.Models.Product> Product { get; set; } = default!;
        public DbSet<Agri_Energy_app.Models.Farmer> Farmer { get; set; } = default!;
        public DbSet<Agri_Energy_APP.Models.Products> Products { get; set; } = default!;
    }
}
