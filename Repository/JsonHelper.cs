using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Repository
{
    public static class JsonHelper
    {
        public static string Serialize<T>(T obj)
        {
            using (var stream = new MemoryStream())
            {
                var instance = Activator.CreateInstance<T>();
                var ser = new DataContractJsonSerializer(instance.GetType());
                ser.WriteObject(stream, obj);
                stream.Position = 0;
                var sr = new StreamReader(stream);
                return sr.ReadToEnd();
            }
        }

        public static T Deserialize<T>(string json)
        {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                return (T)serializer.ReadObject(ms);
            }
        }
    }
}