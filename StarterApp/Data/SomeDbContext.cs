using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarterApp.Models;

namespace StarterApp.Data;

    public class SomeDbContext : DbContext
    {
        public SomeDbContext (DbContextOptions<SomeDbContext> options)
            : base(options)
        {
        }

        public DbSet<StarterApp.Models.Movie> Movie{ get; set; }= default!;

        public DbSet<StarterApp.Models.HomeText> HomeText{ get; set; }= default!;
    }
