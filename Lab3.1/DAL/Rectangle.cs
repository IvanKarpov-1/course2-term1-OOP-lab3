using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace DAL
{
    [Serializable]
    public class Rectangle : ISerializable
    {
        public string FillColor { get; set; }
        public string BorderColor { get; set; }
        public double SideAB { get; set; }
        public double SideBC { get; set; }

        private static readonly Random Random = new Random();


        public Rectangle()
        {
            FillColor = RandomHexColor();
            BorderColor = RandomHexColor();
            SideAB = RandomSideSize();
            SideBC = RandomSideSize();
        }

        public Rectangle(string fillColor, string borderColor, double sideAB, double sideBC)
        {
            CheckHexCode(fillColor);
            CheckHexCode(borderColor);
            CheckSide(sideAB);
            CheckSide(sideBC);

            FillColor = fillColor;
            BorderColor = borderColor;
            SideAB = sideAB;
            SideBC = sideBC;
        }

        protected Rectangle(SerializationInfo info, StreamingContext context)
        {
            FillColor = info.GetString("FillColor");
            BorderColor = info.GetString("BorderColor");
            SideAB = info.GetDouble("SideAB");
            SideBC = info.GetDouble("SideBC");
        }

        public double CalculateArea()
        {
            return SideAB * SideBC;
        }

        public double CalculatePerimeter()
        {
            return SideAB * 2 + SideBC * 2;
        }

        private static void CheckHexCode(string code)
        {
            var regex = new Regex(@"^#[0-9A-F]{6}$");
            if (!regex.IsMatch(code))
            {
                throw new Exception($"HEX код неправильний! {code}");
            }
        }

        private static void CheckSide(double side)
        {
            if (side <= 0)
            {
                throw new Exception("Сторона повинна бути додатньою!");
            }
        }

        public static string RandomHexColor()
        {
            var hex = "#";

            for (var i = 0; i < 3; i++)
            {
                var temp = Random.Next(0, 255);
                temp = temp < 10 ? temp + 10 : temp;
                hex += Convert.ToString(Convert.ToInt32(temp), 16).ToUpper();
            }

            if (hex.Length < 7)
            {
                var numberOfMissingCharacters = 7 - hex.Length;
                for (var i = 0; i < numberOfMissingCharacters; i++)
                {
                    hex += "0";
                }
            }

            return hex;
        }

        public static double RandomSideSize()
        {
            var temp = Random.NextDouble() * Random.Next(1, 99);
            return Math.Round(temp, 1) + 0.1;
        }

        public override string ToString()
        {
            return
                $"Прямокутник зі сторонами {SideAB,-6:F2} та {SideBC,-6:F2}, " +
                $"кольором заповнення - {FillColor} та контуру - {BorderColor}. Площа: {CalculateArea()}";
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FillColor", FillColor);
            info.AddValue("BorderColor", BorderColor);
            info.AddValue("SideAB", SideAB);
            info.AddValue("SideBC", SideBC);
        }
    }
}
