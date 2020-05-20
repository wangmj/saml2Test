using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Web;
using System.Xml.Linq;

namespace SamlComposer
{
    public static class Composer
    {
        /// <summary>
        /// Decode SamlResponse
        /// </summary>
        /// <param name="samlResponse"></param>
        /// <returns></returns>
        public static string DecodeSamlResponse(string samlResponse)
        {
            var bs = Convert.FromBase64String(samlResponse);
            return Encoding.UTF8.GetString(bs);
        }
        /// <summary>
        /// Decode SamlRequest,此方法在压力测试中可能不需要
        /// </summary>
        /// <param name="samlRequest"></param>
        /// <returns></returns>
        public static string DecodeSamlRequest(string samlRequest)
        {
            var bs = Convert.FromBase64String(HttpUtility.UrlDecode(samlRequest));
            using (var output = new MemoryStream())
            {
                using (var input = new MemoryStream(bs))
                {
                    using (var unzip = new DeflateStream(input, CompressionMode.Decompress))
                    {
                        unzip.CopyTo(output, bs.Length);
                        unzip.Close();
                    }
                    return Encoding.UTF8.GetString(output.ToArray());
                }
            }
        }
        /// <summary>
        /// Encode SamlRequest
        /// </summary>
        /// <param name="xmlSamlRequest">xml格式的SamlRequest字符串</param>
        /// <returns></returns>
        public static string EncodeSamlRequest(string xmlSamlRequest)
        {
            var bytes = Encoding.UTF8.GetBytes(xmlSamlRequest);
            string middle;
            using (var output = new MemoryStream())
            {
                using (var zip = new DeflateStream(output, CompressionMode.Compress))
                    zip.Write(bytes, 0, bytes.Length);
                middle = Convert.ToBase64String(output.ToArray());
            }
            return HttpUtility.UrlEncode(middle);
        }
        /// <summary>
        /// 根据参数生成xml格式的SamlRequest
        /// </summary>
        /// <param name="issuer">adfs服务上配置的RelayingParty</param>
        /// <param name="id">guid</param>
        /// <param name="dt">时间</param>
        /// <returns>xml格式的samlrequest</returns>
        public static string GenerateSamlRequest(string issuer, Guid id, DateTime dt)
        {
            if (id == null) id = Guid.NewGuid();
            if (dt == null) dt = DateTime.Now;

            XNamespace saml2p = "urn:oasis:names:tc:SAML:2.0:protocol";
            XNamespace saml2 = "urn:oasis:names:tc:SAML:2.0:assertion";

            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(saml2p + "AuthnRequest",
                    new XAttribute(XNamespace.Xmlns + "saml2p", saml2p),
                    new XAttribute("ID", "_" + id.ToString("N")),
                    new XAttribute("IssueInstant", dt.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss")),
                    new XAttribute("ProtocolBinding", "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST"),
                    new XAttribute("Version", "2.0"),
                    new XElement(saml2 + "Issuer", new XAttribute(XNamespace.Xmlns + "saml2", saml2), issuer),
                    new XElement(saml2p + "NameIDPolicy", new XAttribute("AllowCreate", true))
                ));
            //如果保存到文件，不用xDeclaration的字符串，如果返回字符串，则需要加上不用xDeclaration的字符串
            //doc.Save("d:\\1.xml");
            return "<?xml version=\"1.0\" encoding=\"UTF - 8\"?>" + doc;
        }
    }
}
