﻿using System.ComponentModel.DataAnnotations;

namespace DotNet.Model
{
    public class RefUserRole
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int RoleId { get; set; }
    }
}