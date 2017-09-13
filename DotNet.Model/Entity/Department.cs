using System;
using System.ComponentModel.DataAnnotations;

namespace DotNet.Model.Entity
{
    public class Department
    {
        public Department()
        {
            AddDate=DateTime.Now;
        }
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public int ParentId { get; set; }
        public int Sort { get; set; }
        public DateTime AddDate { get; set; }
        public bool HaveChild { get; set; }
        public int DepartmentLevel { get; set; }
    }
}