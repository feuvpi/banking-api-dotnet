﻿
namespace Domain.Entity
{
    internal class User : BaseEntity
    {
        public string Name { get; set;}
        public string Email { get; set; } 
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}