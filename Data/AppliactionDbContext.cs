using EmlpoyeesDetails.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmlpoyeesDetails.Data
{
    public class AppliactionDbContext: DbContext
    {
        public AppliactionDbContext(DbContextOptions<AppliactionDbContext> options) : base(options)
        {
        }

        public DbSet<Employeedtl> Employees { get; set; }
    }
}
