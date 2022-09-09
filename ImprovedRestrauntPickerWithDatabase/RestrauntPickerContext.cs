using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ImprovedRestrauntPickerWithDatabase.Models;

namespace ImprovedRestrauntPickerWithDatabase
{
    public class RestrauntPickerContext : DbContext 
    {
        public DbSet<Restraunt> Restraunts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PastPick> PastPicks { get; set; }

        public RestrauntPickerContext() { }
        public RestrauntPickerContext(DbContextOptions<RestrauntPickerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = @"server=localhost\sqlexpress;" + "database=RestrauntPicker;" + "trusted_connection=true;";
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) { }


    }
}
