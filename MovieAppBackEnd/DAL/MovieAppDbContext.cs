using Microsoft.EntityFrameworkCore;
using MovieAppBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppBackEnd.DAL
{
   
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options) : base(options)
        {


        }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieList> MovieLists { get; set; }

        public DbSet<Favorite> favorites { get; set; }


    }
}
