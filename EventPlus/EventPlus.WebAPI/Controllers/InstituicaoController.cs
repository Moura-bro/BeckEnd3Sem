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
    private readonly IInstitucaoRepository _instituicaoRepository;

    public InstituicaoController(IInstitucaoRepository instituicaoRepository)
    {
        _instituicaoRepository = instituicaoRepository;
    }








    /// <summary>
    /// Endpoint da Api que faz a chamda para o metodo de listar os tipos de Instituicao
    /// </summary>
    /// <returns>Status code 200 e a lista de tipos Instituicao</returns>
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









    /// <summary>
    ///  Endpoit da Api que faz a chamada para o metodo de buscar um tipo Instituicao por id
    /// </summary>
    /// <param name="Id">Id do Tipo Instituicao buscado</param>
    /// <returns>Code 200 e o tipo Instituicao buscado</returns>
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










    /// <summary>
    /// Endpoit da API que faz a chamada para o metodo  de cadastro. de um tipo Instituicao
    /// </summary>
    /// <param name="instituicao">Tipo de Instituicao a ser cadastrado</param>
    /// <returns>Status code 201 e o tipo Institucao a ser cadastrado </returns>
    [HttpPost]
    public IActionResult Cadastrar(InstituicaoDTO instituicao)
    {
        try
        {
            var novoInstituicao = new Instituicao
            {
                Cnpj = instituicao.Cnpj!,
                Endereco = instituicao.Endereco!,
                NomeFantasia = instituicao.NomeFantasia!
            };

            _instituicaoRepository.Cadastrar(novoInstituicao);
            return StatusCode(201, instituicao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }











    /// <summary>
    /// Endpoint da API que faz chmada para o metodo atualizar 
    /// </summary>
    /// <param name="id">id  do tipo Instituicao a ser atualizado</param>
    /// <param name="instituicao">Tipo Instituicao com os dados</param>
    /// <returns>Status code 204 e o tipo  Instituicao atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, InstituicaoDTO instituicao)
    {
        try
        {
            var InstituicaoAtualizada = new Instituicao
            {
                Cnpj = instituicao.Cnpj!,
                Endereco = instituicao.Endereco!,
                NomeFantasia = instituicao.NomeFantasia!
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
