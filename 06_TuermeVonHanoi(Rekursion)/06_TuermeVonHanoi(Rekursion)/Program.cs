using System;
using System.Threading.Tasks;
//Thomas Weithaler
//4 BEL
//05.05.2020
//Tuerme von Hanoi

namespace _06_TuermeVonHanoi_Rekursion_
{
    class Program
    {
        static void Main(string[] args)
        {
            //Der Algorithmus soll n Scheiben vom Turm A nach Turm C ueber den Turm B schieben.
            //Also muessen zuerst n-1 Scheiben von A nach B ueber C geschoben werden
            //Dann wird die Scheibe von A nach C geschoben
            //Als naechstes n-1 Scheiben vom Turm B nach Turm C ueber Turm A
            Console.WriteLine("Wieviele Scheiben möchten Sie verschieben?");
            uint AnzahlScheiben = 0;
            while (!(uint.TryParse(Console.ReadLine(), out AnzahlScheiben)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Eingabe ungueltig, nur natuerliche Zahlen zulaessig.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("Benennen Sie den Startturm: (A,B oder C)");
            string Startturm =Console.ReadLine();
            while (!(Startturm == "A" || Startturm == "B" || Startturm == "C"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Eingabe ungueltig: Es ist nur A,B oder C zulaessig!");
                Startturm = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Benennen Sie den Zielturm: (A,B oder C");
            string Zielturm = Console.ReadLine();
            while (!(Zielturm == "A" || Zielturm == "B" || Zielturm == "C") || Zielturm == Startturm)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Eingabe ungueltig nur A,B oder C zulässig außer dem Startturm({0})", Startturm);
                Zielturm = Console.ReadLine();
            }
            Console.ForegroundColor = ConsoleColor.White;

            string ueber = string.Empty;
            switch (Startturm)
            {
                case "A":
                    switch (Zielturm)
                    {
                        case "B":
                            ueber = "C";
                            break;

                        case "C":
                            ueber = "B";
                            break;
                    }
                    break;

                case "B":
                    switch (Zielturm)
                    {
                        case "A":
                            ueber = "C";
                            break;

                        case "C":
                            ueber = "A";
                            break;
                    }
                    break;

                case "C":
                    switch (Zielturm)
                    {
                        case "A":
                            ueber = "B";
                            break;

                        case "B":
                            ueber = "A";
                            break;
                    }
                    break;
                    
            }

            Console.WriteLine("Damit werden {0} Scheiben von Turm {1} nach Turm {2} ueber Turm {3} geschoben...", AnzahlScheiben, Startturm, Zielturm, ueber);

            System.Threading.Thread.Sleep(100);

            Console.ReadKey();
        }
    }
}
