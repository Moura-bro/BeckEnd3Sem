using FilmesMoura.WebAPI.Models;

namespace FilmesMoura.WebAPI.Interfaces;

public interface IGeneroRepository
{
    Genero BuscarPorId(Guid id);
    List<Genero> Listar();
    void Cadastrar(Genero novoGenero);
    void Deletar(Guid id);
    void AtualizarIdCorpo(Genero generoAtualizado);
    void AtualizarIdUrl(Guid id, Genero generoAtualizado);
}
