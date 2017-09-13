using System;
using System.ComponentModel.DataAnnotations;

namespace DotNet.Model.Entity
{
    public class Role
    {
        public Role()
        {
            AddDate=DateTime.Now;
        }
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int DepartmentId { get; set; }
    }
}