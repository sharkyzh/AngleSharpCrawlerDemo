using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using TswwAngleSharpWeb.Models;

namespace TswwAngleSharpWeb
{
    public class TswwDbContext : DbContext
    {
        public TswwDbContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<TswwDbContext>(null);
            //Database.SetInitializer(new CreateDatabaseIfNotExists<TswwDbContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<TswwDbContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TswwDbContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<MyDbContext>(null);
            base.OnModelCreating(modelBuilder);
            //推荐用法
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

        }


        public DbSet<Agent> Agents { get; set; }
        public DbSet<Tuan> Tuans { get; set; }
    }
}