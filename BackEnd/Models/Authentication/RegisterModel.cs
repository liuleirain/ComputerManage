using System.ComponentModel.DataAnnotations;

namespace ComputerManage.Models.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="用户名是必须的")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required(ErrorMessage = "密码是必须的")]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
        [Required(ErrorMessage = "确认密码是必须的")]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
    }
}
