using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

    public class SomeDbContext : DbContext
    {
        public SomeDbContext (DbContextOptions<SomeDbContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Movie> Movie{ get; set; }= default!;

        public DbSet<MvcMovie.Models.HomeText> HomeText{ get; set; }= default!;
    }
