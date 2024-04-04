

using Newtonsoft.Json;
using ProjetoEmprestimoAspCore.Models;

namespace ProjetoEmprestimoAspCore.CarrinhoCompra
{
    public class Carrinho
    {
        private string Key = "COOKIE.COMPRAS";
        private Cookie.Cookie _cookie;

        public Carrinho(Cookie.Cookie cookie)
        {
            _cookie = cookie;
            
        }
        public void Salvar(List<Livro> list)
        {
            string Valor = JsonConvert.SerializeObject(list);
            _cookie.Cadastrar(Key, Valor);
        }
        public List<Livro> Consultar()
        {
            return 
        }
    }
}
