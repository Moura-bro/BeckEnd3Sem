using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositoriesp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresencaController : ControllerBase
{
    private IPresencaRepository _presencaRepository;

    public PresencaController(IPresencaRepository presencaRepository)
    {
        _presencaRepository = presencaRepository;
    }

    //-----------------------------------BuscarMinhas---------------------------------------------

    /// <summary>
    /// Endpoit da API que Lista as presenças de um usuario especifico
    /// </summary>
    /// <param name="idUsuario">id do usuario para filtragem</param>
    /// <returns>Status code 200 e uma lista de presenca </returns>
    [HttpGet("ListarMinhas/{idUsuario}")]
    public IActionResult BuscarMinhas(Guid idUsuario)
        {
        try
        {
            return Ok(_presencaRepository.ListarMinhas(idUsuario));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    //-----------------------------------Listar e BucarPorId----------------------------------------------------




    /// <summary>
    /// Enspoit que Lista todas as presenças cadastradas no sistema, sem filtro de usuario
    /// </summary>
    /// <returns>Status code 200 e a lista de Presenca de Usuario</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_presencaRepository.Listar());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //---------------------------------------BuscarPorId------------------------------------------------


    /// <summary>
    /// Endpoit da API para buscar uma presença especifica por id, sem filtro de usuario
    /// </summary>
    /// <param name="id"> id que busca Presenca especifica </param>
    /// <returns> status code 200 e a Presenca do Usuario buscado  </returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_presencaRepository.BuscarPorId(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    //--------------------------------Inscrever------------------------------------------------

    /// <summary>
    /// Endpoit da API para inscrever um usuario 
    /// </summary>
    /// <param name="presenca"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Inscrever(PresencaDTO presenca)
    {
        try
        {
            var novaPresenca = new Presenca
            {
                Situacao = presenca.Situacao,
                IdEvento = presenca.IdEvento,
                IdUsuario = presenca.IdUsuario
            };

            _presencaRepository.Inscrever(novaPresenca);
            return StatusCode(201, novaPresenca);
        }
        catch (Exception e)
        {

            return BadRequest();
        }
    }

    //---------------------------------Atualizar------------------------------------------------------


    /// <summary>
    /// Endpoit da API para atualizar a presença de um usuario, sem filtro de usuario
    /// </summary>
    /// <param name="id"> </param>
    /// <param name="presenca"></param>
    /// <returns>Status code 204 e Presenca atualizada </returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, PresencaDTO presenca)
    {
        try
        {
            var PresencaAtualizada = new Presenca
            {
                Situacao = presenca.Situacao,
                IdEvento = presenca.IdEvento,
                IdUsuario = presenca.IdUsuario
            };

            _presencaRepository.Atualizar(id, PresencaAtualizada);
            return StatusCode(204, PresencaAtualizada);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
     }

//-------------------------------Deletar-------------------------------------------------------------


    /// <summary>
    /// Endpoit da API para deletar a presença de um usuario
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Status code 204 e Presenca deletada </returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _presencaRepository.Deletar(id);
            return StatusCode(204);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
