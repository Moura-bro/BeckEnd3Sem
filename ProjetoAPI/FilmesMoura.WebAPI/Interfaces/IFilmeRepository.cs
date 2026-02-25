using FilmesMoura.WebAPI.Models;

namespace FilmesMoura.WebAPI.Interfaces;

public interface IFilmeRepository
{
    Filme BuscarPorId(Guid id);
        List<Filme> Listar();
        void Cadastrar(Filme novoFilme);
        void Deletar(Guid id);
        void AtualizarIdCorpo(Filme filmeAtualizado);
        void AtualizarIdUrl(Guid id, Filme filmeAtualizado);
}
