using System.Xml.Serialization;

namespace API.XmlModels;

[XmlRoot("CompNFe")]
public class CompNFe
{
    [XmlElement("NFe")]
    public List<NFe> NotasFiscais { get; set; }
}