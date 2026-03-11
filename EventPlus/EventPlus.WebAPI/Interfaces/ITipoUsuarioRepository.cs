using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface ITipoUsuarioRepository
{
    void Cadastrar(TipoUsuario tipoUsuario);
    TipoUsuario BuscarPorId(Guid id);
    List<TipoUsuario> Listar();
    void Deletar(Guid id);
    void Atualizar(Guid id, TipoUsuario tipoUsuario);
}
