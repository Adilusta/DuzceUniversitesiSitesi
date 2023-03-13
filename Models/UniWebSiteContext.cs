using Microsoft.EntityFrameworkCore;

namespace Web_Vize_Proje.Models
{
    public class UniWebSiteContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-A7KUBO2;database=UniWebSiteDb; integrated security=true;");

        }
        public DbSet<Yonetici> Yoneticiler { get; set; }
        public DbSet<Duyuru> Duyurular { get; set; }
    }
}
