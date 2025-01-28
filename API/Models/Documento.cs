namespace API.Models;
public class Documento
{
    public long UsuarioEventoId { get; set; }
    public int EventoId { get; set; }
    public DateTime DataHoraEvento { get; set; }
    public int TipoEventoId { get; set; }
    public int DocumentoId { get; set; }
    public int TipoDocumento { get; set; }
    public string NumeroDocumento { get; set; } = string.Empty;
    public string CnpjCpfEmitente { get; set; } = string.Empty;
    public string CnpjCpfDestinatario { get; set; } = string.Empty;
    public string? CodigoVerificador { get; set; } = string.Empty;
    public string? DataHoraEmissao { get; set; }
}
