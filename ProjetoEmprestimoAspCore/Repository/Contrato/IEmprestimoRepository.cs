using ProjetoEmprestimoAspCore.Models;

namespace ProjetoEmprestimoAspCore.Repository.Contrato
{
    public interface IEmprestimoRepository
    {
        IEnumerable<Emprestimo> ObterTodosOsEmprestimo();
        Emprestimo ObteEmprestimoPorId(int idEmpre);
        void buscarUltimoEmp(Emprestimo emprestimo);
        void Cadastrar(Emprestimo emprestimo);
        void Atualizar(Emprestimo emprestimo);
        void Deletar(int idEmpre);
    }
}
