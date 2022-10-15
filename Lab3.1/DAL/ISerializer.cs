using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISerializer
    {
        void Write(IEnumerable<object> data, string connection);
        IEnumerable<object> Read(string connection);
    }
}
