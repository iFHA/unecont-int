using API.XmlModels;

namespace API.Response;

public record DocumentoApiResponse(
    long UsuarioEventoId,
    int EventoId,
    DateTime DataHoraEvento,
    int TipoEventoId,
    int DocumentoId,
    int TipoDocumento,
    string NumeroDocumento,
    string CnpjCpfEmitente,
    string CnpjCpfDestinatario,
    string CodigoVerificador,
    string? DataHoraEmissao,
    ICollection<NFe> NFes
);