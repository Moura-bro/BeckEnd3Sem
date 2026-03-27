using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class InstitucaoRepository : IInstitucaoRepository
{
    private readonly EventContext _context;
    public InstitucaoRepository(EventContext context)
    {
        _context = context;
    }

//---------------------------------Atualizar---------------------------------------------------------------


    /// <summary>
    /// Metodo que atualiza a instituicao
    /// </summary>
    /// <param name="id"> id que sera Puxado </param>
    /// <param name="instituicao">Instituicao que  sera Atualizada</param>
    public void Atualizar(Guid id, Instituicao instituicao)
    {
        var InstituicaoBuscado = _context.Instituicaos.Find(id);

        if(InstituicaoBuscado != null)
        {
            InstituicaoBuscado.NomeFantasia = instituicao.NomeFantasia;
            InstituicaoBuscado.Endereco = instituicao.Endereco;
            InstituicaoBuscado.Cnpj = instituicao.Cnpj;

            _context.SaveChanges();
        }
    }


//---------------------------------------BuscarPorId---------------------------------------------------------

    /// <summary>
    /// Medoto que Busca Id da instituicao
    /// </summary>
    /// <param name="id">Id da Instituicao que ser Buscada</param>
    /// <returns>Retorna Id </returns>
    public Instituicao BuscarPorId(Guid id)
    {
        return _context.Instituicaos.Find(id);
    }

//------------------------------------Cadastrar------------------------------------------------------------


    /// <summary>
    /// Medoto que cadastra a Instituicao
    /// </summary>
    /// <param name="instituicao"> Instituicao que sra Cadastrada</param>
    public void Cadastrar(Instituicao instituicao)
    {
        _context.Instituicaos.Add(instituicao);
        _context.SaveChanges();
    }

//------------------------------------Deletar------------------------------------------------------------


    /// <summary>
    /// Metodo que deleta a Instituicao Cadastrada
    /// </summary>
    /// <param name="id">id que sera deletado</param>
    public void Deletar(Guid id)
    {
        var InstituicaoBuscado = _context.Instituicaos.Find(id);

        if(InstituicaoBuscado != null)
        {
            _context.Instituicaos.Remove(InstituicaoBuscado);
            _context.SaveChanges();
        }
    }

//--------------------------------Listar----------------------------------------------------------------



    /// <summary>
    /// Metodo que lista a Instituicao
    /// </summary>
    /// <returns>Retorna a lista de Instituicao</returns>
    public List<Instituicao> Listar()
    {
        return _context.Instituicaos.OrderBy(Instituicaos => Instituicaos.NomeFantasia).ToList();
    }
}
