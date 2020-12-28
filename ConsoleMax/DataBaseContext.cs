using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMax
{
    class DataBaseContext : DbContext
    {
        public DbSet<Task> AllTasks { get; set; }

        public DataBaseContext ()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
            $"Host=localhost;Port=5432;Database=VozmiteMenyaPozhozda_SolarTaskDataBase;Username=postgres;Password=wwe12cmpunk;SSL Mode=Prefer;Trust Server Certificate=true");
        }
    }
}
