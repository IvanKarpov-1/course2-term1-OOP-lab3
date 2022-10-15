using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class ForSerialization
    {
        private static Rectangle[] _rectanglesArray = {};
        private static List<Rectangle> _rectanglesList = new List<Rectangle>();

        public static void Add()
        {
            _rectanglesArray = _rectanglesArray.Append(new Rectangle()).ToArray();
            _rectanglesList.Add(new Rectangle());
        }

        public static IEnumerable<object> GetRectanglesArray()
        {
            return _rectanglesArray;
        }

        public static IEnumerable<object> GetRectanglesList()
        {
            return _rectanglesList;
        }
    }
}
