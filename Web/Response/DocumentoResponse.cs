using System;
using System.Globalization;

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
    string? DataHoraEmissao,
    ICollection<NFe> NFes)
{
    public int GetQtdNFe() => NFes.Count;
    public DateTime DataEmissaoToDateTime()
    {
        string formatoEntrada = "yyyy-MM-ddTHH:mm:ss";
        DateTime dataConvertida = DateTime.ParseExact(DataHoraEmissao, formatoEntrada, null);
        
        return dataConvertida;
    }
    public string GetDataEmissaoFormatada()
    {
        string formatoSaida = "dd/MM/yyyy";
        return DataEmissaoToDateTime().ToString(formatoSaida);
    }
    public DateOnly DataEmissaoToDateOnly()
    {
        return DateOnly.FromDateTime(DataEmissaoToDateTime());
    }
    public NFe GetNFe() => NFes.First();
}
