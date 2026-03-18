namespace EventPlus.WebAPI.DTO;

public class PresencaDTO
{
    public Guid IdEvento { get; set; }
    public Guid IdUsuario { get; set; }

    public bool Situacao { get; set; }
}
