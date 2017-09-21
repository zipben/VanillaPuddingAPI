using System;
using Microsoft.EntityFrameworkCore;
using VanillaPuddingAPI.DAL;

namespace VanillaPuddingAPI.Models
{
    public class BuildClientModel 
    {
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}