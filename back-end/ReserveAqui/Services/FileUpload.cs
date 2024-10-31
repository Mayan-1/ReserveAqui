using System.Text.RegularExpressions;

namespace ReserveAqui.Services;

public class FileUpload : IFileUpload
{
    private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Imagens");

    public FileUpload()
    {
        if (!Directory.Exists(_filePath))
            Directory.CreateDirectory(_filePath);
    }

    public async Task<string> SalvarImagemAsync(IFormFile imagem)
    {
        if (imagem == null || imagem.Length == 0)
            throw new ArgumentException("Arquivo de imagem inválido");

        var nomeArquivo = $"{Guid.NewGuid()}_{Path.GetFileName(imagem.FileName)}";
        var caminhoCompleto = Path.Combine(_filePath, nomeArquivo);

        using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
        {
            await imagem.CopyToAsync(stream);
        }

        return Path.Combine("Imagens", nomeArquivo);
    }

    public void deletarImagem(string caminhoImagem)
    {
        var caminhoCompleto = Path.Combine(Directory.GetCurrentDirectory(), caminhoImagem);
        if(File.Exists(caminhoCompleto))
            File.Delete(caminhoCompleto);
    }

   

}
