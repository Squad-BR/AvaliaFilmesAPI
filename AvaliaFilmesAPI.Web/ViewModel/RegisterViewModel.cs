using System.ComponentModel.DataAnnotations;

namespace AvaliaFilmesAPI.Web.ViewModels
{
    public class RegisterViewModels
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmPassword { get; set; }
    }
}
