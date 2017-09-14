using System;
using Microsoft.EntityFrameworkCore;

namespace VanillaPuddingAPI.DAL{
    public class Context: DbContext
    {
        public DbSet<Client> Clients {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseNpgsql(@"Host=localhost;Username=systemadmin;Password=jeremy;Database=VanillaPuddingDB");
        
    }
}

