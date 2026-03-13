using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class InstituicaoDTO
{
    [Required(ErrorMessage = "O TipoInstituicao e obrigatorio!")]
    public string? Cnpj { get; set; }

    [Required(ErrorMessage = "O Endereco e obrigatorio!")]

    public string? Endereco { get; set; }

    [Required(ErrorMessage = "O NomeFantasia e obrigatorio!")]

    public string? NomeFantasia { get; set; }


}
