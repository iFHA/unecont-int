namespace API.Response;

public record DocumentoResponse(
    Int64 UsuarioEventoId,
    int EventoId,
    DateTime DataHoraEvento,
    int TipoEventoId,
    int DocumentoId,
    int TipoDocumento,
    string NumeroDocumento,
    string CnpjCpfEmitente,
    string CnpjCpfDestinatario,
    string CodigoVerificador,
    string? DataHoraEmissao
);