using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Macros
{
    public static class JsonSerialization
    {
        private static JsonSerializerSettings _settings;
        private static JsonSerializerSettings Settings
        {
            get
            {
                if (_settings == null)
                {
                    JsonSerializerSettings temp = new JsonSerializerSettings();
                    temp.TypeNameHandling = TypeNameHandling.Objects;
                    temp.NullValueHandling = NullValueHandling.Ignore;
                    _settings = temp;
                }
                return _settings;
            }
        }

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, Settings);
        }

        public static T Deserialize<T>(string serializedObject)
        {
            return JsonConvert.DeserializeObject<T>(serializedObject, Settings);
        }
    }
}
