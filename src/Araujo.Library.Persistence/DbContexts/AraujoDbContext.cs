using Araujo.Library.Domain.Common;
using Araujo.Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Araujo.Library.Persistence.DbContexts
{
    public partial class AraujoDbContext : DbContext
    {

        public AraujoDbContext(DbContextOptions<AraujoDbContext> options)
         : base(options)
        {
        }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseCategories> CourseCategories { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseCategories>().HasKey(cc => new { cc.BookCategoryId, cc.CourseId });

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var auditableEntity = ChangeTracker
            .Entries()
            .Where(e => e.Entity is AuditableEntity &&
            (e.State == EntityState.Added ||
            e.State == EntityState.Modified));

            foreach (var entry in auditableEntity)
            {
                if (entry.State == EntityState.Added)
                {
                    ((AuditableEntity)entry.Entity).CreatedAt = DateTime.SpecifyKind(DateTimeOffset.UtcNow.DateTime, DateTimeKind.Utc);
                }
                else
                {
                    ((AuditableEntity)entry.Entity).UpdatedAt = DateTime.SpecifyKind(DateTimeOffset.UtcNow.DateTime, DateTimeKind.Utc);
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
