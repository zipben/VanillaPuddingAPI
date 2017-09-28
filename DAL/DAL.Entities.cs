using System;
using System.Collections.Generic;
using VanillaPuddingAPI.Enums;

namespace VanillaPuddingAPI.DAL
{
    public class Client
    {
        public int ClientId { get; set; }
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string PhoneNumber { get; set; }
        public List<Contact> Contacts { get; set; } 

    }

    public class Contact
    {
        public int ContactId { get; set; }
        public ContactType Type { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

    }
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public int OrderStatus { get; set; }
        public List<Unit> Units { get; set; }
    }
    public class Unit
    {
        public int UnitId { get; set; }
        public List<UnitSetting> Settings { get; set; }
    }

    public class UnitSetting
    {
        public int UnitSettingId { get; set; }
        public string StringValue { get; set; }
        public bool BoolValue { get; set; }
        public int IntValue { get; set; }
    }
}