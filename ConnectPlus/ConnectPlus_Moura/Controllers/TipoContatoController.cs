using ConnectPlus_Moura.DTO;
using ConnectPlus_Moura.Interface;
using ConnectPlus_Moura.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus_Moura.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoContatoController : ControllerBase
{
    private readonly ITipoContatoRepository _tipoContatoRepository;

    public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
    {
        _tipoContatoRepository = tipoContatoRepository;
    }


    //------------------Listar------------------


    /// <summary>
    /// Endpoit que lista os tipos de contato cadastrados
    /// </summary>
    /// <returns>Lista de Tipos de contato</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_tipoContatoRepository.Listar());
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    //------------------BuscarPorId------------------


    /// <summary>
    /// Busca um tipo de contato específico a partir do seu Id
    /// </summary>
    /// <param name="Id"> Id que busca contato especifico</param>
    /// <returns>Retorna Id do TipoContado buscado</returns>
    [HttpGet("{Id}")]
    public IActionResult BuscarPorId(Guid Id)
    {
        try
        {
            return Ok(_tipoContatoRepository.BuscarPorId(Id));
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }


    //------------------Cadastrar------------------

    /// <summary>
    /// Endpoint para cadastrar um novo tipo de contato, é necessário passar o título do tipo de contato a ser cadastrado
    /// </summary>
    /// <param name="tipoContato"> E o tipo do contato que sera cadstrado</param>
    /// <returns>Tipos de contato Cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(TipoContatoDTO tipoContato)
    {
        try
        {
            var novoTipoContato = new TipoContato
            {
                Titulo = tipoContato.Titulo!
            };

            _tipoContatoRepository.Cadastrar(novoTipoContato);
            return StatusCode(201);

        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }


    //------------------Atualizar------------------


    /// <summary>
    /// Atualiza um tipo de contato específico a partir do seu Id
    /// </summary>
    /// <param name="Id"> Id do Usuario que sera Atualizado</param>
    /// <param name="tipoContato">Tipo de contado que sera atualizado</param>
    /// <returns>Atualiza as informacoes</returns>
    [HttpPut("{Id}")]
    public IActionResult Atualizar(Guid Id, TipoContatoDTO tipoContato)
    {
        var tipoContatoBuscado = new TipoContato
        {
            Titulo = tipoContato.Titulo!
        };

        try
        {
            _tipoContatoRepository.Atualizar(Id, tipoContatoBuscado);
            return StatusCode(204, tipoContato);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }


    //------------------Deletar------------------
    /// <summary>
    /// Endpoint para deletar um tipo de contato específico a partir do seu Id,
    /// é necessário passar o Id do tipo de contato a ser deletado
    /// </summary>
    /// <param name="Id">Id que sera Deletado</param>
    /// <returns>Id Deletado</returns>
    [HttpDelete("{Id}")]
    public IActionResult Deletar(Guid Id)
    {
        try
        {
            _tipoContatoRepository.Deletar(Id);
            return NoContent();
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

}

