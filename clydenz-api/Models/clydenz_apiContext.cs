using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;

namespace clydenz_api.Models
{
    public class clydenz_apiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public class MyConfiguration : DbMigrationsConfiguration<clydenz_apiContext>
        {
            public MyConfiguration()
            {
                this.AutomaticMigrationsEnabled = true;
            }
            protected override void Seed(clydenz_apiContext context)
            {
                var entries = new List<UrlMapping>
                {
                    new UrlMapping {  ShortUrl = "github", LongUrl = "https://github.com/ClydeDz"},
                    new UrlMapping { ShortUrl = "linkedin",   LongUrl = "https://nz.linkedin.com/in/clydedz"}
                };
                entries.ForEach(s => context.UrlMappings.AddOrUpdate(p => p.ShortUrl, s));
                context.SaveChanges();
            }
        }

        public clydenz_apiContext() : base("name=clydenz_apiContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<clydenz_apiContext, MyConfiguration>());
        }

        public System.Data.Entity.DbSet<clydenz_api.Models.UrlMapping> UrlMappings { get; set; }

        public System.Data.Entity.DbSet<clydenz_api.Models.UrlHits> UrlHits { get; set; }

        public System.Data.Entity.DbSet<clydenz_api.Models.Users> Users { get; set; }
    }
}
