using ComputerManage.Models.Authentication;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ComputerManage.Models
{
    [Index(nameof(HostName), IsUnique = true)]
    [Index(nameof(IpAddress), IsUnique = true)]
    [Index(nameof(SerialNumber), IsUnique = true)]
    public class Computer
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(256)]
        public string? HostName { get; set; }
        [MaxLength(256)]
        public string? IpAddress { get; set; }
        [Required]
        [MaxLength(256)]
        public string SerialNumber { get; set; }
        [MaxLength(256)]
        public string? QuickServiceCode { get; set; }
        [MaxLength(256)]
        public string? User { get; set; }
        public string? Remark { get; set; }

        public Department? Department { get; set; }
        public LoginModel? Administrator { get; set; }
        public WorkingGroup? Group { get; set; } 
    }
}
