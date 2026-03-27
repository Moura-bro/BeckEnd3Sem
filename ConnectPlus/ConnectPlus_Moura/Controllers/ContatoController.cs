using ConnectPlus_Moura.DTO;
using ConnectPlus_Moura.Interface;
using ConnectPlus_Moura.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus_Moura.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
    private readonly IContatoRepository _contatoRepository;

    public ContatoController(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }




    //------------------Listar------------------

    /// <summary>
    /// Listar os contatos cadastrados
    /// </summary>
    /// <returns>Lista os contatos</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_contatoRepository.Listar());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    //------------------BuscarPorId------------------


    /// <summary>
    /// Busca um contato específico a partir do seu Id
    /// </summary>
    /// <param name="Id"> Id que sera Buscado</param>
    /// <returns>Retorna Id Buscado</returns>
    [HttpGet("{Id}")]
    public IActionResult BuscarPorId(Guid Id)
    {
        try
        {
            return Ok(_contatoRepository.BuscarPorId(Id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }



    //------------------Cadastrar------------------


    /// <summary>
    /// Endpoint para cadastrar um novo contato, onde é possível enviar uma imagem e os dados do contato. A imagem será salva em uma pasta específica no servidor,
    /// e o nome do arquivo será armazenado no banco de dados junto com os outros detalhes do contato.
    /// </summary>
    /// <param name="contato">Contato que sera cadastrado</param>
    /// <returns>Cadastra Um novo contato</returns>
    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromForm] ContatoDTO contato)
    {
        try
        {
            var novoContato = new Contado
            {
                Nome = contato.Nome!,
                FormaContato = contato.FormaContato!
            };

            // Lógica de salvar imagem extraída do seu exemplo
            if (contato.Imagens != null && contato.Imagens.Length > 0)
            {
                var extensao = Path.GetExtension(contato.Imagens.FileName);
                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";
                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                if (!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await contato.Imagens.CopyToAsync(stream);
                }

                novoContato.Imagens = nomeArquivo;
            }

            _contatoRepository.Cadastrar(novoContato);
            return StatusCode(201);
        }
        catch (Exception e)
        {
            return BadRequest(e.InnerException?.Message);
        }
    }



    //------------------Atualizar------------------


    /// <summary>
    /// Endpoint para atualizar um contato existente, onde é possível enviar uma nova imagem e os dados atualizados do contato.
    /// A nova imagem será salva em uma pasta específica no servidor,
    /// </summary>
    /// <param name="Id"> Id que sera Buscado</param>
    /// <param name="contato">Contato que sera Atualizado</param>
    /// <returns>Atuliza o contato buscado</returns>
    [HttpPut("{Id}")]
    public async Task<IActionResult> Atualizar(Guid Id, [FromForm] ContatoDTO contato)
    {
        try
        {
            var contatoBuscado = new Contado
            {
                Nome = contato.Nome!,
                FormaContato = contato.FormaContato!
            };

            // Lógica de salvar imagem no Atualizar
            if (contato.Imagens != null && contato.Imagens.Length > 0)
            {
                var extensao = Path.GetExtension(contato.Imagens.FileName);
                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";
                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                if (!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await contato.Imagens.CopyToAsync(stream);
                }

                contatoBuscado.Imagens = nomeArquivo;
            }

            _contatoRepository.Atualizar(Id, contatoBuscado);
            return StatusCode(204, contatoBuscado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    //------------------Deletar------------------


    /// <summary>
    /// Endpoint para deletar um contato existente, onde é necessário passar o Id do contato a ser deletado.
    /// O contato correspondente ao Id fornecido será removido do banco de dados.
    /// </summary>
    /// <param name="Id">Id que sera deletado</param>
    /// <returns>Deleta o Id Buscado </returns>
    [HttpDelete("{Id}")]
    public IActionResult Deletar(Guid Id)
    {
        try
        {
            _contatoRepository.Deletar(Id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}


