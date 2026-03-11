using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class InstituicaoDTO
{
    [Required(ErrorMessage = "O TipoInstituicao e obrigatorio!")]
    public string? Cnpj { get; set; }
}
