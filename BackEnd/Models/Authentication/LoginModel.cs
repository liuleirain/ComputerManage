using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.MinimalApi;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerManage.Models.Authentication
{
    public class LoginModel : IdentityUser
    {
        [Required(ErrorMessage = "Username is requried")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [NotMapped]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        public ICollection<Computer> computers { get; set; } = new List<Computer>();
    }
}
