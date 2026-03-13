using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class UsuarioDTO
{
    [Required(ErrorMessage = "O nome do usuario e Obrigatorio!")]
    public string? Nome { get; set; } 

    [Required(ErrorMessage = "O Email do usuario e Obrigatorio!")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A Senha do usuario e Obrigatorio!")]
    public string? Senha { get; set; }

    public Guid IdTipoUsuario { get; set; }
}
