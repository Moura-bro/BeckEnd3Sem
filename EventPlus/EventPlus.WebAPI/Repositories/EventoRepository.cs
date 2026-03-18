using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly EventContext _context;

    public EventoRepository(EventContext context)
    {
        _context = context; 
    }

    


    public void Atualizar(Guid id, Evento evento)
    {
       var eventoBuscado = _context.Eventos.Find(id);
        if (eventoBuscado != null)
        {
            eventoBuscado.Nome = evento.Nome;
            eventoBuscado.Descricao = evento.Descricao;
            eventoBuscado.DataEvento = evento.DataEvento;
            _context.SaveChanges();
        }
    }

    public Evento BuscarPorId(Guid id)
    {
        return _context.Eventos.Find(id)!;
    }

    public void Cadastrar(Evento evento)
    {
       _context.Eventos.Add(evento);
        _context.SaveChanges();
    }

    public void Deletar(Guid id)
    {
       var eventoBuscado = _context.Eventos.Find(id);
        if (eventoBuscado != null)
        {
            _context.Eventos.Remove(eventoBuscado);
            _context.SaveChanges();
        }
    }

    public List<Evento> Listar()
    {
        return _context.Eventos.OrderBy(Eventos => Eventos.Nome).ToList();
    }







    /// <summary>
    /// Metodo que Lista Eventos Filtrdos pelo Id do Usuario
    /// </summary>
    /// <param name="IdUsuario">Id do Usuario para Flitragem</param>
    /// <returns>Lista de Eventos Flistrados pelo Usuario</returns>
    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .Where(e  => e.Presencas.Any(p => p.IdUsuario == IdUsuario && p.Situacao == true))
            .ToList()!;

    }








    /// <summary>
    /// Metodo que Busca os proximos Eventos que irao acontecer 
    /// </summary>
    /// <returns>Lista de Proximos Eventos</returns>
    public List<Evento> ListarProximos()
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .Where(e => e.DataEvento >= DateTime.Now)
            .OrderBy(e => e.DataEvento)
            .ToList()!;

    }
}
