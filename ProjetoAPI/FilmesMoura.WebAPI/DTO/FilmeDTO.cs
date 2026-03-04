namespace FilmesMoura.WebAPI.DTO;

public class FilmeDTO
{
    public string? Titulo { get; set; }

    public IFormFile? Imagem { get; set; }

    public Guid? Idgenero { get; set; }
}
