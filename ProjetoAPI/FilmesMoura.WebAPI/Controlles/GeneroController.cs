using FilmesMoura.WebAPI.Interfaces;
using FilmesMoura.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmesMoura.WebAPI.Controlles;

[Route("api/[controller]")]
[ApiController]
public class GeneroController : ControllerBase
{
    private readonly IGeneroRepository _generoRepository;

    public GeneroController(IGeneroRepository generoRepository)
    {
        _generoRepository = generoRepository;
    }
    [HttpGet("{id}")]
    public IActionResult GetbyID(Guid id)
    {
        try
        {
          return Ok(_generoRepository.BuscarPorId(id));
        }
        catch(Exception ex) 
        { 
            return BadRequest(ex.Message);
        }
    } 




    [HttpGet]

    public IActionResult Get()
    {
        try
        {
            return Ok(_generoRepository.Listar());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }


    [HttpPost]
    public IActionResult Cadastrar(Genero novoGenero)
    {
        try
        {
            _generoRepository.Cadastrar(novoGenero);
            return StatusCode(201);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, Genero generoAtualizado)
    {
        try
        {
            _generoRepository.AtualizarIdUrl(id, generoAtualizado);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public IActionResult PutBody(Genero generoAtualizado)
    {
        try
        {
            _generoRepository.AtualizarIdCorpo(generoAtualizado);

            return NoContent();
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _generoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }
}
