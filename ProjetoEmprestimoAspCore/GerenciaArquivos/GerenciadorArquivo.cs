namespace ProjetoEmprestimoAspCore.GerenciaArquivos
{
    public class GerenciadorArquivo
    {
        public static string CadastrarImagemProduto(IFormFile file)
        {
            var nomeArquivo = Path.GetFileName(file.FileName);
            var Caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Imagen", nomeArquivo);

            using (var stream = new FileStream(Caminho, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Path.Combine("/Imagen", nomeArquivo).Replace("\\","/");
        }
    }
}
