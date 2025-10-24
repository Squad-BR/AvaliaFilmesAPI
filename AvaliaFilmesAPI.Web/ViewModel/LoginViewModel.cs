using System.ComponentModel.DataAnnotations;

namespace AvaliaFilmesAPI.Web.ViewModels
{
    public class LoginViewModels
    {
        [Required(ErrorMessage = "O nome usuário é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Password { get; set; }
    }
}
