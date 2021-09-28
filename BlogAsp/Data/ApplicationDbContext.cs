using System;
using System.Collections.Generic;
using System.Text;
using BlogAsp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogAsp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
         public DbSet<User> Users { get; set; }
         
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
    }
}