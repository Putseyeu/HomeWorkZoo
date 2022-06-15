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
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("1 - Информация о вольерах, 2 - Выйти из программы.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        zoo.ChoiceAviary();
                        break;

                    case "2":
                        isWork = false;
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
            CreateAviaries();
        }

        public void ChoiceAviary()
        {
            Console.WriteLine($"Общее количесвто вольеров {_aviaries.Count}, информация о котором нужна?");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int index))
            {
                if (index <= _aviaries.Count && index != 0)
                {
                    Aviary aviary = _aviaries[index - 1];
                    aviary.ShowInfo();
                }
                else
                {
                    Console.WriteLine("Вольера с таким номером нету.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода");
            }
        }

        private void CreateAviaries()
        {
            _aviaries.Add(new Aviary(1, 3, new Animal("Слон", "Тромбит")));
            _aviaries.Add(new Aviary(1, 2, new Animal("Бегемот", "Фырчит")));
            _aviaries.Add(new Aviary(5, 3, new Animal("Горила", "Ууууууу")));
            _aviaries.Add(new Aviary(1, 10, new Animal("Лев", "Рычит Ррррр")));
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

        public void ShowInfo()
        {
            Console.WriteLine($"Инфорция о вольере" +
                $"\nЖивотные          :{Animal.Name}" +
                $"\nИздают звуки      :{Animal.Voice}" +
                $"\nКоличество самцов :{NumberMale}" +
                $"\nКоличесвто самок  :{NumberFemale}");
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
