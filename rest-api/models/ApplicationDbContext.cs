using System;
using Microsoft.EntityFrameworkCore;

namespace rest_api.models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        public DbSet<Hilary> Hilaries {get; set;}


      
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {

        }
    }
}
