using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class SocialMediaContext : DbContext
    {
        public SocialMediaContext(DbContextOptions options) : base(options) { }
        public DbSet<Post> Posts { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is Auditable && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var item in entries)
            {
                ((Auditable)item.Entity).LastModified = DateTime.UtcNow;

                if(item.State == EntityState.Added)
                {
                    ((Auditable)item.Entity).Created = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }
    }
}
