using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimoAspCore.CarrinhoCompra;
using ProjetoEmprestimoAspCore.GerenciaArquivos;
using ProjetoEmprestimoAspCore.Models;
using ProjetoEmprestimoAspCore.Repository.Contrato;

namespace ProjetoEmprestimoAspCore.Controllers
{
    public class LivroController : Controller
    {
        private ILivroRepository _livroRepository;
        private Carrinho _carrinho;
        private IEmprestimoRepository _emprestimoRepository;
        private IItemRepository _itemRepository;

        public LivroController(ILivroRepository livroRepository, IEmprestimoRepository emprestimoRepository,
            IItemRepository itemRepository)//,Carrinho carrinho)
        {
            _livroRepository = livroRepository;
            _emprestimoRepository = emprestimoRepository;
            _itemRepository = itemRepository;
        }
        public IActionResult Index()
        {
            return View(_livroRepository.ObterTodosOsLivros());
        }
        public IActionResult AdicionarItem(int id)
        {
            Livro produto = _livroRepository.ObterLivroPorId(id);
            if(produto == null)
            {
                return View("NãoExisteItem");
            }
            else
            {
                var item = new Livro()
                {
                    idLivro = id,
                    qtd = 1,
                    imgLivro = produto.imgLivro,
                    nameLivro = produto.nameLivro
                };
                _carrinho.Cadastrar(item);
                return RedirectToAction(nameof(Carrinho));
            }
        }
        public IActionResult Carrinho()
        {
            return View(_carrinho.Consultar());
        }
        public IActionResult RemoverItem(int id)
        {
            _carrinho.Remover(new Livro() { idLivro=id});
            return RedirectToAction(nameof(Carrinho));
        }

        DateTime data;
        public IActionResult SalvarCarrinho(Emprestimo emprestimo)
        {
            List<Livro> carrinho = _carrinho.Consultar();

            Emprestimo mdE = new Emprestimo();
            Item mdI = new Item();

            data = DateTime.Now.ToLocalTime();

            mdE.dataEmpre = data.ToString("dd/MM/yyyy");
            mdE.dataDev = data.AddDays(7).ToString("dd/MM/yyyy");
            mdE.idUsuario = 1;

            _emprestimoRepository.Cadastrar(mdE);
            _emprestimoRepository.buscarUltimoEmp(emprestimo);//verifiar essa busca

            for(int i = 0;i < carrinho.Count; i++)
            {
                mdI.idEmpre = Convert.ToInt32(emprestimo.idEmpre);
                mdI.idLivro = Convert.ToInt32(carrinho[i].idLivro);

                _itemRepository.Cadastrar(mdI);
            }
            _carrinho.RemoverTodos();
            return RedirectToAction("confEmp");
        }
        public IActionResult confEmp()
        {
            return View();
        }


        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(Livro livro, IFormFile file) 
        {
            var caminho = GerenciadorArquivo.CadastrarImagemProduto(file);

            livro.imgLivro = caminho;

            _livroRepository.Cadastrar(livro);

            ViewBag.msg = "Cadastro realizado";
            return RedirectToAction("Index");
        }
    }
}
