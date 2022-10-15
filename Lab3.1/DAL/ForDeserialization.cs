using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ForDeserialization
    {
        private static Rectangle[] _rectanglesArray = { };
        private static List<Rectangle> _rectanglesList = new List<Rectangle>();

        public static void SetRectanglesArray(IEnumerable<object> array)
        {
            _rectanglesArray = array.Cast<Rectangle>().ToArray();
        }
        public static void SetRectanglesList(IEnumerable<object> array)
        {
            _rectanglesList = array.Cast<Rectangle>().ToList();
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
