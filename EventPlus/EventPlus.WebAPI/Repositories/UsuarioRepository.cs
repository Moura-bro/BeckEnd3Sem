using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class UsuarioRepository : IUsuarioRepository
{

    private readonly EventContext _context;

    public UsuarioRepository(EventContext context)
    {
        _context = context;
    }






    /// <summary>
    /// Busca o Usuario pelo email e valida o hash da senha 
    /// </summary>
    /// <param name="Email">Email do Usuario</param>
    /// <param name="Senha">Snhae do Usuario</param>
    /// <returns>Usuario buscado e validado</returns>
    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {
        //Primero buscamos o usuário pelo email
        var usuarioBuscado = _context.Usuarios.
            Include(Usuario => Usuario.IdTipoUsuarioNavigation).
            FirstOrDefault(Usuario => Usuario.Email == Email);

        //Verificar se o Usuario Realmente existe
                if (usuarioBuscado == null)
        {
            //comparamos o hash da senha com oque esta no banco de dados
           bool confere = Criptografia.compararHash(Senha, usuarioBuscado.Senha);

            if (confere)
            {
                return usuarioBuscado;
            }
                 
        }
                return null!;

    }




    /// <summary>
    /// Busca um Usuario pelo seu id, incluindo seu dados de tipo de usuario.
    /// </summary>
    /// <param name="idUsuario">Id do usuario a ser buscado </param>
    /// <returns>Usuario Buscado</returns>
    public Usuario BuscarPorId(Guid idUsuario)
    {
        return _context.Usuarios.Include(Usuario => Usuario.IdTipoUsuarioNavigation).
            FirstOrDefault(Usuario => Usuario.IdUsuario == idUsuario)!;
    }





    /// <summary>
    /// cadastra um novo usuario, criptografando a senha antes de salvar no banco de dados.
    /// </summary>
    /// <param name="usuario">Usuario a ser cadastrado</param>
    public void Cadastrar(Usuario usuario)
    {
        usuario.Senha = Criptografia.GerarHash(usuario.Senha);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }
}
