using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resume.Models;

namespace Resume.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUsers>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        public DbSet<ResumeTemplate> ResumeTemplate {get;set;}
        public DbSet<Job> Jobs { get; set; }
        public DbSet<SubTitle> SubTitles { get; set; }
        public DbSet<VisitorCounter> VisitorCounter { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {   
            base.OnModelCreating(builder);

            // Creating Roles
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin", 
                    NormalizedName = "ADMIN" // NormalizedName basically means its capitalized
                },
                new IdentityRole
                {
                    Name = "User", 
                    NormalizedName = "USER" // NormalizedName basically means its capitalized
                },
            };

            // Add in the roles
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}