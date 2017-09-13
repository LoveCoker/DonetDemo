using System;
using System.ComponentModel.DataAnnotations;

namespace DotNet.Model.Entity
{
    public class Menu
    {
        public Menu()
        {
            AddDate=DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public string Icon { get; set; }
        public int Sort { get; set; }
        public DateTime AddDate { get; set; }
        public string ControllerNameCode { get; set; }
        public string ActionNameCode { get; set; }
        public bool HaveChild { get; set; }

        public int MenuLevel { get; set; }
    }
}