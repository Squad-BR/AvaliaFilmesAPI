using System.ComponentModel.DataAnnotations;

namespace AvaliaFilmesAPI.Web.ViewModel
{
    namespace AvaliaFilmesAPI.Web.ViewModels
    {
        public class UpdateViewModel
        {
            [Required(ErrorMessage = "O nome de usuário é obrigatório")]
            public string Username { get; set; }

            [Required(ErrorMessage = "O e-mail é obrigatório")]
            [EmailAddress(ErrorMessage = "O formato do e-mail é inválido")]
            public string Email { get; set; }
            [Required(ErrorMessage = "A senha atual é obrigatória")]
            [DataType(DataType.Password)]
            public string CurrentPassword { get; set; }

            [Required(ErrorMessage = "A nova senha é obrigatória")]
            [DataType(DataType.Password)]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Compare("NewPassword", ErrorMessage = "A nova senha e a confirmação não coincidem.")]
            public string ConfirmNewPassword { get; set; }



        }
    }

}
