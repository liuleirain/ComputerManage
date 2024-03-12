using System.ComponentModel.DataAnnotations;

namespace ComputerManage.Models
{
    public class Department
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }
        public string? Description { get; set; }

        public ICollection<Computer> Computers { get; } = new List<Computer>();
    }
}
