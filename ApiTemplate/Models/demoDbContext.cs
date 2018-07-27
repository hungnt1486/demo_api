using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTemplate.Models
{
    public class demoDbContext:DbContext
    {
        public demoDbContext(DbContextOptions<demoDbContext> options)
           : base(options)
        {
        }

        public  DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mapping model voi table trong database
            modelBuilder.Entity<Users>().ToTable("Users");
        }
    }
}
