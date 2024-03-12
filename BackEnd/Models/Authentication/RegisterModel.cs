using System.ComponentModel.DataAnnotations;

namespace ComputerManage.Models.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Username is required")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is requried")]
        [StringLength(50, MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
    }
}
