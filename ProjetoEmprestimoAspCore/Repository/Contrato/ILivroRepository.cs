using ProjetoEmprestimoAspCore.Models;

namespace ProjetoEmprestimoAspCore.Repository.Contrato
{
    public interface ILivroRepository
    {
        IEnumerable<Livro> ObterTodosOsLivros();
        Livro ObterLivroPorId(int idLivro);
        void Cadastrar (Livro livro);
        void Atualizar(Livro livro);
        void Deletar(int idLivro);

    }
}
