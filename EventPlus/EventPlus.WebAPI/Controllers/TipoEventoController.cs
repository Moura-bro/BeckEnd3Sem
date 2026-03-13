using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoEventoController : ControllerBase
{
    private readonly ITipoEventoRepository _tipoEventoRepository;

    // Injecao de dependencia : Recebe o repositorio pelo construtor
    public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
    {
        _tipoEventoRepository = tipoEventoRepository;
    }

    /// <summary>
    /// Endpoint da Api que faz a chamda para o metodo de listar os tipos de eventos
    /// </summary>
    /// <returns>Status code 200 e a lista de tipos de eventos</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_tipoEventoRepository.Listar());
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Endpoit da Api que faz a chamada para o metodo de buscar um tipo de evento por id
    /// </summary>
    /// <param name="Id">Id do Tipo de evento buscado</param>
    /// <returns>Code 200 e o tipo de evento buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid Id)
    {
        try
        {
            return Ok(_tipoEventoRepository.BuscarPorId(Id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Endpoit da API que faz a chamada para o metodo  de cadastro. de um tipo de evento 
    /// </summary>
    /// <param name="tipoEvento">Tipo de evento a ser cadastrado</param>
    /// <returns>Status code 201 e o tipo de evento a ser cadastrado </returns>
    [HttpPost]
    public IActionResult Cadastrar(TipoEventoDTO tipoEvento)
    {
        try
        {
            var novoTipoEvento = new TipoEvento
            {
                Titulo = tipoEvento.Titulo!
            };

            _tipoEventoRepository.cadastrar(novoTipoEvento);
            return StatusCode(201, tipoEvento);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }




    /// <summary>
    /// Endpoint da API que faz chmada para o metodo atualizar 
    /// </summary>
    /// <param name="id">id  do tipo envento a ser atualizado</param>
    /// <param name="tipoEvento">Tipo evento com os dados </param>
    /// <returns>Status code 204 e o tipo de evento atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoEventoDTO tipoEvento)
    {
        try
        {
            var tipoEventoAtualizado = new TipoEvento
            {
                Titulo = tipoEvento.Titulo!
            };

            _tipoEventoRepository.Atualizar(id, tipoEventoAtualizado);
            return StatusCode(204, tipoEvento);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }





    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de deletar um tipo de evento
    /// </summary>
    /// <param name="id">Id do evento a ser excluido</param>
    /// <returns>Status code 204 </returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _tipoEventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
