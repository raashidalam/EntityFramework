using StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace StackOverFlow.DAL
{
    public class StackContext:DbContext
    {
        public StackContext():base("StackContext")
        {
             //  Database.SetInitializer<StackContext>(new DropCreateDatabaseIfModelChanges<StackContext>());
            // Database.SetInitializer<StackContext>(new DropCreateDatabaseIfModelChanges<StackContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StackContext, StackOverFlow.Migrations.Configuration>());
        }
        public DbSet<UsersTable> userTables { get; set; }
        public DbSet<Questions> question { get; set; }
       public DbSet<Tag> tag { get; set; }
       public DbSet<Answer> answer{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}