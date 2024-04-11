using System.ComponentModel.DataAnnotations;

namespace ComputerManage.Models.Authentication
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "用户名是必须的")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required(ErrorMessage = "密码是必须的")]
        [StringLength(50)]
        public string newPassword { get; set; }
    }
}
