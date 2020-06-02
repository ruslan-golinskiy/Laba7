using System;
using System.Collections;

namespace Rus_OOP_7._1
{
    public class Trees : IComparable
    {
        public string name;
        public double height;
        public float cena;
        public int number;
        public string country;



        public Trees(string name, string country, float cena, int number, float height)
        {
            this.name = name;
            this.country = country;
            this.cena = cena;
            this.number = number;
            this.height = height;
        }

        public class SortByCena : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Trees p1 = (Trees)ob1;
                Trees p2 = (Trees)ob2;
                if (p1.height > p2.height) return 1;
                if (p1.height < p2.height) return -1;
                return 0;
            }
        }

        public int CompareTo(object pers)
        {
            Trees p = (Trees)pers;
            if (this.cena > p.cena) return 1;
            if (this.cena < p.cena) return -1; return 0;
        }
        public void Info()
        {

            Console.WriteLine("{0, -15}{1, -10}{2, -15}{3, -15}{4, -10}", name, country, cena, number, height);
        }
    }

    class Chiken : IEnumerable
    {
        public string name;
        public string country;
        public float cena;
        public int number;
        public float height;



        public Chiken(string name, string country, float cena, int number, float height)
        {
            this.name = name;
            this.country = country;
            this.cena = cena;
            this.number = number;
            this.height = height;
        }

        protected int size;
        protected Trees[] container;

        public Chiken()
        {
            size = 10;
            container = new Trees[size];
            FillContainer();
        }

        public Chiken(int size)
        {
            this.size = size;
            container = new Trees[size];
            FillContainer();
        }
        public Chiken(Trees[] container)
        {
            this.container = container;
            size = container.Length;
        }
        void FillContainer()
        {


            Trees p1 = new Trees("Cryptomeria", "Spain", 130, 20, 1);
            Trees p2 = new Trees("Abies","Ukraine", 150, 20, 5);
            Trees p3 = new Trees("Cedrus", "Italy", 300, 13, 3);
            Trees p4 = new Trees("Cupresus","Grees", 330, 100, 8);
            Trees p5 = new Trees("Gingo", "Egypt", 310, 50, 2);
            Trees p6 = new Trees("Larix","Montenegro", 500, 20, 4);
            Trees p7 = new Trees("Picea", "Canada", 160, 10, 10);
            Trees p8 = new Trees("Pinus", "Canada", 100, 18, 13);
            Trees p9 = new Trees("Taxus","Italy", 200, 6, 6);
            Trees p10 = new Trees("Thuja", "France", 220, 23, 3/2);
            Trees[] pn = new Trees[10];
            pn[0] = p1;
            pn[1] = p2;
            pn[2] = p3;
            pn[3] = p4;
            pn[4] = p5;
            pn[5] = p6;
            pn[6] = p7;
            pn[7] = p8;
            pn[8] = p9;
            pn[9] = p10;



        }
        public IEnumerator GetEnumerator()
        {
            Array.Sort(container);
            return container.GetEnumerator();
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Trees p1 = new Trees("Cryptomeria", "Spain", 130, 20, 1);
            Trees p2 = new Trees("Abies", "Ukraine", 150, 20, 5);
            Trees p3 = new Trees("Cedrus", "Italy", 300, 13, 3);
            Trees p4 = new Trees("Cupresus", "Grees", 330, 100, 8);
            Trees p5 = new Trees("Gingo", "Egypt", 310, 50, 2);
            Trees p6 = new Trees("Larix", "Montenegro", 500, 20, 4);
            Trees p7 = new Trees("Picea", "Canada", 160, 10, 10);
            Trees p8 = new Trees("Pinus", "Canada", 100, 18, 13);
            Trees p9 = new Trees("Taxus", "Italy", 200, 6, 6);
            Trees p10 = new Trees("Thuja", "France", 220, 23, 3 / 2);
            Trees[] pn = new Trees[10];
            pn[0] = p1;
            pn[1] = p2;
            pn[2] = p3;
            pn[3] = p4;
            pn[4] = p5;
            pn[5] = p6;
            pn[6] = p7;
            pn[7] = p8;
            pn[8] = p9;
            pn[9] = p10;
            Array.Sort(pn);

            Console.WriteLine("\t\t\tПорівняння за ціною\n{0, -15}{1, -10}{2, -15}{3, -15}{4, -10}", "Дерево", "Країна", "Ціна", "Кількість", "Висота");
            foreach (Trees elem in pn) elem.Info();
            Console.WriteLine("\n\t\t\tСортувати за висотою");
            Array.Sort(pn, new Trees.SortByCena());
            foreach (Trees elem in pn) elem.Info();

            int size = 10;
            Chiken chic = new Chiken(size);

            Console.WriteLine("\t\t\tПорівняння за ціною");
            foreach (Chiken chics in chic)
            {
                Console.WriteLine("{0, -15}{1, -10}{2, -15}{3, -15}{4, -10}", chic.name, chic.country, chic.cena, chic.number, chic.height);
            }


        }
    }
}
