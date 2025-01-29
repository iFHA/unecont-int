using System.Xml.Serialization;

namespace API.XmlModels;

public class NFe
{
    public string NumeroNFe { get; set; }
    public string CodigoVerificador { get; set; }
    public DateTime DataEmissaoNFe { get; set; }
    public DateTime DataCompetenciaNFe { get; set; }
    public int NFeIntercompany { get; set; }
    public int TipoTributacaoNFe { get; set; }
    public int PrestadorOptanteSimplesNacional { get; set; }
    public int PrestadorOptanteSimei { get; set; }
    public string CodigoServicoMunicipal { get; set; }
    public string DescricaoServicoMunicipal { get; set; }
    public string CodigoItemLei116 { get; set; }
    public string DescricaoItemLei116 { get; set; }
    public int MunicipioPrestacaoIbge { get; set; }
    public string MunicipioPrestacao { get; set; }
    public int UfPrestacaoIbge { get; set; }
    public decimal ValorNFe { get; set; }
    public int ISSRetido { get; set; }
    public int MunicipioDevidoISSIbge { get; set; }
    public int UfDevidoISSIbge { get; set; }
    public decimal ValorDeducaoISS { get; set; }
    public decimal BaseCalculoISS { get; set; }
    public decimal AliquotaIss { get; set; }
    public decimal ValorISS { get; set; }
    public decimal BaseCalculoCSRF { get; set; }
    public decimal ValorPIS { get; set; }
    public decimal AliquotaPIS { get; set; }
    public decimal ValorCOFINS { get; set; }
    public decimal AliquotaCOFINS { get; set; }
    public decimal ValorCSLL { get; set; }
    public decimal AliquotaCSLL { get; set; }
    public decimal BaseCalculoIRRF { get; set; }
    public decimal AliquotaIRRF { get; set; }
    public decimal ValorIRRF { get; set; }
    public decimal BaseCalculoINSS { get; set; }
    public int DesoneracaoFolhaINSS { get; set; }
    public decimal AliquotaINSS { get; set; }
    public decimal ValorINSS { get; set; }
    public decimal ValorLiquidoNFe { get; set; }
    
    [XmlElement("Prestador")]
    public Parceiro Prestador { get; set; }
    
    [XmlElement("Tomador")]
    public Parceiro Tomador { get; set; }
}