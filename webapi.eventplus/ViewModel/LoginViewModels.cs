using System.ComponentModel.DataAnnotations;

namespace webapi.eventplus.ViewModel
{
    public class LoginViewModels
    {
        [Required(ErrorMessage = "Email obrigatorio")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatoria")]
        public string? Senha { get; set; }    
    }
}
