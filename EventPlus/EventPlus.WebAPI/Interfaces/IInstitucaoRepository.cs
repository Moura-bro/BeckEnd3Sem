using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface IInstitucaoRepository
{
    void Cadastrar(Instituicao instituicao);

        Instituicao BuscarPorId(Guid id);
        List<Instituicao> Listar();
        void Deletar(Guid id);
        void Atualizar(Guid id, Instituicao instituicao);

}
