using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Darkec.Models;
using Newtonsoft.Json;

namespace Darkec.Helpers
{
    public class JsonFileReader<Key, Value>
    {
        public static Dictionary<Key, Value> ReadJson(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);

            return JsonConvert.DeserializeObject<Dictionary<Key, Value>>(jsonString);
        }
    }
}
