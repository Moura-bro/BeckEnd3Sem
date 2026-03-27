using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositoriesp;

public class TipoEventoRepository : ITipoEventoRepository

{
    private readonly EventContext _context;
    // Injecao de dependencia : Recebe contexto pelo construtor
    public TipoEventoRepository(EventContext context)
    {
        _context = context;
    }



//---------------------------Atualizar----------------------------------------------------------
    /// <summary>
    /// Atualiza um tipo de evento usando o rastreamento automatiaco
    /// </summary>
    /// <param name="id">id do tipo evento a ser atualizado</param>
    /// <param name="tipoEvento">Novos dados do tipo evento</param>
    public void Atualizar(Guid id, TipoEvento tipoEvento)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);

        if (tipoEventoBuscado != null)
        {
            tipoEventoBuscado.Titulo = tipoEvento.Titulo;
           
            //O SaveChanges() detecta a mudanca na propiedade "Titulo" Automaticamente
            _context.SaveChanges();
        }
    }


//-------------------------------BuscarPorId------------------------------------------------------
    /// <summary>
    /// Busca um tipo de Evento por Id
    /// </summary>
    /// <param name="id">id do tipo evento a ser buscado </param>
    /// <returns>Objeto do tipo evento com as informacoes do tipo evento buscado</returns>
    public TipoEvento BuscarPorId(Guid id)
    {
       return _context.TipoEventos.Find(id);
    }


//---------------------------------cadastrar----------------------------------------------------

    /// <summary>
    /// Cadastra um novo tipo de evento
    /// </summary>
    /// <param name="tipoEvento">O tipo de evento a ser cadastrado</param>
    public void cadastrar(TipoEvento tipoEvento)
    {
        _context.TipoEventos.Add(tipoEvento);
        _context.SaveChanges();
    }

//-----------------------------------Deletar--------------------------------------------------


    /// <summary>
    /// Deleta um tipo de evento
    /// </summary>
    /// <param name="id">id do tipo evento a ser deletado</param>
    public void Deletar(Guid id)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);

        if(tipoEventoBuscado != null)
        {
            _context.TipoEventos.Remove(tipoEventoBuscado);
            _context.SaveChanges();
        }
    }


    //--------------------------------Listar-----------------------------------------------------

    /// <summary>
    /// Busca a lista de eventos cadastrados 
    /// </summary>
    /// <returns>Uma lista do tipo evento</returns>
    public List<TipoEvento> Listar()
    {
        return _context.TipoEventos.OrderBy(TipoEvento => TipoEvento.Titulo).ToList();
    }
}
