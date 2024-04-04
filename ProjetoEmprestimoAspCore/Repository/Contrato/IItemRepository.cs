using ProjetoEmprestimoAspCore.Models;

namespace ProjetoEmprestimoAspCore.Repository.Contrato
{
    public interface IItemRepository
    {
        IEnumerable<Item> ObterTodosOsItens();
        Item ObteItemPorId(int idItem);
        void Cadastrar(Item item);
        void Atualizar(Item item);
        void Deletar(int idItem);
    }
}
