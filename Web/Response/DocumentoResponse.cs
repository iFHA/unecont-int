using System;

namespace Web.Response;

public record DocumentoResponse(
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
    string? DataHoraEmissao
);
