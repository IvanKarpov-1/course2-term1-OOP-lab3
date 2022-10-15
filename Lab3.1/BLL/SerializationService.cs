using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class SerializationService
    {
        private ISerializer _serializer;
        private string _path = AppDomain.CurrentDomain.BaseDirectory;

        public void SetSerializationType(int numOfType)
        {
            switch (numOfType)
            {
                case 1:
                {
                    _serializer = new BinarySerializer();
                    break;
                }
                case 2:
                {
                    _serializer = new XmlSerializer();
                    break;
                }
                case 3:
                {
                    _serializer = new JsonSerializer();
                    break;
                }
                case 4:
                {
                    _serializer = new CustomSerializer();
                    break;
                }
                default:
                {
                    _serializer = null;
                    break;
                }
            }
        }

        public void SetPath(string path)
        {
            if (path != null) _path = path;
        }

        public void Serialize()
        {
            _serializer.Write(ForSerialization.GetRectanglesArray(), _path + "Array");
            _serializer.Write(ForSerialization.GetRectanglesList(), _path + "List");
        }

        public void Deserialize()
        {
            ForDeserialization.SetRectanglesArray(_serializer.Read(_path + "Array"));
            ForDeserialization.SetRectanglesList(_serializer.Read(_path + "List"));
        }
    }
}
