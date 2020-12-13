using System.IO;
using System.Xml.Serialization;

namespace Serializer
{
    class XMLSerializer : ISerializer
    {
        public T Deserialize<T>(string str)
        {
            using (var sr = new StringReader(str))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(sr);
            }
        }

        public string Serialize<T>(T obj)
        {
            using (var sw = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(sw, obj);
                return sw.ToString();
            }
        }
    }
}
