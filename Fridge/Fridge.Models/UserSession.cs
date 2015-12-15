﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Fridge.Models
{
    public class UserSession
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string AccessToken { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }
    }
}