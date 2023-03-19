using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibForBlog.BlogModels;
using LibForBlog.MovieModels;

namespace StarterApp.Data;

    public class SomeDbContext : DbContext
    {
        public SomeDbContext (DbContextOptions<SomeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie{ get; set; }= default!;

        public DbSet<HomeText> HomeText{ get; set; }= default!;
    }
