using System;
using System.Collections;
using System.IO;


namespace Rus_OOP_7._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Key.KKEY();
        }
    }
    class Meterology : IComparable
    {
        public DateTime date;
        public string city;
        public double temperatura;
        public double tisk;
        public double speed;
        public  Meterology(DateTime date,string city,double temperatura,double tisk,double speed)
        {
            this.date = date;
            this.city = city;
            this.temperatura = temperatura;
            this.tisk = tisk;
            this.speed = speed;
        }
        public int CompareTo(object obj)
        {
            Meterology p = (Meterology)obj;
            if (this.date > p.date) return 1;
            if (this.date < p.date) return -1;
            return 0;
        }
        public void Data1(Meterology[] a)
        {
            Console.WriteLine("\nСортування за датою:");
            Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", "Дата", "Місто", "Температура", "Тиск", "Швидкість вітру");


            Array.Sort(a);
            foreach (Meterology elem in a) elem.Inf();
        }
        public void Inf()
        {
            Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", date.ToShortDateString(), city, temperatura, tisk,speed);
        }
        public class SortByT : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Meterology p1 = (Meterology)ob1;
                Meterology p2 = (Meterology)ob2;
                if (p1.temperatura > p2.temperatura) return 1;
                if (p1.temperatura < p2.temperatura) return -1;
                return 0;
            }
        }
        public void One(Meterology[] a)
        {
            Console.WriteLine("\nСортування за температурою:");
            Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", "Дата", "Місто", "Температура", "Тиск", "Швидкість вітру");
            Array.Sort(a, new Meterology.SortByT());
            foreach (Meterology elem in a) elem.Info1();
        }
        public void Info1()
        {
            Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", date.ToShortDateString(), city, temperatura, tisk, speed);
        }

        public class SortBySpeed : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Meterology p1 = (Meterology)ob1;
                Meterology p2 = (Meterology)ob2;
                if (p1.speed > p2.speed) return 1;
                if (p1.speed < p2.speed) return -1;
                return 0;
            }
        }
        public void Two(Meterology[] a)
        {
            Console.WriteLine("\nСортування за швидкістю вітру:");
            Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", "Дата", "Місто", "Температура", "Тиск", "Швидкість вітру");
            Array.Sort(a, new Meterology.SortBySpeed());
            foreach (Meterology elem in a) elem.Info();
        }
        public void Info()
        {
            Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", date.ToShortDateString(), city, temperatura, tisk, speed);
        }

        public void Add()
        {
            Console.WriteLine("Write data:");

            string str = Console.ReadLine();

            string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
    class Key
    {
        public static void KKEY()
        {
            FileStream file1 = File.OpenRead("text.txt");
            byte[] array = new byte[file1.Length];
            file1.Read(array, 0, array.Length);
            string textfromfile = System.Text.Encoding.Default.GetString(array);
            string[] s = textfromfile.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            file1.Close();
            Meterology[] a = new Meterology[s.Length / 5];
            int c = 0;
            while (a[c] != null)
            {
                ++c;
            }
            for (int i = 0; i < s.Length; i += 5)
            {
                a[c + i / 5] = new Meterology(DateTime.Parse(s[i]), s[i + 1],double.Parse(s[i + 2]), double.Parse(s[i + 3]),double.Parse(s[i + 4]));
            }
            bool[] delete = new bool[100];
            Console.WriteLine("Add note: A");
            Console.WriteLine("Edit note: E");
            Console.WriteLine("Remove note: R");
            Console.WriteLine("Show notes: Enter");
            Console.WriteLine("Sort by temperatura: N");
            Console.WriteLine("Sort by speed: D");
            Console.WriteLine("Sort by date: S");
            Console.WriteLine("Exit: Esc");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.E:
                    Key.Edit(a);
                    break;

                case ConsoleKey.N:
                    a[0].One(a);
                    Key.KKEY();
                    break;

                case ConsoleKey.D:
                    a[0].Two(a);
                    Key.KKEY();
                    break;

                case ConsoleKey.S:
                    a[0].Data1(a);
                    Key.KKEY();
                    break;

                case ConsoleKey.Enter:
                    Key.Show(a);
                    break;

                case ConsoleKey.A:
                    Key.Add(a, c);
                    break;

                case ConsoleKey.R:
                    Key.Remove(a, delete);
                    break;

                case ConsoleKey.Escape:
                    break;
            }

        }
        public static void Show(Meterology[] a)
        {
            Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", "Дата", "Місто", "Температура", "Тиск", "Швидкість вітру");

            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] != null)
                {
                    Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", a[i].date.ToShortDateString(),a[i].city,a[i].temperatura,a[i].tisk,a[i].speed);
                }
            }
            Key.KKEY();
        }
        public static void Add(Meterology[] a, int c)
        {
            Console.WriteLine("\nWrite data:");

            string str = Console.ReadLine();

            string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Key.Parse(elements, true, a, c);
            Key.KKEY();
        }

        private static void Save(Meterology m)
        {
            StreamWriter save = new StreamWriter("text.txt", true);



            save.WriteLine(m.date);
            save.WriteLine(m.city);
            save.WriteLine(m.temperatura);
            save.WriteLine(m.tisk);
            save.WriteLine(m.speed);

            save.Close();
        }

        public static void Parse(string[] elements, bool save, Meterology[] a, int counter)
        {
            for (int i = 0; i < elements.Length; i += 5)
            {
                a[counter + i / 5] = new Meterology(DateTime.Parse(elements[i]), elements[i + 1],double.Parse(elements[i + 2]),double.Parse(elements[i + 3]),double.Parse(elements[i + 4]));
                if (save)
                {
                    Save(a[counter + i / 5]);
                }
            }
        }
        public static void Remove(Meterology[] a, bool[] delete)
        {
            Console.Write("\nCity: ");

            string name = Console.ReadLine();

            bool[] write = new bool[a.Length];
            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] != null)
                {
                    if (a[i].city == name)
                    {
                        Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", a[i].date.ToShortDateString(), a[i].city, a[i].temperatura, a[i].tisk, a[i].speed);

                        Console.WriteLine("\nDELETE? (Y/N)\n");

                        var key = Console.ReadKey().Key;

                        if (key == ConsoleKey.Y)
                        {
                            a[i] = null;
                            delete[i] = true;
                            Key.Show(a);
                        }
                        else
                        {
                            delete[i] = false;
                        }
                    }
                }
            }
            Key.KKEY();
        }
        public static void Edit(Meterology[] a)
        {
            Console.WriteLine("\nWhat do you want to edit?");
            string what = Console.ReadLine();
            switch (what)
            {
                case "city":
                    Console.WriteLine("What city: ");
                    string name1 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].city == name1)
                            {
                                Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", a[i].date.ToShortDateString(), a[i].city, a[i].temperatura, a[i].tisk, a[i].speed);

                                Console.WriteLine("New city: ");

                                string str = Console.ReadLine();

                                a[i].city = str;

                                Key.Show(a);
                            }
                        }
                    }
                    break;

                case "Date":
                    Console.WriteLine("What city: ");
                    string name2 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].city == name2)
                            {
                                Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", a[i].date.ToShortDateString(), a[i].city, a[i].temperatura, a[i].tisk, a[i].speed);

                                Console.WriteLine("New date: ");
                                string str = Console.ReadLine();
                                a[i].date = DateTime.Parse(str);
                                Key.Show(a);
                            }
                        }
                    }
                    break;
                case "temperatura":
                    Console.WriteLine("What city: ");
                    string name3 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].city == name3)
                            {
                                Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", a[i].date.ToShortDateString(), a[i].city, a[i].temperatura, a[i].tisk, a[i].speed);
                                Console.WriteLine("New subject: ");
                                string str = Console.ReadLine();
                                a[i].temperatura =double.Parse(str);
                                Key.Show(a);
                            }
                        }

                    }
                    break;

                case "tisk":
                    Console.WriteLine("What city: ");
                    string name5 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].city == name5)
                            {
                                Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", a[i].date.ToShortDateString(), a[i].city, a[i].temperatura, a[i].tisk, a[i].speed);
                                Console.WriteLine("New number: ");
                                double str = double.Parse(Console.ReadLine());
                                a[i].tisk = str;
                                Key.Show(a);
                            }
                        }
                    }
                    break;
                case "speed":
                    Console.WriteLine("What city: ");
                    string name6 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].city == name6)
                            {
                                Console.WriteLine("{0,-5} {1,-20}{2,-30}{3,-20}{4,-15} ", a[i].date.ToShortDateString(), a[i].city, a[i].temperatura, a[i].tisk, a[i].speed);
                                Console.WriteLine("New login: ");
                                string str = Console.ReadLine();
                                a[i].speed =double.Parse(str);
                                Key.Show(a);
                            }
                        }

                    }
                    break;
            }
            Key.KKEY();
        }
    }

}
