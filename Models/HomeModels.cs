using System;
using Microsoft.EntityFrameworkCore;

namespace VanillaPuddingAPI.Models
{
    public class IndexModel 
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}