using ConnectPlus_Moura.Models;

namespace ConnectPlus_Moura.Interface;

public interface IContatoRepository
{
    void Cadastrar(Contado contato);
    List<Contado> Listar();
    Contado BuscarPorId(Guid id);
    void Atualizar(Guid id, Contado contato);
    void Deletar(Guid id);
}
