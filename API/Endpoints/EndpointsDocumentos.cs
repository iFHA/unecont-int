using API.Database;
using API.Models;
using API.Response;

namespace API.Endpoints;
public static class EndpointsDocumentos
{
    public static void AddEntpointsDocumentos(this WebApplication app)
    {
        app.MapGet("", (DAL<Documento> dalDocumento) =>
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
    }
}
