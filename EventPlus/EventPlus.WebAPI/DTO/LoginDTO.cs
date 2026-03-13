using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O Email do usuario e Obrigatorio!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O Senha do usuario e Obrigatorio!")]
        public string? Senha { get; set; }
    }
}
