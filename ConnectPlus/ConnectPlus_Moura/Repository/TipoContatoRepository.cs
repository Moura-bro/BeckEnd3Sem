using ConnectPlus_Moura.BdContextConnect;
using ConnectPlus_Moura.Interface;
using ConnectPlus_Moura.Models;

namespace ConnectPlus_Moura.Repository;

public class TipoContatoRepository : ITipoContatoRepository
{
    private readonly ConnectContext _context;

    public TipoContatoRepository(ConnectContext context)
    {
        _context = context;
    }



//-----------------------------------Cadastrar---------------------------------------
    public void Cadastrar(TipoContato tipoContato)
    {
        _context.TipoContatos.Add(tipoContato);
        _context.SaveChanges();
    }

//----------------------------------Atualizar----------------------------------------

    public void Atualizar(Guid id, TipoContato tipoContato)
    {
        var tipoContatoExistente = _context.TipoContatos.Find(id);

        if(tipoContatoExistente != null)
        {
            tipoContatoExistente.Titulo = tipoContato.Titulo;

            _context.SaveChanges();
        }

       
    }


//----------------------------------BuscarPorId---------------------------------------

    public TipoContato BuscarPorId(Guid id)
    {
        return _context.TipoContatos.Find(id)!;
    }


//----------------------------------Deletar---------------------------------------
    public void Deletar(Guid id)
    {
        var tipoContatoBuscado = _context.TipoContatos.Find(id);

        if (tipoContatoBuscado != null)
        {
            _context.TipoContatos.Remove(tipoContatoBuscado);
            _context.SaveChanges();
        }
    }

//----------------------------------Listar---------------------------------------
    public List<TipoContato> Listar()
    {
        return _context.TipoContatos.OrderBy(TipoContatos => TipoContatos.Titulo).ToList();
    }
}
