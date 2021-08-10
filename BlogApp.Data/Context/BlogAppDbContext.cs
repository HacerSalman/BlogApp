using BlogApp.Data.Entities;
using BlogApp.Data.Enums;
using BlogApp.Data.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Context
{
    public class BlogAppDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public BlogAppDbContext(DbContextOptions<BlogAppDbContext> options) : base(options)
        {

        }

        public async Task<int> SaveChangesAsync()
        {
            string currentUsername = "anonymous";

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity.GetType().IsSubclassOf(typeof(BaseEntity)))
                {
                    if (entry.State == EntityState.Added)
                    {
                        ((BaseEntity)entry.Entity).CreateTime = DateTimeUtils.GetCurrentTicks();
                        ((BaseEntity)entry.Entity).Owner = currentUsername;
                    }
                    ((BaseEntity)entry.Entity).UpdateTime = DateTimeUtils.GetCurrentTicks();
                    ((BaseEntity)entry.Entity).Modifier = currentUsername;
                }

            }
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var statusConverter = EntityStatus.FluentInitAndSeed(modelBuilder);
            var userTypeConverter = UserType.FluentInitAndSeed(modelBuilder);
            var roleConverter = Role.FluentInitAndSeed(modelBuilder);

            User.FluentInitAndSeed(modelBuilder, statusConverter, userTypeConverter);
            Article.FluentInitAndSeed(modelBuilder, statusConverter);
            Category.FluentInitAndSeed(modelBuilder, statusConverter);
            Comment.FluentInitAndSeed(modelBuilder, statusConverter);
            UserRole.FluentInitAndSeed(modelBuilder, statusConverter, roleConverter);
        }
    }
}
