using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DAL
{
    public class CustomSerializer : ISerializer
    {
        public void Write(IEnumerable<object> data, string connection)
        {
            using (var fs = new FileStream(connection + "_Custom", FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(fs, data);
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
            using (var fs = new FileStream(connection + "_Custom", FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                try
                {
                    data = (IEnumerable<object>)formatter.Deserialize(fs);
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
