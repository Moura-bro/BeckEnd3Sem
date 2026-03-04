using FilmesMoura.WebAPI.DTO;
using FilmesMoura.WebAPI.Interfaces;
using FilmesMoura.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmesMoura.WebAPI.Controlles;

[Route("api/[controller]")]
[ApiController]
public class FilmeController : ControllerBase
{
    private readonly IFilmeRepository _filmeRepository;

    public FilmeController(IFilmeRepository filmeRepository)
    {
        _filmeRepository = filmeRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromForm]FilmeDTO novoFilme)
    {
        if(String.IsNullOrWhiteSpace(novoFilme.Titulo) && novoFilme.Idgenero != null) 
            return BadRequest("O título do filme é obrigatório.");

        Filme filme = new Filme();
        if(novoFilme.Imagem != null && novoFilme.Imagem.Length > 0)
        {
            var extensao = Path.GetExtension(novoFilme.Imagem.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            // Verificar se a pasta existe, caso contrário, criar
            if (!Directory.Exists(caminhoPasta))
            
                Directory.CreateDirectory(caminhoPasta);

            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

            using(var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await novoFilme.Imagem.CopyToAsync(stream);
            }

            filme.Imagem = nomeArquivo;

        }

            filme.IdGenero = novoFilme.Idgenero.ToString();
            filme.Titulo = novoFilme.Titulo!;

        try
        {
            _filmeRepository .Cadastrar(filme);
            return StatusCode(201);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(_filmeRepository.Listar());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            return Ok(_filmeRepository.BuscarPorId(id));
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, FilmeDTO filme)
    {
        var filmeBuscado = _filmeRepository.BuscarPorId(id);
        if (filmeBuscado == null)
            return NotFound("Filme não encontrado!");

        if (!String.IsNullOrWhiteSpace(filme.Titulo))
            filmeBuscado.Titulo = filme.Titulo;

        if (filme.Idgenero != null && filme.Idgenero.ToString() != 
            filmeBuscado.IdGenero)
            filmeBuscado.IdGenero = filme.Idgenero.ToString();

        if(filme.Imagem != null && filme.Imagem.Length > 0)
        {
            var pastaRelativa = "wwwroot/imagens";
            var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

            // deletar a imagem antiga, caso exista
            if (!String.IsNullOrEmpty(filmeBuscado.Imagem))
            {
                var cminhoAntigo = Path.Combine(caminhoPasta, filmeBuscado.Imagem);

                if (System.IO.File.Exists(cminhoAntigo))
                    System.IO.File.Delete(cminhoAntigo);
            }

            // salvar a nova imagem
            var extensao = Path.GetExtension(filme.Imagem.FileName);
            var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

            if (!Directory.Exists(caminhoPasta))
                Directory.CreateDirectory(caminhoPasta);

            var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);
            using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await filme.Imagem.CopyToAsync(stream);
            }
            filmeBuscado.Imagem = nomeArquivo;
        }


        try
        {
            _filmeRepository.AtualizarIdUrl(id, filmeBuscado);
            return NoContent();
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }


    [HttpPut]
    public IActionResult Put(Filme filmeAtualizado)
    {
        try
        {
            _filmeRepository.AtualizarIdCorpo(filmeAtualizado);
            return NoContent();
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var filmeBuscado = _filmeRepository.BuscarPorId(id);
        if(filmeBuscado == null)
            return NotFound("Filme nao encontrado");

        var pastaRelativa = "wwwroot/imagens";
        var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

        //Deletar Arquivo
        if (!String.IsNullOrEmpty(filmeBuscado.Imagem))
        {
            var caminho = Path.Combine(caminhoPasta, filmeBuscado.Imagem);

            if (System.IO.File.Exists(caminho))
                System.IO.File.Delete(caminho);
        }
        
        try
        {
            _filmeRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

}
