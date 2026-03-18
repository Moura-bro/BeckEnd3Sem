using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class PresencaRepository : IPresencaRepository
{
    private readonly EventContext _context;

    public PresencaRepository(EventContext context)
    {
        _context = context;
    }
//-------------------Atualizar-------------------------------------------------------------------

    /// <summary>
    /// Metodo Que alterna a situacao da Presenca 
    /// </summary>
    /// <param name="id">Id da Presenca a ser alterado</param>
    /// <param name="presenca"></param>
    public void Atualizar(Guid id, Presenca presenca)
    {
        var presencaBuscada = _context.Presencas.Find(id);
        if (presencaBuscada != null)
        {
            presencaBuscada.Situacao = !presencaBuscada.Situacao;

            _context.SaveChanges();
        }
    }

//---------------------------BuscarPorId---------------------------------------------------------


/// <summary>
/// Metodo que Busca uma Presenca por id 
/// </summary>
/// <param name="id">Id da presenca a ser buscada </param>
/// <returns>presenca buscada </returns>
    public Presenca BuscarPorId(Guid id)
    {
       return _context.Presencas.Include(p => p.IdEventoNavigation)
            .ThenInclude(e => e!.IdInstituicaoNavigation)
            .FirstOrDefault(p => p.IdPresenca == id)!;
    }

 //---------------------------------Deletar-------------------------------------------------------------

    /// <summary>
    /// Metodo que deleta Presenca Buscada
    /// </summary>
    /// <param name="id">Id da Presenca </param>
    public void Deletar(Guid id)
    {
        var presencaBuscada = _context.Presencas.Find(id);
        if(presencaBuscada != null)
        {
            _context.Presencas.Remove(presencaBuscada);
            _context.SaveChanges();
        }
    }

//------------------------------Inscrever----------------------------------------------------------------

    /// <summary>
    /// Metodo que inscreve uma Presenca
    /// </summary>
    /// <param name="presenca">Presenca que sera Inscrita</param>
    public void Inscrever(Presenca presenca)
    {
       _context.Presencas.Add(presenca);
       _context.SaveChanges();
    }

    public List<Presenca> Listar()
    {
        return _context.Presencas.OrderBy(presenca => presenca.Situacao).ToList()!;
    }



 //--------------------------Listar--------------------------------------------------------------------

    /// <summary>
    /// Metodo que lista as presencas de um usuario especifico
    /// </summary>
    /// <param name="IdUsuario">id do usuario para a filtragem</param>
    /// <returns>Lista de presecas de um usuario</returns>
    public List<Presenca> ListarMinhas(Guid IdUsuario)
    {
        return _context.Presencas
            .Include(p => p.IdEventoNavigation)
            .ThenInclude(e => e!.IdInstituicaoNavigation)
            .Where(p => p.IdUsuario == IdUsuario).ToList();
    }
}
