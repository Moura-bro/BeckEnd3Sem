using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositories;
using EventPlus.WebAPI.Repositoriesp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstituicaoController : ControllerBase
{
    private IInstitucaoRepository _instituicaoRepository;

    public InstituicaoController(IInstitucaoRepository instituicaoRepository)
    {
        _instituicaoRepository = instituicaoRepository;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_instituicaoRepository.Listar());
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }




    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid Id)
    {
        try
        {
            return Ok(_instituicaoRepository.BuscarPorId(Id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    public IActionResult Cadastrar(InstituicaoDTO instituicao)
    {
        try
        {
            var novoInstituicao = new Instituicao
            {
                Cnpj = instituicao.Cnpj!
            };

            _instituicaoRepository.Cadastrar(novoInstituicao);
            return StatusCode(201, instituicao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, InstituicaoDTO instituicao)
    {
        try
        {
            var InstituicaoAtualizada = new Instituicao
            {
                Cnpj = instituicao.Cnpj!
            };


            _instituicaoRepository.Atualizar(id, InstituicaoAtualizada);
            return StatusCode(204, instituicao);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de deletar uma Instituicao
    /// </summary>
    /// <param name="id">Id do Instituicao a ser excluido</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _instituicaoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
