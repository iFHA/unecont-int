using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using API.Response;
using API.UneCont.Request;
using API.UneCont.Response;
using API.XmlModels;

namespace API.Services;
public class DocumentoService
{
    private readonly HttpClient HttpClient;
    private readonly IConfiguration Config;
    public DocumentoService()
    { }
    public DocumentoService(HttpClient HttpClient, IConfiguration Config)
    {
        this.HttpClient = HttpClient;
        this.Config = Config;
    }

    private async Task LoginAsync()
    {
        var response = await HttpClient.PostAsJsonAsync($"{Config["UneContAPI:BaseUrl"]}/Token",
        new TokenRequest
        {
            Usuario = Config["UneContAPI:User"] ?? "",
            Senha = Config["UneContAPI:Password"] ?? "",
        }
        );
        // TODO: tratar erro na resposta do login

        if (response.IsSuccessStatusCode)
        {
            var tokenResponse = await response.Content.ReadFromJsonAsync<TokenResponse>();
            string accessToken = tokenResponse?.Token ?? "";
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        }
    }
    public async Task<DocumentoConsultaResponse> GetDocumentosAsyncByUltimoEventoUsuarioId(long ultimoEventoUsuarioId = 0)
    {
        await LoginAsync();
        var response = await HttpClient.PostAsJsonAsync($"{Config["UneContAPI:BaseUrl"]}/v2/UneCont/Documento/Consulta",
        new
        {
            UltimoEventoUsuarioId = ultimoEventoUsuarioId
        }
        );

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<DocumentoConsultaResponse>();
        }
        return null;
    }
}
