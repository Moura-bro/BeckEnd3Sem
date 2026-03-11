using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class TipoUsuarioDTO
{
    [Required(ErrorMessage = "O TipoUsuario e obrigatorio!")]
    public string? Titulo { get; set; }
}
