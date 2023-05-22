using DataLayer.Interfaces;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace DataLayer.Context
{
    public class ShorterUrlDBContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=ShorterUrl.db");
            }
        }
        public DbSet<UrlMapping> urlMappings { get; set; }
    }
}
