namespace ConnectPlus_Moura.DTO;

public class ContatoDTO
{
    
       public string? Nome { get; set; }
       public string? FormaContato { get; set; }
       public IFormFile? Imagens { get; set; }

       public Guid IdTipoContato { get; set; }
}
