using System.Xml.Serialization;

namespace TodoPlanning.Providers.Helper
{
    public class XmlParseHelper
    {
        public static T Deserialize<T>(string xmlString)
        {
            if (xmlString == null) return default;
            var serializer = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(xmlString))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
