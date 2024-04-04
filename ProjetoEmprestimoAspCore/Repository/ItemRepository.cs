using MySql.Data.MySqlClient;
using ProjetoEmprestimoAspCore.Models;
using ProjetoEmprestimoAspCore.Repository.Contrato;

namespace ProjetoEmprestimoAspCore.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly string _Conexao;
        public ItemRepository(IConfiguration conexao)
        {
            _Conexao = conexao.GetConnectionString("Conexao");
        }
        public void Atualizar(Item item)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Item item)
        {
            using (var conexao = new MySqlConnection(_Conexao))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO itensemp VALUES(default,@idEmp,@idLivro);", conexao);
                cmd.Parameters.Add("@idEmp",MySqlDbType.VarChar).Value = item.idEmpre;
                cmd.Parameters.Add("@idLivro",MySqlDbType.VarChar).Value = item.idLivro;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Deletar(int idItem)
        {
            throw new NotImplementedException();
        }

        public Item ObteItemPorId(int idItem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Item> ObterTodosOsItens()
        {
            throw new NotImplementedException();
        }
    }
}
