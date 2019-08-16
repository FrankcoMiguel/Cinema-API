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
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Director> Director { get; set; }
        
        


        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Relationship Film - Actor {Many to Many}
            builder.Entity<ActorFilm>().HasKey(af => new { af.ActorId, af.FilmId });

            builder
                .Entity<ActorFilm>()
                .HasOne(af => af.Actor)
                .WithMany(a => a.Films)
                .HasForeignKey(af => af.ActorId);

            builder
                .Entity<ActorFilm>()
                .HasOne(af => af.Film)
                .WithMany(a => a.Actors)
                .HasForeignKey(af => af.FilmId);


            // Relationship Director - Film {One to Many}
            builder
                .Entity<Director>()
                .HasMany(d => d.Films)
                .WithOne(f => f.Director)
                .HasForeignKey(f => f.DirectorId);



            // Relationship Staff - Employee {One to Many}
            builder
                .Entity<Staff>()
                .HasMany(s => s.Employees)
                .WithOne(e => e.Title)
                .HasForeignKey(e => e.StaffId);

            // Relationship Photo - Actor {One to One}
            builder
                .Entity<Photo>()
                .HasOne(p => p.Actor)
                .WithOne(a => a.Photo)
                .HasForeignKey<Actor>(a => a.PhotoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship Photo - Director {One to One}
            builder
                .Entity<Photo>()
                .HasOne(p => p.Director)
                .WithOne(d => d.Photo)
                .HasForeignKey<Director>(d => d.PhotoId);

            // Relationship Photo - Film {One to One}
            builder
                .Entity<Photo>()
                .HasOne(p => p.Film)
                .WithOne(f => f.Photo)
                .HasForeignKey<Film>(f => f.PhotoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship Photo - Employee {One to One}
            builder
                .Entity<Photo>()
                .HasOne(p => p.Employee)
                .WithOne(e => e.Photo)
                .HasForeignKey<Employee>(e => e.PhotoId);


            // Relationship Photo - Snack {One to One}
            builder
                .Entity<Photo>()
                .HasOne(p => p.Snack)
                .WithOne(s => s.Photo)
                .HasForeignKey<Snack>(s => s.PhotoId);


        }



    }
}
