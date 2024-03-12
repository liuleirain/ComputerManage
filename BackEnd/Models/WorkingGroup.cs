using System.ComponentModel.DataAnnotations;

namespace ComputerManage.Models
{
    public class WorkingGroup
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string GroupName { get; set; }
        public string? Description { get; set; }
        public ICollection<Computer> Computers { get; } = new List<Computer>();
    }
}
