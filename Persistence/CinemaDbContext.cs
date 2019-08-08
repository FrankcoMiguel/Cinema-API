using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class CinemaDbContext : DbContext
    {

        public DbSet<Film> Film { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Snack> Snack { get; set; }


        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          

        }


    }
}
