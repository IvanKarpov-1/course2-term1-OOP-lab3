using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public static class EntityService
    {
        public static void AddRectangles(int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                ForSerialization.Add();
            }
        }

        public static IEnumerable<object> GetRectanglesArrayBefore()
        {
            return ForSerialization.GetRectanglesArray();
        }
        public static IEnumerable<object> GetRectanglesListBefore()
        {
            return ForSerialization.GetRectanglesList();
        }
        public static IEnumerable<object> GetRectanglesArrayAfter()
        {
            return ForDeserialization.GetRectanglesArray();
        }
        public static IEnumerable<object> GetRectanglesListAfter()
        {
            return ForDeserialization.GetRectanglesList();
        }
    }
}
