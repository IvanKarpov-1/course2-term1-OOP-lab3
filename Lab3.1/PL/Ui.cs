using BLL;
using System;

namespace PL
{
    public class Ui
    {
        private readonly SerializationService _serializationService;

        public Ui(SerializationService serializationService)
        {
            _serializationService = serializationService;
        }

        public void Start()
        {
            SetSerializationType();
            SetPath();

            while (true)
            {
                ChooseAction();

                switch (Console.ReadLine())
                {
                    case "1":
                    {
                        AddRectangle();
                        break;
                    }
                    case "2":
                    {
                        ShowBefore();
                        break;
                    }
                    case "3":
                    {
                        ShowAfter();
                        break;
                    }
                    case "4":
                    {
                        Serialize();
                        break;
                    }
                    case "5":
                    {
                        Deserialize();
                        break;
                    }
                    case "6":
                    {
                        SetSerializationType();
                        break;
                    }
                    case "7":
                    {
                        SetPath();
                        break;
                    }
                    case "8":
                    {
                        Environment.Exit(0);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Дія не розпізнана.\n");
                        ChooseAction();;
                        break;
                    }
                }
            }
        }

        private void ChooseAction()
        {
            Console.WriteLine("Виверіть дію:\n" +
                              "1 - Додати прямокутник/и;\n" +
                              "2 - Показати елемент/и до сериалізації;\n" +
                              "3 - Показати елементи після десиреалізації;\n" +
                              "4 - Сериалізувати;\n" +
                              "5 - Десиарилізувати;\n" +
                              "6 - Змінити тип сериалізації;\n" +
                              "7 - Змінити шлях сералізації;\n" +
                              "8 - Вихід з програми.");
        }

        private void SetSerializationType()
        {
            Console.WriteLine("Виберіть тип сериалізації:\n" +
                              "1 - Бінарнка;\n" +
                              "2 - XML;\n" +
                              "3 - JSON;\n" +
                              "4 - Користувацька.");
            var type = Console.ReadLine();
            var checker = new RegexChecker(type, @"^[1-4]$");
            _serializationService.SetSerializationType(int.Parse(checker.Check()));
            Console.WriteLine();
        }

        private void SetPath()
        {
            Console.WriteLine("Введіть шлях для збереження результатів сериалізацї, або залиште його за замовченням (Enter):");
            var path = Console.ReadLine();
            var checker = new RegexChecker(path, @"(^([a-zA-Z]:)?(\\[a-zA-Zа-яА-ЯіІїЇ\s0-9_\-]+)+\\?)|(^$|\s+/)");
            _serializationService.SetPath(checker.Check());
            Console.WriteLine();
        }

        private void AddRectangle()
        {
            Console.WriteLine("Введіть кількість прямокутників для додавання: (Enter для додавання лише одного)");
            var count = Console.ReadLine();
            var checker = new RegexChecker(count, @"(^[1-9]{1}[0-9]*$)|(^$|\s+/)");
            var result = checker.Check();
            EntityService.AddRectangles(result != string.Empty ? int.Parse(result) : 1);
            Console.WriteLine();
        }

        private void ShowBefore()
        {
            foreach (var rectangle in EntityService.GetRectanglesArrayBefore())
            {
                Console.WriteLine(rectangle);
            }
            Console.WriteLine();
        }

        private void ShowAfter()
        {
            foreach (var rectangle in EntityService.GetRectanglesArrayAfter())
            {
                Console.WriteLine(rectangle);
            }
            Console.WriteLine();
        }

        private void Serialize()
        {
            _serializationService.Serialize();
            Console.WriteLine();
        }

        private void Deserialize()
        {
            _serializationService.Deserialize();
        }
    }
}
