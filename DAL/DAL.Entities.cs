using System;

namespace VanillaPuddingAPI.DAL
{
    public class Client
    {
        public int ClientId { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string PhoneNumber { get; set; }
    }
}