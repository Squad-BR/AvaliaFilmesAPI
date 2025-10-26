namespace AvaliaFilmesAPI.Web.ViewModel
{
    namespace AvaliaFilmesAPI.Web.ViewModels
    {
        public class UpdateViewModel
        {
            public string Id { get; set; }           // Id do usuário logado
            public string Username { get; set; }     // Novo nome de usuário
            public string Email { get; set; }        // Novo e-mail
            public string CurrentPassword { get; set; } // Senha atual
            public string? NewPassword { get; set; } // Nova senha (opcional)
        }
    }

}
