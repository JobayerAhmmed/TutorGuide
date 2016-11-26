using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using TutorGuide.Models;

namespace TutorGuide.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<StudentProfile> StudentProfiles { get; set; }
        public DbSet<TutorProfile> TutorProfiles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<ClassVersion> Versions { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Year> Years { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}