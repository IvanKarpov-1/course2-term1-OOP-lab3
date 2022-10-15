using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL;
using PL;

namespace Lab3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Default;
            Console.InputEncoding = Encoding.Default;

            var serializationService = new SerializationService();
            var ui = new Ui(serializationService);

            ui.Start();
        }
    }
}
