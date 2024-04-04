using ProjetoEmprestimoAspCore.Models;
using ProjetoEmprestimoAspCore.Repository.Contrato;

namespace ProjetoEmprestimoAspCore.Repository
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly string _Conexao;
        public EmprestimoRepository(IConfiguration conexao)
        {
            _Conexao = conexao.GetConnectionString("Conexao");
        }
        public void Atualizar(Emprestimo emprestimo)
        {
            throw new NotImplementedException();
        }

        public void buscarUltimoEmp(Emprestimo emprestimo)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Emprestimo emprestimo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idEmpre)
        {
            throw new NotImplementedException();
        }

        public Emprestimo ObteEmprestimoPorId(int idEmpre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Emprestimo> ObterTodosOsEmprestimo()
        {
            throw new NotImplementedException();
        }
    }
}
