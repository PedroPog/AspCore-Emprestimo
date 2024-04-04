namespace ProjetoEmprestimoAspCore.Models
{
    public class Item
    {
        public int idItem { get; set; }
        public int idEmpre { get; set; }
        public int idLivro { get; set; }
        public string nameLivro { get; set; }
        public string imgLivro { get; set; }
        public int qtd { get; set; }
    }
}
