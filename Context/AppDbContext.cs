using AlfaSoft.Models;
using Microsoft.EntityFrameworkCore;

namespace AlfaSoft.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Contact>().HasKey(c => c.ID);
            modelBuilder.Entity<Contact>().Property(c => c.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Contact>().Property(c => c.ContactPhone).HasMaxLength(9).IsRequired();
            modelBuilder.Entity<Contact>().Property(c => c.Email).HasMaxLength(100).IsRequired();
        }
    }
}
