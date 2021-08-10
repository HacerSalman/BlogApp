using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Context
{
    public class BlogAppDbContextFactory : IDesignTimeDbContextFactory<BlogAppDbContext>
    {
        public BlogAppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlogAppDbContext>();
            var connString = Environment.GetEnvironmentVariable("BLOG_APP_DB_CONNECTION");
            ServerVersion sv = MySqlServerVersion.AutoDetect(connString);           
            optionsBuilder.UseMySql(connString,sv);
            optionsBuilder.EnableSensitiveDataLogging();

            return new BlogAppDbContext(optionsBuilder.Options);
        }
    }
}
