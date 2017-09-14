using System;
using Microsoft.EntityFrameworkCore;

namespace VanillaPuddingAPI.Models
{
    public class ErrorViewModel 
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}