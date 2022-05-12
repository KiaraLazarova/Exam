using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ApplicationDBContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<User> Users { get; set; }

        public DbSet<Interest> Interests  { get; set; }

        public DbSet<Area> Areas { get; set; }

        public ApplicationDBContext(string connectionString = "")
        {
            _connectionString = connectionString;
        }

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connectionString))
                optionsBuilder.UseMySQL("Server=127.0.0.1;Port=3306;Database=user_interests_database;Uid=root;Pwd=74d357k;");
        }

    }
}