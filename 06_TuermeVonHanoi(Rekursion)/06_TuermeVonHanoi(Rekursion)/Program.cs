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
        static int _xKonsole = 75;        //hier kann man die groese in y-Richtung des Konsolenfensters veraendern
        static int _yKonsole=20;         //hier kann man die groese in x-Richtung des Konsolenfensters bei der Simulatuon aendern
        static int[,] Feld;             //Array um die Position der Scheiben festzuhalten
        static int _start;            //speichert den Startturm als Zahl ab um besser arbeiten zu koennen
        static int _ziel;            //speichert den Zielturm als Zahl ab um besser arbeiten zu koennen
        static int AnzahlScheiben;  //hier wird beim einlesen die gewuenschte Anzahl der Scheiben gespeichert
        static int posTurmA, posTurmB, posTurmC;
        static void Main(string[] args)
        {
            #region Eingabe
            Console.WriteLine("Wieviele Scheiben möchten Sie verschieben?");
            while (!(int.TryParse(Console.ReadLine(), out AnzahlScheiben)))
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
                            _ziel = 1;
                            ueber = "C";
                            break;

                        case "C":
                            _ziel = 2;
                            ueber = "B";
                            break;
                    }
                    break;

                case "B":
                    switch (Zielturm)
                    {
                        case "A":
                            _ziel = 0;
                            ueber = "C";
                            break;

                        case "C":
                            _ziel = 2;
                            ueber = "A";
                            break;
                    }
                    break;

                case "C":
                    switch (Zielturm)
                    {
                        case "A":
                            _ziel = 0;
                            ueber = "B";
                            break;

                        case "B":
                            _ziel = 1;
                            ueber = "A";
                            break;
                    }
                    break;

            }
            Feld = new int[3, AnzahlScheiben];
            for(int i=0;i<AnzahlScheiben;i++)
            {
                if(Startturm=="A")
                {
                    _start = 0;
                    Feld[0, i] = (int)AnzahlScheiben-i;
                }
                if (Startturm == "B")
                {
                    _start = 1;
                    Feld[1, i] = (int)AnzahlScheiben-i;
                }
                if (Startturm == "C")
                {
                    _start = 2;
                    Feld[2, i] = (int)AnzahlScheiben-i;
                }
            }
            Console.WriteLine("Damit werden {0} Scheiben von Turm {1} nach Turm {2} ueber Turm {3} geschoben...", AnzahlScheiben, Startturm, Zielturm, ueber);
            #endregion

            System.Threading.Thread.Sleep(1000);

            Console.Clear();

            #region Verschieben
            //Zeicne als erstes alle Scheiben(Startsituation)
            zeichne();
            System.Threading.Thread.Sleep(50);

            verschiebe(Startturm, Zielturm, ueber, AnzahlScheiben);
            #endregion

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
        static void verschiebe(string A, string C, string B, int Anzahl)
        {
            if (Anzahl > 1)
            {
                verschiebe(A, B, C, Anzahl - 1);
                schiebeEinTurm(A,C);
                verschiebe(B, C, A, Anzahl - 1);
            }
            else 
            {
                schiebeEinTurm(A,C);
            }
        }

        /// <summary>
        /// Schiebt die oberste Scheibe vom Startturm zum ersten freien Platz am Zielturm
        /// </summary>
        static void schiebeEinTurm(string Start,string Ziel)
        {
            int start = 0, ziel = 0;

            switch (Start)
            {
                case "A":
                    start = 0;
                    break;

                case "B":
                    start = 1;
                    break;

                case "C":
                    start = 2;
                    break;
            }
            switch (Ziel)
            {
                case "A":
                    ziel = 0;
                    break;

                case "B":
                    ziel = 1;
                    break;

                case "C":
                    ziel = 2;
                    break;
            }

            bool quelleGefunden = false;
            int posx = 0, posy = 0, groesse = 0;
            
            //sucht die oberste Scheibe auf den Startturm
            for (int i = AnzahlScheiben-1; quelleGefunden == false; i--)
            {
                if (Feld[start, i] !=0)
                {
                    quelleGefunden = true;
                    posx = start;
                    posy = i;
                    groesse = Feld[start, i];
                }
            }
            Feld[posx, posy] = 0;       //loescht die Scheibe auf dieser Position

            bool zielGefunden = false;
            //den ersten freien Platz auf Zielturm
            for (int i = 0; zielGefunden == false; i++)
            {
                if (Feld[ziel, i] == 0)
                {
                    zielGefunden = true;
                    posx = ziel;
                    posy = i;
                }
            }
            Feld[posx, posy] = groesse;     //speichert die Scheibe auf der neuen Position

            // Zeichnet alle Scheiben neu
            zeichne();

            //Delay um die Simulation beobachten zu koennen
            System.Threading.Thread.Sleep(500);
        }

        /// <summary>
        /// Zeichnet die Scheuben auf die Tuerme laut dem Array Feld
        /// </summary>
        static void zeichne()
        {
            //Zuerst die alte Zeichnung loeschen
            Console.Clear();
            
            //Grundgereust neu zeichen
            grundgeruest();

            //scheiben an der Richtigen stelle Zeichen (Array -> Feld)
            zeichneScheiben();
        }

        /// <summary>
        /// Zeichnet das Grundgeruest auf die Console -> Namen der Tuerme und einen Strich oberhalb der Namen
        /// </summary>
        static void grundgeruest()
        {
            //setzt das Konsolenfenster auf eine Bestimmte größe -> Variablen
            Console.SetWindowSize(_xKonsole, _yKonsole);

            //schreibt die Namen der Türme am unteren Rand 
            Console.SetCursorPosition(5, (_yKonsole - 1));
            Console.Write("Turm A");
            posTurmA = Console.CursorLeft - 3;

            Console.SetCursorPosition((_xKonsole / 2) - 3, (_yKonsole - 1));
            Console.Write("Turm B");
            posTurmB = Console.CursorLeft - 3;


            Console.SetCursorPosition(_xKonsole - 10, _yKonsole - 1);
            Console.Write("Turm C");
            posTurmC = Console.CursorLeft - 3;

            //schreibt noch eine Zeile unterschtriche oberhalb der Namen
            Console.SetCursorPosition(0, _yKonsole - 2);
            for (int i = 0; i <= _xKonsole; i++)
            {
                Console.Write("_");
            }

        }

        /// <summary>
        /// Zeichnet die Scheiben mit *; eine Scheibe pro Zeile
        /// Die Methode zeichnet immer alle Scheiben neu
        /// </summary>
        static void zeichneScheiben()
        {
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < AnzahlScheiben; i++)
                {
                    if (Feld[j, i] != 0)
                    {
                        int breite = Feld[j, i];

                        switch (j)
                        {
                            case 0:
                                Console.SetCursorPosition(posTurmA - ((breite*2) / 2), _yKonsole - (i + 3));
                                for (int u = 0; u < breite; u++)
                                {
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.Write("  ");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                                break;

                            case 1:
                                Console.SetCursorPosition(posTurmB - ((breite*2) / 2), _yKonsole - (i + 3));
                                for (int u = 0; u < breite; u++)
                                {
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.Write("  ");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                                break;

                            case 2:
                                Console.SetCursorPosition(posTurmC - ((breite*2) / 2), _yKonsole - (i + 3));
                                for (int u = 0; u < breite; u++)
                                {
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.Write("  ");
                                    Console.BackgroundColor = ConsoleColor.Black;
                                }
                                break;

                        }


                    }
                }
            }
        }
    }
}
