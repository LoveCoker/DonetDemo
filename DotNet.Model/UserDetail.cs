using System;
using System.ComponentModel.DataAnnotations;
using DotNet.Model.Entity;

namespace DotNet.Model
{
    public class UserDetail
    {
        public int UserAccountId { get; set; }
        public string NickName { get; set; }
        public string PhotoPath { get; set; }
        public bool Gender { get; set; }
        public DateTime Birth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        
    }
}