using System.ComponentModel.DataAnnotations;

namespace DotNet.Model
{
    public class RefRoleMenuButton
    {
        [Key]
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int MenuId { get; set; }

        public int ButtonId { get; set; }
    }
}