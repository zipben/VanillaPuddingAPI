using System;
using Microsoft.EntityFrameworkCore;

namespace VanillaPuddingAPI.DAL{
    public class Context: DbContext
    {
        public DbSet<Client> Clients {get;set;}
        public DbSet<Contact> Contacts {get;set;}
        public DbSet<Order> Orders {get;set;}
        public DbSet<Unit> Units {get;set;}
        public DbSet<UnitSetting> UnitSettings {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseNpgsql(@"Host=localhost;Username=systemadmin;Password=jeremy;Database=VanillaPuddingDB");
        
    }
}

