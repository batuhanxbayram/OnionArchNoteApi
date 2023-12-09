using Microsoft.EntityFrameworkCore;
using NoteApi.Domain.Entities;
using System.Reflection;

namespace NoteApi.Persistence.context
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           
        }

    }
}
