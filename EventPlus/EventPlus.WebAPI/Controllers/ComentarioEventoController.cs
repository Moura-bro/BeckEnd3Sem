using Azure;
using Azure.AI.ContentSafety;
using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComentarioEventoController : ControllerBase
{
    //01---------------
    private readonly IComentarioEventoRepository _comentarioEventoRepository;

    //02---------------
    private readonly ContentSafetyClient _contentSafetyClient;

    public ComentarioEventoController(ContentSafetyClient contentSafetyClient, IComentarioEventoRepository comentarioEventoRepository)
    {
        _comentarioEventoRepository = comentarioEventoRepository;
        _contentSafetyClient = contentSafetyClient;
    }
//------------------------------Listar--------------------------------------------------


    /// <summary>
    /// EndPoit da API que lista os comentarios de um Evento
    /// </summary>
    /// <returns>Lista de Comentarios do Evento</returns>
    [HttpGet]
    public IActionResult Listar() { 
        try
        {
            return Ok(_comentarioEventoRepository.Listar());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

//----------------------------------------BuscarPorIdUsuario-------------------------------------------------------



    /// <summary>
    /// Endpoit da API que lista os comentarios de um Evento filtrados pelo Id do Usuario
    /// </summary>
    /// <param name="IdUsuario">Id Usuario que Filtra os comentarios </param>
    /// <param name="IdEvento">Id Evento que Filtra os comentarios</param>
    /// <returns>Filtra os comentarios pelos Usuarios </returns>
    [HttpGet("BuscarPorIdUsuario")]
    public IActionResult BuscarPorIdUsuario(Guid IdUsuario)
    {
        try
        {
            return Ok(_comentarioEventoRepository.BuscarPorIdUsuario(IdUsuario));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }



//----------------------------------ListarSomenteExibe-------------------------------------------------------


    /// <summary>
    /// Endpoit da API que Listaos comentarios de um Evento filtrados 
    /// </summary>
    /// <param name="IdEvento">Id de Evento que Filtra os comentarios</param>
    /// <returns>Retorna apenas os Comentarios que podem ser Exibidos </returns>

    [HttpGet("ListarSomenteExibe")]
    public IActionResult ListarSomenteExibe(Guid IdEvento)
    {
        try
        {
            return Ok(_comentarioEventoRepository.ListarSomenteExibe(IdEvento));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    //----------------------------------Post------------------------------------------

    //Async = Metodo que nao e Ao vivo, e que espera uma resposta(No caso dessa Api,  espera a resposta da Ia do Azure)


    /// <summary>
    /// 
    /// </summary>
    /// <param name="comentarioEvento"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post(ComentarioEventoDTO comentarioEvento)
    {
        try
        {
            if (String .IsNullOrEmpty(comentarioEvento.Descricao))
            {
                return BadRequest("A descrição do comentário não pode ser vazia.");
            }

            //criar objeto de analize 
            var request = new AnalyzeTextOptions(comentarioEvento.Descricao);

            // Chama a API de Content Safety para analisar o texto
            Response<AnalyzeTextResult> response = await _contentSafetyClient.AnalyzeTextAsync(request);

            //Verificar se o texto tem alguma severidade maior que 0
            bool temConteudoImpropio = response.Value.CategoriesAnalysis.Any(c => c.Severity > 0);

            var novoComentario = new ComentarioEvento
            {
                Descricao = comentarioEvento.Descricao,
                IdUsuario = comentarioEvento.IdUsuario,
                IdEvento = comentarioEvento.IdEvento,
                Exibe = !temConteudoImpropio, // Se tiver conteúdo impróprio, não exibe
                DataComentarioEvento = DateTime.Now
            };

            _comentarioEventoRepository.Cadastrar(novoComentario);
            return StatusCode(201, novoComentario);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }
//-------------------------------------Deletar----------------------------------------------------


    /// <summary>
    /// Endpoit da API que faz a chamada para o metodo de deletar um comentario de evento
    /// </summary>
    /// <param name="id"> id que Seleciona o Comentario que sera deletado</param>
    /// <returns>Deleta o Comentario Selelecionado por Id</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _comentarioEventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
