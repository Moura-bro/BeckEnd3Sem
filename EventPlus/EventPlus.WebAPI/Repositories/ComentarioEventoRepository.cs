using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class ComentarioEventoRepository : IComentarioEventoRepository
{
    private readonly EventContext _context;

    public ComentarioEventoRepository(EventContext context)
    {
        _context = context;
    }
    public ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario, Guid IdEvento)
    {
        throw new NotImplementedException();
    }

    public void Cadastrar(ComentarioEvento comentarioEvento)
    {
        _context.ComentarioEventos.Add(comentarioEvento);
        _context.SaveChanges();
    }

    public void Deletar(Guid idComentarioEvento)
    {
        var comentarioEventoBuscado = _context.ComentarioEventos.Find(idComentarioEvento);
        {
            if (comentarioEventoBuscado != null)
            {
                _context.ComentarioEventos.Remove(comentarioEventoBuscado);
                _context.SaveChanges();
            }
        }
    }

    public List<ComentarioEvento> Listar(Guid IdEvento)
    {
        return _context.ComentarioEventos.OrderBy(ComentarioEventos => ComentarioEventos.Descricao).ToList();
    }

    public List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento)
    {
        throw new NotImplementedException();
    }
}
