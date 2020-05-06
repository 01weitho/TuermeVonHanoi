using System;
using System.Security.Principal;
using System.Threading.Tasks;
//Thomas Weithaler
//4 BEL
//05.05.2020
//Tuerme von Hanoi

namespace _06_TuermeVonHanoi_Rekursion_
{
    class Program
    {
        static int[,] Feld;
        static uint _start;
        static uint _ziel;
        static uint AnzahlScheiben;
        static void Main(string[] args)
        {
            Console.WriteLine("Wieviele Scheiben möchten Sie verschieben?");
            while (!(uint.TryParse(Console.ReadLine(), out AnzahlScheiben)))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Eingabe ungueltig, nur natuerliche Zahlen zulaessig.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("Benennen Sie den Startturm: (A,B oder C)");
            string Startturm = Console.ReadLine();
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
                            _ziel = 2;
                            ueber = "C";
                            break;

                        case "C":
                            _ziel = 3;
                            ueber = "B";
                            break;
                    }
                    break;

                case "B":
                    switch (Zielturm)
                    {
                        case "A":
                            _ziel = 1;
                            ueber = "C";
                            break;

                        case "C":
                            _ziel = 3;
                            ueber = "A";
                            break;
                    }
                    break;

                case "C":
                    switch (Zielturm)
                    {
                        case "A":
                            _ziel = 1;
                            ueber = "B";
                            break;

                        case "B":
                            _ziel = 2;
                            ueber = "A";
                            break;
                    }
                    break;

            }
            Feld = new int[2, AnzahlScheiben];
            for(int i=0;i<AnzahlScheiben;i++)
            {
                if(Startturm=="A")
                {
                    _start = 0;
                    Feld[0, i] = 1;
                }
                if (Startturm == "B")
                {
                    _start = 1;
                    Feld[1, i] = 1;
                }
                if (Startturm == "C")
                {
                    _start = 2;
                    Feld[2, i] = 1;
                }
            }
            Console.WriteLine("Damit werden {0} Scheiben von Turm {1} nach Turm {2} ueber Turm {3} geschoben...", AnzahlScheiben, Startturm, Zielturm, ueber);

            System.Threading.Thread.Sleep(100);

            //Anzeigen der Tuerme



            Console.ReadKey();
        }

        //Der Algorithmus soll n Scheiben vom Turm A nach Turm C ueber den Turm B schieben.
        //Also muessen zuerst n-1 Scheiben von A nach B ueber C geschoben werden
        //Dann wird die Scheibe von A nach C geschoben
        //Als naechstes n-1 Scheiben vom Turm B nach Turm C ueber Turm A
        
        /// <summary>
        /// Schiebt Scheiben vom Startturm zum Zielturm
        /// </summary>
        /// <param name="Start">Starttum, wo die Scheiben am Anfang liegen</param>
        /// <param name="Ziel">Zielturm, wo die Scheiben zum Schluss liegen sollen</param>
        /// <param name="Ueber">Der Turm wo die Scheiben "zwischengleagert" werden</param>
        /// <param name="Anzahl">Anzahl der zu verschiebenden Scheiben</param>
        static void verschiebe(string Start, string Ziel, string Ueber, uint Anzahl)
        {
            if (Anzahl == 1)
            {
                schiebeEinTurm();
            }
            else
            {
                verschiebe(Start, Ueber, Ziel, Anzahl - 1);
                schiebeEinTurm();
                verschiebe(Ueber, Ziel, Start, Anzahl - 1);
            }
        }

        /// <summary>
        /// Schiebt die oberste Scheibe vom Startturm zum ersten freien Platz am Zielturm
        /// </summary>
        static void schiebeEinTurm()
        {
            bool quelleGefunden = false;
            uint posx = 0, posy = 0;
            for (uint i = AnzahlScheiben; quelleGefunden == true; i--)
            {
                if (Feld[_start, i] == 1)
                {
                    quelleGefunden = true;
                    posx = _start;
                    posy = i;
                }
            }
            //von Start nach Ziel schieben
            Feld[posx, posy] = 0;
            bool zielGefunden = false;

            for (uint i = 0; zielGefunden == true; i++)
            {
                if (Feld[_ziel, i] == 0)
                {
                    zielGefunden = true;
                    posx = _ziel;
                    posy = i;
                }
            }
        }
    }
}
