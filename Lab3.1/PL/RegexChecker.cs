using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PL
{
    public class RegexChecker
    {
        private string _data;
        private readonly string _format;

        public RegexChecker(string data, string format)
        {
            _data = data; _format = format;
        }

        public string Check()
        {
            var regex = new Regex(_format);
            while (!regex.IsMatch(_data))
            {
                Console.WriteLine("Значення невірне. Будь ласка, введіть ще раз");
                _data = Console.ReadLine();
            }
            return _data;
        }

    }
}
