using MySql.Data.MySqlClient;
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
            using (var conexao = new MySqlConnection(_Conexao))
            {
                conexao.Open();
                MySqlDataReader dr;

                MySqlCommand cmd = new MySqlCommand("SELECT idempre FROM emprestimo_tb ORDER BY idempre DESC LIMIT 1;", conexao);
                MySqlDataAdapter mySqlDataAdapter  = new MySqlDataAdapter(cmd);
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    emprestimo.idEmpre = (int)dr[0];//dr[0].ToString();
                }
                conexao.Close();
            }
        }

        public void Cadastrar(Emprestimo emprestimo)
        {
            using (var conexao = new MySqlConnection(_Conexao))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO emprestimo_tb VALUES(default,@dataemp,@datadev,@idusuario);", conexao);
                cmd.Parameters.Add("@dataemp", MySqlDbType.VarChar).Value = emprestimo.dataEmpre;
                cmd.Parameters.Add("@datadev", MySqlDbType.VarChar).Value = emprestimo.dataDev;
                cmd.Parameters.Add("@idusuario", MySqlDbType.VarChar).Value = emprestimo.idUsuario;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
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
