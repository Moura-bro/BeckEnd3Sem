using System.ComponentModel.DataAnnotations;

namespace FilmesMoura.WebAPI.DTO;

public class LoginDTO
{
    [Required(ErrorMessage = "O campo Email do Usuario é obrigatório.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "O campo Senha do Usuario é obrigatório.")]
    public string? Senha { get; set; }
}
