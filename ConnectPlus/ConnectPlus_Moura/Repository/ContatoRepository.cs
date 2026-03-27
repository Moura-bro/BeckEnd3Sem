using ConnectPlus_Moura.BdContextConnect;
using ConnectPlus_Moura.Interface;
using ConnectPlus_Moura.Models;

namespace ConnectPlus_Moura.Repository;

public class ContatoRepository : IContatoRepository
{
    private readonly ConnectContext _context;
    public ContatoRepository(ConnectContext context)
    {
        _context = context;
    }


//----------------------------------Atualizar------------------
    public void Atualizar(Guid id, Contado contato)
    {
       var contatoExistente = _context.Contados.Find(id);
        if (contatoExistente == null)
        {
            contatoExistente.Nome = contato.Nome;
            contatoExistente.FormaContato = contato.FormaContato;
            contatoExistente.Imagens = contato.Imagens;
            _context.SaveChanges();
        }
    
    }


//----------------------------------BuscarPorId------------------
    public Contado BuscarPorId(Guid id)
    {
       return _context.Contados.Find(id)!;
    }

//----------------------------------Cadastrar------------------
    public void Cadastrar(Contado contato)
    {
        _context.Contados.Add(contato);
        _context.SaveChanges();
    }

//----------------------------------Deletar------------------
    public void Deletar(Guid id)
    {
        var contatoBuscado = _context.Contados.Find(id);

        if (contatoBuscado != null)
        {
            _context.Contados.Remove(contatoBuscado);
            _context.SaveChanges();
        }
    }

//------------------Listar------------------
    public List<Contado> Listar()
    {
        return _context.Contados.OrderBy(Contados => Contados.Nome).ToList();
    }
}
