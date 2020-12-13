using Newtonsoft.Json;

namespace HTTPClient
{
    public class JSONSerializer
    {
        public T Deserialize<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);

        }
    }
}
