namespace ReserveAqui.Services;

public interface IFileUpload
{
    Task<string> SalvarImagemAsync(IFormFile imagem);
    void deletarImagem(string caminhoImagem);
}
