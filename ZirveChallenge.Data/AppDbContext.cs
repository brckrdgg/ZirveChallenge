using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ZirveChallenge.Core.Entities;
using ZirveChallenge.Data.Configurations;

namespace ZirveChallenge.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieRating> MovieRatings { get; set; }

        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }

    }
}
