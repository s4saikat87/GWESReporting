using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace GwesReportApi.Models
{
    public class GwesDbContext:DbContext
    {
        public GwesDbContext()
        {
        }

        public GwesDbContext(DbContextOptions<GwesDbContext> options) : base(options) { }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>().HasNoKey();
            modelBuilder.Entity<DocModel>().HasNoKey();
        }

        public DbSet<UserModel> DbUsers { get; set; }
        public DbSet<DocModel> DbDocs { get; set; }
    }
}
