using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ComputerManage.Models
{
    public class WorkingGroup
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "组名字段是必须的")]
        [StringLength(50)]
        public string GroupName { get; set; }
        public string? Description { get; set; }

        public long? DepartmentId { get; set; }
        [JsonIgnore]
        public Department? Department { get; set; }
        [JsonIgnore]
        public ICollection<Computer> Computers { get; } = new List<Computer>();
    }
}
