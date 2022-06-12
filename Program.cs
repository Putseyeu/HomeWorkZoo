using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkZoo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            string userInput = "";

            while (userInput != "2")
            {
                Console.WriteLine("1 - Информация о вольерах, 2 - Выйти из программы.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        zoo.ShowInfo();
                        break;

                        case "2":
                        Console.WriteLine("Закрытие приложения");
                        break;

                        default:
                        Console.WriteLine("Не верный ввод");
                        break;
                }
            }

            Console.ReadLine();
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();

        public Zoo()
        {
            CreativeAviary();
        }

        public void ShowInfo()
        {         
            Console.WriteLine($"Общее количесвто вольеров {_aviaries.Count}, информация о котором нужна?");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int Value))
            {
                if (Value <= _aviaries.Count && Value != 0)
                {
                    Aviary aviary = _aviaries[Value - 1];
                    aviary.ShowInfo(aviary);
                }

                Console.WriteLine("Вольера с таким номером нету.");
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
            }

        }

        private void CreativeAviary()
        {
            _aviaries.Add(new Aviary(1, 3, new Animal("Слон", "Тромбит")));
            _aviaries.Add(new Aviary(1, 2, new Animal("Бегемот", "Фырчит")));
            _aviaries.Add(new Aviary(5, 3, new Animal("Горила", "Ууууууу")));
            _aviaries.Add(new Aviary(1, 10,new Animal("Лев", "Рычит Ррррр")));
            _aviaries.Add(new Aviary(1, 0, new Animal("Медведь", "Рычит Уаааррррр")));
        }
    }

    class Aviary
    {      
        public int NumberMale { get; private set; }
        public int NumberFemale { get; private set; }
        public Animal Animal { get; private set; }

        public Aviary(int numberMale, int numberFemale, Animal animal)
        {
            NumberMale = numberMale;
            NumberFemale = numberFemale;
            Animal = animal;
        }

        public void ShowInfo(Aviary aviary)
        {
            Console.WriteLine($"Инфорция о вольере" +
                $"\nЖивотные          :{aviary.Animal.Name}" +
                $"\nИздают звуки      :{aviary.Animal.Voice}" +
                $"\nКоличество самцов :{aviary.NumberMale}" +
                $"\nКоличесвто самок  :{aviary.NumberFemale}");
        }
    }

    class Animal
    {
        public string Name { get; private set; }
        public string Voice { get; private set; }

        public Animal(string name, string voice)
        {
            Name = name;
            Voice = voice;
        }
    }
}
