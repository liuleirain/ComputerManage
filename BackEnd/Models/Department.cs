using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ComputerManage.Models
{
    [Index(nameof(DepartmentName), IsUnique = true)]
    public class Department
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "部门名字段是必须的")]
        [StringLength(100)]
        public string DepartmentName { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<Computer> Computers { get; } = new List<Computer>();
        [JsonIgnore]
        public ICollection<WorkingGroup> WorkGroups { get; } = new List<WorkingGroup>();
    }
}
