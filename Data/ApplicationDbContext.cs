using Asp.netCore_MVC_.Models;
using Microsoft.EntityFrameworkCore;

namespace Asp.netCore_MVC_.Data
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

    }
}
