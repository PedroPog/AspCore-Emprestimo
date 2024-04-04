using Microsoft.AspNetCore.Mvc;
using ProjetoEmprestimoAspCore.GerenciaArquivos;
using ProjetoEmprestimoAspCore.Models;
using ProjetoEmprestimoAspCore.Repository.Contrato;

namespace ProjetoEmprestimoAspCore.Controllers
{
    public class LivroController : Controller
    {
        private ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        public IActionResult Index()
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
