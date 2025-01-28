using System.Collections.ObjectModel;
using API.Database;
using API.Models;
using API.Response;
using API.Services;

namespace API.Endpoints;
public static class EndpointsDocumentos
{
    public static void AddEndpointsDocumentos(this WebApplication app)
    {
        app.MapGet("Documentos", (DAL<Documento> dalDocumento) =>
        {
            var response = dalDocumento.List().Select(doc => new DocumentoResponse(
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
                doc.DataHoraEmissao
            ));
            return Results.Ok(response);
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
            while (!ultimoEventoUsuarioId.Equals(response.MaximoEventoUsuarioId))
            {
                collection = collection.Concat(response.ListaEventosDocumentos).ToList();
                ultimoEventoUsuarioId = response.UltimoEventoUsuarioId;
                response = await service.GetDocumentosAsyncByUltimoEventoUsuarioId(ultimoEventoUsuarioId);

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
                DataHoraEmissao = c.DataHoraEmissao
            });
            await dalDocumento.AddRangeAsync(models.ToList());
        });
        app.MapDelete("Documentos", (DAL<Documento> dalDocumento) =>
        {
            dalDocumento.DeleteAll();
        });
    }
}
