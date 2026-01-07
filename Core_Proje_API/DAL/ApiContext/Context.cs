using Core_Proje_API.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core_Proje_API.DAL.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-R0GSR22\\SQLEXPRESS;database=CoreProjeDb2;integrated security=true;");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
