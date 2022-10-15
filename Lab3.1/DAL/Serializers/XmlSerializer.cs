using System;
using System.Collections.Generic;
using System.IO;

namespace DAL
{
    public class XmlSerializer : ISerializer
    {
        public void Write(IEnumerable<object> data, string connection)
        {
            using (var fs = new FileStream(connection + ".xml", FileMode.Create))
            {
                var formatter = new System.Xml.Serialization.XmlSerializer(data.GetType());
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
            using (var fs = new FileStream(connection + ".xml", FileMode.OpenOrCreate))
            {
                var formatter = new System.Xml.Serialization.XmlSerializer(typeof(List<Rectangle>));
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
