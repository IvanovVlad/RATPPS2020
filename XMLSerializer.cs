using System.IO;
using System.Xml.Serialization;

namespace Serializer
{
    class XMLSerializer : ISerializer
    {
        public T Deserialize<T>(string str)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (var fs = File.OpenRead("input.xml"))
            {
                return (T)xmlSerializer.Deserialize(fs);
            }
        }

        public string Serialize<T>(T obj)
        {
            var file = "input.xml";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (var fs = File.Create(file))
            {
                xmlSerializer.Serialize(fs, obj);
            }
            using (var fs = File.OpenText(file))
            {
                return fs.ReadToEnd();
            }
        }
    }
}
