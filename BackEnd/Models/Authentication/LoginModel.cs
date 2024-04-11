using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.MinimalApi;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerManage.Models.Authentication
{
    public class LoginModel : IdentityUser
    {
        [Required(ErrorMessage = "用户名是必须的")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "密码是必须的")]
        [NotMapped]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        public ICollection<Computer> Computers { get; set; } = new List<Computer>();
    }
}
