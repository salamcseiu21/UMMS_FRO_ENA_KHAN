namespace UniversityManagementSystem.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityManagementSystem.DatabaseContext.DatabaseContexts.ProjectDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "UniversityManagementSystem.DatabaseContext.DatabaseContexts.ProjectDbContext";
        }

        protected override void Seed(UniversityManagementSystem.DatabaseContext.DatabaseContexts.ProjectDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
