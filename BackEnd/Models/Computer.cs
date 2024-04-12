using AutoMapper.Configuration.Annotations;
using ComputerManage.Models.Authentication;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ComputerManage.Models
{
    [Index(nameof(SerialNumber), IsUnique = true)]
    [Index(nameof(HostName), IsUnique = true)]
    [Index(nameof(IpAddress), IsUnique = true)]
    public class Computer
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(256)]
        public string? HostName { get; set; }
        [MaxLength(256)]
        public string? IpAddress { get; set; }
        [Required(ErrorMessage = "序列号字段是必须的")]
        [MaxLength(256)]
        public string SerialNumber { get; set; }
        [MaxLength(256)]
        public string? QuickServiceCode { get; set; }
        [MaxLength(256)]
        public string? User { get; set; }
        public string? Remark { get; set; }

        public long? DepartmentId { get; set; }
        [JsonIgnore]
        public Department? Department { get; set; }
        public string? AdministratorId { get; set; }
        [JsonIgnore]
        public LoginModel? Administrator { get; set; }
        public long? GroupId { get; set; }
        [JsonIgnore]
        public WorkingGroup? Group { get; set; } 
    }
}
