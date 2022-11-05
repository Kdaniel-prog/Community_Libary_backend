using Community_Libary.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Community_Libary.DAL.DATA
{
    public class Community_LibaryDbContext : DbContext
    {    
        public DbSet<Books> Books { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Borrowed> Borrowed { get; set; }
        public DbSet<BookReviews> BookReviews { get; set; }
        public DbSet<UserReviews> UserReviews { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public Community_LibaryDbContext(DbContextOptions<Community_LibaryDbContext> options) : base(options)
        {

        }
    }
}
