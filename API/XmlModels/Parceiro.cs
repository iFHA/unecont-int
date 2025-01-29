namespace API.XmlModels;

public class Parceiro
{
    public string CnpjCpf { get; set; }
    public string InscricaoMunicipal { get; set; }
    public string RazaoSocialNome { get; set; }
    public string NomeFantasia { get; set; }
    public int CodigoNaturezaJuridica { get; set; }
    public string DescricaoNaturezaJuridica { get; set; }
    public string Email { get; set; }
    public string TipoLogradouro { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public int MunicipioId { get; set; }
    public string Municipio { get; set; }
    public int UfId { get; set; }
    public string Cep { get; set; }
    public int CodigoCnaePrincipal { get; set; }
}