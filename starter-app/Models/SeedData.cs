using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SomeDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SomeDbContext>>()))
            {
                bool isSeeding = false;
                
                if (!context.Movie.Any())
                {
                    context.Movie.AddRange(
                        new Movie
                        {
                            Title = "When Harry Met Sally",
                            ReleaseDate = DateTime.Parse("1989-2-12"),
                            Genre = "Romantic Comedy",
                            Rating = "R",
                            Price = 7.99M
                        },

                        new Movie
                        {
                            Title = "Ghostbusters ",
                            ReleaseDate = DateTime.Parse("1984-3-13"),
                            Genre = "Comedy",
                            Rating = "PG-13",
                            Price = 8.99M
                        },

                        new Movie
                        {
                            Title = "Ghostbusters 2",
                            ReleaseDate = DateTime.Parse("1986-2-23"),
                            Genre = "Comedy",
                            Rating = "PG-13",
                            Price = 9.99M
                        },

                        new Movie
                        {
                            Title = "Rio Bravo",
                            ReleaseDate = DateTime.Parse("1959-4-15"),
                            Genre = "Western",
                            Rating = "PG",
                            Price = 3.99M
                        }
                    );
                    isSeeding = true;
                }
                
                if(!context.HomeText.Any())
                {
                    context.HomeText.AddRange(
                        new HomeText{
                            Name = HomeTextNames.SiteName,
                            Value = "(site name)"
                        },
                        new HomeText{
                            Name = HomeTextNames.IndexBody,
                            Value = "(home index body)"
                        },
                        new HomeText{
                            Name = HomeTextNames.PrivacyBody,
                            Value = "(privacy policy text)"
                        }
                    );
                    isSeeding = true;
                }

                if(isSeeding) context.SaveChanges();
            }
        }
    }
}