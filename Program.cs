using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkZoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            Console.CursorVisible = false;

            while (true)
            {
                Console.SetCursorPosition(35, 10);
                Console.WriteLine("Виртуальная карта нашего зоопарка.");
                zoo.ShowMap(zoo.Map, zoo.UserX, zoo.UserY);
                zoo.MoveUser(zoo.Map, ref zoo.UserX, ref zoo.UserY);
                zoo.ShowInfo(zoo.Map, zoo.UserX, zoo.UserY);
            }
        }
    }

    class Zoo
    {
        private char[,] map = {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#','#','#','#','#','#','#','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','&',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ','!',' ',' ',' ',' ',' ',' ',' ','$',' ',' ',' ',' ',' ',' ',' ',' ',' ','%',' ','#' },
                {'#','#','#','#','#',' ',' ',' ','#','#','#','#','#','#',' ',' ',' ',' ','#','#','#','#','#' },
                {'#',' ',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ','#',' ',' ',' ',' ','#',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ','#',' ',' ',' ',' ','#',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ','#',' ',' ',' ',' ','#',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ',' ',' ','#',' ',' ',' ',' ','#',' ',' ',' ',' ','#',' ',' ',' ','#' },
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' }
            };

        public char[,] Map => map;
        public int UserX = 1;
        public int UserY = 1;

        public void ShowMap(char[,] map, int x, int y)
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < map.GetLength(0); i++)
            {

                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }

            Console.SetCursorPosition(y, x);
            Console.Write('@');
        }

        public void MoveUser(char[,] map, ref int userX, ref int userY)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            switch (userInput.Key)
            {
                case ConsoleKey.UpArrow:

                    if (map[userX - 1, userY] != '#')
                    {
                        userX--;
                    }

                    break;

                case ConsoleKey.DownArrow:

                    if (map[userX + 1, userY] != '#')
                    {
                        userX++;
                    }

                    break;

                case ConsoleKey.LeftArrow:
                    if (map[userX, userY - 1] != '#')
                    {
                        userY--;
                    }

                    break;

                case ConsoleKey.RightArrow:

                    if (map[userX, userY + 1] != '#')
                    {
                        userY++;
                    }

                    break;
            }
        }

        public void ShowInfo(char[,] map, int userX, int userY)
        {
            if (map[userX, userY] == ' ')
            {
                Console.Clear();
            }

            if (map[userX, userY] == '!')
            {
                Animal animalBear = new Bear();
            }

            if (map[userX, userY] == '$')
            {
                Animal animalLion = new Lion();
            }

            if (map[userX, userY] == '%')
            {
                Animal animalElephant = new Elephant();
            }

            if (map[userX, userY] == '&')
            {
                Animal animalTiger = new Tiger();
            }          
        }
    }

    class Animal
    {
        protected string _name;
        protected int _number;
        private string _genderFemale = "самка";
        private string _genderMale = "самец";

        public Animal()
        {
            SetName();
            SetNumber();
            ShowName();
            ShowInfoNumber();
            ReproductionVoice();
            ShowInfoGender();
        }

        public void ShowName()
        {
            Console.SetCursorPosition(35, 0);
            Console.WriteLine($"Информация о вольере с животными {_name} ");
        }

        public void ShowInfoNumber()
        {
            Console.SetCursorPosition(35, 2);
            Console.WriteLine($"Общее количество животных {_number}");
        }

        public void ShowInfoGender()
        {
            int pair = 2;
            int numberFemale;
            int numberMale = 1;
            Console.SetCursorPosition(35, 3);

            if (_number == pair)
            {               
                Console.WriteLine($"Тут живет пара {_genderMale}  и {_genderFemale}");
            }

            if (_number < pair && _number > 0)
            {
                Console.WriteLine($"Тут проживает одинокий {_genderMale}");
            }

            if (_number > pair)
            {
                numberFemale = _number - numberMale;
                Console.WriteLine($"Тут проживает {_genderMale} и {numberFemale} {_genderFemale}.");
            }
        }

        public virtual void SetName()
        {
            _name = "Пустой";
        }


        public virtual void SetNumber()
        {
            
        }

        public virtual void ReproductionVoice()
        {

        }    
    }

    class Bear : Animal
    {
 
        public override void ReproductionVoice()
        {
            Console.SetCursorPosition(35, 1);
            Console.WriteLine("Уаукауаауу - рык медведя !");
        }

        public override void SetName()
        {
           _name = "медведи";
        }

        public override void SetNumber()
        {
            _number = 5;
        }
    }

    class Lion : Animal
    {
        public override void ReproductionVoice()
        {
            Console.SetCursorPosition(35, 1);
            Console.WriteLine("РРРРРРРР - рычат львы!");
        }

        public override void SetName()
        {
            _name = "львы";
        }

        public override void SetNumber()
        {
            _number = 3;
        }
    }

    class Elephant : Animal
    {
        public override void ReproductionVoice()
        {
            Console.SetCursorPosition(35, 1);
            Console.WriteLine("Тууу ттттууу  - тромбят слоны");
        }

        public override void SetName()
        {
            _name = "слоны";
        }

        public override void SetNumber()
        {
            _number = 2;
        }
    }

    class Tiger : Animal
    {
        public override void ReproductionVoice()
        {
            Console.SetCursorPosition(35, 1);
            Console.WriteLine("Рув рув рав  - голос тигра");
        }

        public override void SetName()
        {
            _name = "тигры";
        }

        public override void SetNumber()
        {
            _number = 1;
        }
    }
}
