using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private IEventoRepository _eventoRepository;

    public EventoController(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }










    /// <summary>
    /// Endpoit da API que faz a chamada para o metodo de listar eventos por Usuario
    /// </summary>
    /// <param name="idUsuario">Id usuario para a filtragem </param>
    /// <returns>lista de  eventos filtrados por usuario</returns>
    [HttpGet("Usuario/{idUsuario}")]
    public IActionResult ListarPorId(Guid idUsuario)
    {
        try
        {
            return Ok(_eventoRepository.ListarPorId(idUsuario));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    /// <summary>
    /// Endpoit da API que faz a chamada para o metodo de listar proximos eventos
    /// </summary>
    /// <returns>Status code 200 e uma Lista de Proximos Eventos</returns>
    [HttpGet("ListarProximos")]
    public IActionResult BuscarProximos()
    {
        try
        {
            return Ok(_eventoRepository.ListarProximos());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }









    /// <summary>
    ///  Endpoint da Api que faz a chamda para o metodo de listar  de eventos
    /// </summary>
    /// <returns>Status code 200 e a lista de eventos</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_eventoRepository.Listar());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }




    /// <summary>
    /// Endpoit da Api que faz a chamada para o metodo de buscar um  evento por id
    /// </summary>
    /// <param name="id">Id do evento buscado</param>
    /// <returns>Code 200 e o evento buscado</returns>
    [HttpGet("{id}")]
     public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_eventoRepository.BuscarPorId(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }









    /// <summary>
    /// Endpoit da API que faz a chamada para o metodo  de cadastro. de evento 
    /// </summary>
    /// <param name="evento">evento a ser cadastrad</param>
    /// <returns>Status code 201 e o evento a ser cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(EventoDTO evento)
    {
        try
        {
            var novoEvento = new Evento
            {
                Nome = evento.Nome!,
                Descricao = evento.Descricao!,
                DataEvento = evento.DataEvento!,
            };
            

            _eventoRepository.Cadastrar(novoEvento);
            return StatusCode(201);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    /// <summary>
    /// Endpoint da API que faz chmada para o metodo atualizar 
    /// </summary>
    /// <param name="id">id   envento a ser atualizado</param>
    /// <param name="evento"> evento com os dados </param>
    /// <returns>Status code 204 e oevento atualizado</returns>
    [HttpPut("{id}")]
     public IActionResult Atualizar(Guid id, EventoDTO evento)
    {
        try
        {
            var EventoAtualizado = new Evento
            {
                Nome = evento.Nome!,
                Descricao = evento.Descricao!,
                DataEvento = evento.DataEvento!,
            };

            _eventoRepository.Atualizar(id, EventoAtualizado);
            return StatusCode(204);
        }
        catch (Exception ex)
        {
             return BadRequest(ex.Message);
        }
    }




    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de deletar um evento
    /// </summary>
    /// <param name="id">Id Usuario buscado</param>
    /// <returns>Code 200 e o Usuario buscado</returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _eventoRepository.Deletar(id);
            return StatusCode(204);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
