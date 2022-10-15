using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace DAL
{
    public class JsonSerializer : ISerializer
    {
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            WriteIndented = true
        };


        public void Write(IEnumerable<object> data, string connection)
        {
            using (var fs = new FileStream(connection + ".json", FileMode.Create))
            {
                try
                {
                    System.Text.Json.JsonSerializer.Serialize(fs, data, _options);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public IEnumerable<object> Read(string connection)
        {
            IEnumerable<object> data;
            using (var fs = new FileStream(connection + ".json", FileMode.OpenOrCreate))
            {
                try
                {
                    data = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Rectangle>>(fs, _options);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return data;
        }
    }
}
