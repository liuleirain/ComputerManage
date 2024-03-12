using System.ComponentModel.DataAnnotations;

namespace ComputerManage.Models.Authentication
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Username is requried")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required(ErrorMessage = "New password is requried")]
        [StringLength(50)]
        public string newPassword { get; set; }
    }
}
