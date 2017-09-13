using System.ComponentModel.DataAnnotations;

namespace DotNet.Model
{
    public class RefUserDepartment
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int DepartmentId { get; set; }
    }
}