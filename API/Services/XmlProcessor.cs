using System.IO.Compression;
using System.Text;
using System.Xml.Serialization;

namespace API.Services
{
    public class XmlProcessor<T> where T : class
    {
        public XmlProcessor() {}

        /// <summary>
        /// Converte uma string Base64 compactada em XML.
        /// </summary>
        /// <param name="base64String">String Base64 compactada (GZip).</param>
        public string ConvertStringBase64ToXml(string base64String)
        {
            if (string.IsNullOrWhiteSpace(base64String))
                throw new ArgumentException("A string Base64 não pode ser nula ou vazia.", nameof(base64String));

            var compressedData = Convert.FromBase64String(base64String);

            using var compressedStream = new MemoryStream(compressedData);
            using var gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress);
            using var decompressedStream = new MemoryStream();
            gzipStream.CopyTo(decompressedStream);

            return Encoding.UTF8.GetString(decompressedStream.ToArray());
        }

        /// <summary>
        /// Desserializa o XML em um objeto do tipo T.
        /// </summary>
        /// <returns>Instância do tipo T desserializada a partir do XML.</returns>
        private T DeserializeXml(string xmlString)
        {
            if (string.IsNullOrWhiteSpace(xmlString))
                throw new InvalidOperationException("O XML não foi inicializado. Verifique se o Base64 foi convertido corretamente.");

            var serializer = new XmlSerializer(typeof(T));
            using var reader = new StringReader(xmlString);
            return (T)serializer.Deserialize(reader);
        }

        /// <summary>
        /// Obtém um objeto desserializado a partir de uma string Base64 codificada.
        /// </summary>
        /// <param name="base64EncodedString">String Base64 codificada contendo o XML comprimido.</param>
        /// <returns>Instância do tipo T desserializada.</returns>
        public T GetObjectFromBase64EncodedString(string base64EncodedString)
        {
            if (string.IsNullOrWhiteSpace(base64EncodedString))
                throw new ArgumentException("A string Base64 não pode ser nula ou vazia.", nameof(base64EncodedString));

            var xmlString = ConvertStringBase64ToXml(base64EncodedString);
            return DeserializeXml(xmlString);
        }
    }
}
