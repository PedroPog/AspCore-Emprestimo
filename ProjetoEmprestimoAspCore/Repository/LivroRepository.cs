using MySql.Data.MySqlClient;
using ProjetoEmprestimoAspCore.Models;
using ProjetoEmprestimoAspCore.Repository.Contrato;
using System.Data;

namespace ProjetoEmprestimoAspCore.Repository
{
    public class LivroRepository : ILivroRepository
    {
        private readonly string _Conexao;
        public LivroRepository(IConfiguration conexao)
        {
            _Conexao = conexao.GetConnectionString("Conexao");
        }   
        public void Atualizar(Livro livro)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Livro livro)
        {
            using(var conexao = new MySqlConnection(_Conexao))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO livro_tb " +
                    "VALUES(default, @namelivro, @imglivro)", conexao);

                cmd.Parameters.Add("@namelivro", MySqlDbType.VarChar).Value = livro.nameLivro;
                cmd.Parameters.Add("@imglivro", MySqlDbType.VarChar).Value = livro.imgLivro;

                cmd.ExecuteNonQuery();

                conexao.Close();
            }
        }

        public void Deletar(int idLivro)
        {
            throw new NotImplementedException();
        }

        public Livro ObterLivroPorId(int idLivro)
        {
            using (var conexao = new MySqlConnection(_Conexao))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM livro_tb WHERE idLivro = @idLivro", conexao);

                cmd.Parameters.Add("@idLivro", MySqlDbType.VarChar).Value = idLivro;

                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                MySqlDataReader mySqlDataReader;

                Livro livro = new Livro();
                mySqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while(mySqlDataReader.Read())
                {
                    livro.idLivro = (int) mySqlDataReader["idLivro"];
                    livro.nameLivro = (string)mySqlDataReader["nameLivro"];
                    livro.imgLivro = (string)mySqlDataReader["imgLivro"];
                }
                return livro;
            }
        }

        public IEnumerable<Livro> ObterTodosOsLivros()
        {
            List<Livro> livroList = new List<Livro>();
            using (var conexao = new MySqlConnection(_Conexao))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM livro_tb ", conexao);


                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                mySqlDataAdapter.Fill(dt);
                conexao.Close();

                foreach (DataRow dr in dt.Rows) 
                {
                    livroList.Add(
                        new Livro
                        {
                            idLivro = (int)dr["idlivro"],
                            nameLivro = (string)dr["nameLivro"],
                            imgLivro = (string)dr["imgLivro"]
                        });
                }
                return livroList;
            }
        }
    }
}

