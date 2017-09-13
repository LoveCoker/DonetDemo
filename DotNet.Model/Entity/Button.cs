using System;
using System.ComponentModel.DataAnnotations;

namespace DotNet.Model.Entity
{
    public class Button
    {
        public Button()
        {
            AddDate=DateTime.Now;
        }
        public int Id { get; set; }
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Sort { get; set; }
        public DateTime AddDate { get; set; }
        public string Description { get; set; }
        public string HttpMethod { get; set; }
        public string ActionNameCode { get; set; }
    }
}