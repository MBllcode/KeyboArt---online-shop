using System.ComponentModel.DataAnnotations;

namespace KeyboArt.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Adres email")]
        [Required(ErrorMessage = "Adres email jest wymagany")]
        public string EmailAdress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}
