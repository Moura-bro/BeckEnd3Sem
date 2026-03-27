using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class ComentarioEventoRepository : IComentarioEventoRepository
{
    private readonly EventContext _context;

    public ComentarioEventoRepository(EventContext context)
    {
        _context = context;
    }




    //---------------------------------BuscarPorIdUsuario----------------------------------------


    /// <summary>
    /// Metodo para buscar um comentário de evento por Id do usuário
    /// </summary>
    /// <param name="IdUsuario">Id do Usuario Buscado</param>
    /// <param name="IdEvento">Id do Evento</param>
    /// <returns>Retorna Usuario Buscado></returns>
    public ComentarioEvento BuscarPorIdUsuario(Guid IdUsuario)
    {
        return _context.ComentarioEventos
            .FirstOrDefault(c => c.IdUsuario == IdUsuario)!;
    }



    //-----------------------Cadastrar--------------------------------------------------


    /// <summary>
    /// Cadastra um novo comentário de evento
    /// </summary>
    /// <param name="comentarioEvento"></param>
    public void Cadastrar(ComentarioEvento comentarioEvento)
    {
        _context.ComentarioEventos.Add(comentarioEvento);
        _context.SaveChanges();
    }


//---------------------Deletar----------------------------------------------------


    /// <summary>
    /// Deleta um Comentario
    /// </summary>
    /// <param name="idComentarioEvento"></param>
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



//----------------------------Listar---------------------------------------------


    /// <summary>
    /// Lista de Comentarios
    /// </summary>
    /// <returns>Retorna Lista de Comentarios do Evento</returns>
    public List<ComentarioEvento> Listar()
    {
        return _context.ComentarioEventos.OrderBy(ComentarioEventos => ComentarioEventos.Descricao).ToList();
    }


//----------------------------ListarSomenteExibe---------------------------------------------


    /// <summary>
    /// Lista de Comentarios que somente Exibe 
    /// </summary>
    /// <param name="IdEvento">Id do Evento</param>
    /// <returns>Retorna Somente A lista dl evento Exibido</returns>
    public List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento)
    {
        return _context.ComentarioEventos
            .Where(c => c.IdEvento == IdEvento && c.Exibe).ToList();
    }


//-------------------------------------------------------------------------

    
}
