using System.Collections.ObjectModel;
using API.Database;
using API.Models;
using API.Response;
using API.Services;
using API.UneCont.Response;
using API.XmlModels;
using Castle.Components.DictionaryAdapter.Xml;

namespace API.Endpoints;
public static class EndpointsDocumentos
{
    public static void AddEndpointsDocumentos(this WebApplication app)
    {
        app.MapGet("Documentos", (DAL<Documento> dalDocumento, XmlProcessor<CompNFe> XmlProcessor) =>
        {
            try
            {
                var response = dalDocumento.List().Select(doc =>
                    {
                        List<NFe> nfes = XmlProcessor.GetObjectFromBase64EncodedString(doc.Xml).NotasFiscais;
                        return new DocumentoApiResponse(
                            doc.UsuarioEventoId,
                            doc.EventoId,
                            doc.DataHoraEvento,
                            doc.TipoEventoId,
                            doc.DocumentoId,
                            doc.TipoDocumento,
                            doc.NumeroDocumento,
                            doc.CnpjCpfEmitente,
                            doc.CnpjCpfDestinatario,
                            doc.CodigoVerificador,
                            doc.DataHoraEmissao,
                            nfes
                        );
                    }
                ).OrderBy(doc => doc.UsuarioEventoId);
                return Results.Ok(response);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
        app.MapPost("Documentos/Importacao", async (DAL<Documento> dalDocumento, DocumentoService service) =>
        {
            long ultimoEventoUsuarioId = 0;
            var docs = dalDocumento.List().OrderByDescending(doc => doc.UsuarioEventoId).Take(1);
            var doc = docs.FirstOrDefault();
            if (doc is not null)
            {
                ultimoEventoUsuarioId = doc.UsuarioEventoId;
            }

            ICollection<DocumentoResponse> collection = new Collection<DocumentoResponse>();
            var response = await service.GetDocumentosAsyncByUltimoEventoUsuarioId(ultimoEventoUsuarioId);
            if (response is not null)
            {
                while (!ultimoEventoUsuarioId.Equals(response.MaximoEventoUsuarioId))
                {
                    collection = collection.Concat(response.ListaEventosDocumentos).ToList();
                    ultimoEventoUsuarioId = response.UltimoEventoUsuarioId;
                    response = await service.GetDocumentosAsyncByUltimoEventoUsuarioId(ultimoEventoUsuarioId);
                    if (response is null)
                    {
                        break;
                    }
                }
            }
            var models = collection.Select(c => new Documento()
            {
                UsuarioEventoId = c.UsuarioEventoId,
                EventoId = c.EventoId,
                DataHoraEvento = c.DataHoraEvento,
                TipoEventoId = c.TipoEventoId,
                DocumentoId = c.DocumentoId,
                TipoDocumento = c.TipoDocumento,
                NumeroDocumento = c.NumeroDocumento,
                CnpjCpfEmitente = c.CnpjCpfEmitente,
                CnpjCpfDestinatario = c.CnpjCpfDestinatario,
                CodigoVerificador = c.CodigoVerificador,
                DataHoraEmissao = c.DataHoraEmissao,
                Xml = c.Documentos.Xml
            });
            await dalDocumento.AddRangeAsync(models.ToList());
        });
        app.MapDelete("Documentos", async (DAL<Documento> dalDocumento) =>
        {
            await dalDocumento.DeleteAll();
        });
    }
}
