namespace TutorGuide.Migrations
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TutorGuide.Repository.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TutorGuide.Repository.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("iit123");
            context.Users.AddOrUpdate(
              p => p.PhoneNumber,
              new ApplicationUser
              {
                  UserName = "01760567260",
                  PasswordHash = password,
                  PhoneNumber = "01760567260",
                  PhoneNumberConfirmed = true,
                  SecurityStamp = Guid.NewGuid().ToString()
              },
              new ApplicationUser
              {
                  UserName = "01760567261",
                  PasswordHash = password,
                  PhoneNumber = "01760567261",
                  PhoneNumberConfirmed = true,
                  SecurityStamp = Guid.NewGuid().ToString()

              },
              new ApplicationUser
              {
                  UserName = "01760567262",
                  PasswordHash = password,
                  PhoneNumber = "01760567262",
                  PhoneNumberConfirmed = true,
                  SecurityStamp = Guid.NewGuid().ToString()

              },
              new ApplicationUser
              {
                  UserName = "01760567263",
                  PasswordHash = password,
                  PhoneNumber = "01760567263",
                  PhoneNumberConfirmed = true,
                  SecurityStamp = Guid.NewGuid().ToString()

              },
              new ApplicationUser
              {
                  UserName = "01760567264",
                  PasswordHash = password,
                  PhoneNumber = "01760567264",
                  PhoneNumberConfirmed = true,
                  SecurityStamp = Guid.NewGuid().ToString()

              },
              new ApplicationUser
              {
                  UserName = "01760567265",
                  PasswordHash = password,
                  PhoneNumber = "01760567265",
                  PhoneNumberConfirmed = true,
                  SecurityStamp = Guid.NewGuid().ToString()

              }
            );
            //
        }
    }
}
