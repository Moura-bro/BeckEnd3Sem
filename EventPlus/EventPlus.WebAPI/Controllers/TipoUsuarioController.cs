using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Repositoriesp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoUsuarioController : ControllerBase
{
    private ITipoUsuarioRepository _tipoUsuarioRepository;

    public  TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
    {
        _tipoUsuarioRepository = tipoUsuarioRepository;
    }





    /// <summary>
    ///  Endpoint da Api que faz a chamda para o metodo de listar os tipos de Usuario
    /// </summary>
    /// <returns>Status code 200 e a lista de tipos de Usuario</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }






    /// <summary>
    /// Endpoit da Api que faz a chamada para o metodo de buscar um tipo de Usuario por id
    /// </summary>
    /// <param name="Id">Id do Tipo de Usuario buscado</param>
    /// <returns>Code 200 e o tipo de Usuario buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid Id)
    {
        try
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(Id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }







    /// <summary>
    /// Endpoit da API que faz a chamada para o metodo  de cadastro. de um tipo de Usuario 
    /// </summary>
    /// <param name="tipoUsuario">Tipo de Usuario a ser cadastrado</param>
    /// <returns>Status code 201 e o tipo de Usuario a ser cadastrado </returns>
    [HttpPost]
    public IActionResult Cadastrar(TipoUsuarioDTO tipoUsuario)
    {
        try
        {
                var novoTipoUsuario = new TipoUsuario
                {
                    Titulo = tipoUsuario.Titulo!
                };

                _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);
            return StatusCode(201, tipoUsuario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }











    /// <summary>
    /// Endpoint da API que faz chmada para o metodo atualizar 
    /// </summary>
    /// <param name="id">id  do tipo Usuario a ser atualizado</param>
    /// <param name="tipoUsuario">Tipo Usuario com os dados</param>
    /// <returns>Status code 204 e o tipo de Usuario atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoUsuarioDTO tipoUsuario)
    {
        try
        {
            var TipoUsuarioAtualizado = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };



            _tipoUsuarioRepository.Atualizar(id, TipoUsuarioAtualizado);
            return StatusCode(204, tipoUsuario);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }














    /// <summary>
    /// Endpoint da API que faz a chamada para o metodo de deletar um tipo Usuario
    /// </summary>
    /// <param name="id">Id do Usuario a ser excluido</param>
    /// <returns>Status code 204 </returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _tipoUsuarioRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


}
