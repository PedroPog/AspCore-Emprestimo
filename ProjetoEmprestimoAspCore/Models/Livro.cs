using System.ComponentModel.DataAnnotations;

namespace ProjetoEmprestimoAspCore.Models
{
    public class Livro
    {
        [Display(Name = "Código")]
        public int idLivro { get; set; }
        [Display(Name = "Nome Livro")]
        public string nameLivro { get; set; }
        [Display(Name = "Imagem Livro")]
        public string imgLivro { get; set; }
        [Display(Name = "Quantidade")]
        public int qtd { get; set; }
    }
}
