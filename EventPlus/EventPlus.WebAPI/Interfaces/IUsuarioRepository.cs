using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface IUsuarioRepository
{
     void Cadastrar(Usuario usuario);
    Usuario BuscarPorId(Guid idUsuario);
    Usuario BuscarPorEmailESenha(string Email, string Senha);
}
