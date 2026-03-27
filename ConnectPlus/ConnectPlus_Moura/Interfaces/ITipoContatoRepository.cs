using ConnectPlus_Moura.Models;

namespace ConnectPlus_Moura.Interface;

public interface ITipoContatoRepository
{
    void Cadastrar(TipoContato tipoContato);

    List<TipoContato> Listar();

    TipoContato BuscarPorId(Guid id);

    void Atualizar(Guid id, TipoContato tipoContato);

    void Deletar(Guid id);



}
