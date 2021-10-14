using System.ComponentModel.DataAnnotations;

namespace EsTeam.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First name is a required field!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is a required field!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Login is a required field!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password is a required field!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
