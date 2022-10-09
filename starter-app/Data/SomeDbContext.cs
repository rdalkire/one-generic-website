using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using starter_app.Models;

namespace starter_app.Data;

    public class SomeDbContext : DbContext
    {
        public SomeDbContext (DbContextOptions<SomeDbContext> options)
            : base(options)
        {
        }

        public DbSet<starter_app.Models.Movie> Movie{ get; set; }= default!;

        public DbSet<starter_app.Models.HomeText> HomeText{ get; set; }= default!;
    }
