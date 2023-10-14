using EnvanterTakipSt.EFModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnvanterTakipSt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Departman> Departman { get; set; }
        public DbSet<Gecmis> Gecmis { get; set; }
        public DbSet<Malzeme> Malzeme { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Zimmet> Zimmet { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}