using System;
using System.Net.Http.Json;
using Web.Response;

namespace Web.Services;

public class DocumentoAPI
{
    private readonly HttpClient _httpClient;
    public DocumentoAPI(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("API");
    }

    public async Task<ICollection<DocumentoResponse>?> GetDocumentosAsync()
    {
        return await _httpClient.GetFromJsonAsync<ICollection<DocumentoResponse>>("Documentos");
    }
    public async Task ImportDocumentosAsync()
    {
        await _httpClient.PostAsync("Documentos/Importacao", null);
    }

    public async Task DeleteDocumentoAsync()
    {
        await _httpClient.DeleteAsync("Documentos");
    }
}
