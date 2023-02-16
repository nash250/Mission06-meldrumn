using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_meldrumn.Models
{
    public class MovieAppContext : DbContext
    {
        //Constructor
        public MovieAppContext (DbContextOptions<MovieAppContext> options) : base (options)
        {
            // leave blank for now
        }

        public DbSet<ApplicationResponse> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<ApplicationResponse>().HasData(

                new ApplicationResponse
                {
                    MovieID = 1,
                    Category = "Action/Adventure",
                    Title = "The Avengers",
                    Year = 2012,
                    Director = "Joss Whedon",
                    Rating = "PG-13",
                    Edited = "No",
                    LentTo = "",
                    Notes = "A Certified Classic"
                },
                new ApplicationResponse
                {
                    MovieID = 2,
                    Category = "Action/Adventure",
                    Title = "Tenet",
                    Year = 2020,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = "",
                    LentTo = "",
                    Notes = "Top Tier"
                },
                new ApplicationResponse
                {
                    MovieID = 3,
                    Category = "Action/Adventure",
                    Title = "Spider-Man: Into the Spider-Verse",
                    Year = 2018,
                    Director = "Peter Ramsey, Bob Persichetti, Rodney Rothman",
                    Rating = "PG",
                    Edited = "No",
                    LentTo = "",
                    Notes = "Best Movie of All Time"
                }
            );
        }
    }
}
