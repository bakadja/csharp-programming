using System;

namespace nombre_magique 
{
    class Program
    {
        static int NutzerEingabe(int min, int max)
        {
            int x = 0;
            do
            {
                Console.Write($"Geben Sie eine beliebige ganze Zahl zwichen zwichen {min} und {max} ein: ");
                string zahl = Console.ReadLine();
                //convert to int
                try
                {
                    x = Convert.ToInt32(zahl); 
                    if ((x >= min) && (x <= max)) { return x; }                       
                    else {Console.WriteLine($"Die Zahl muss zwichen {min} und {max} sein!");}
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try again!");
                    Console.WriteLine( );
                }
            } while (!((x >= min) && (x <= max))); 
            return x;
        }

        static void Main(string[] args)
        {
            const int MIN_WERT = 1;
            const int MAX_WERT = 10;

            //generation du nombre aleatoire
            Random rand = new Random();
            int MAGISCHE_ZAHL = rand.Next(MIN_WERT,MAX_WERT+1); 
            int x = MIN_WERT - 1; 
            const int MAX_VERSUCHT = 4;
            
            //comparaison & bloucle
            for (int i=1; i<=MAX_VERSUCHT ; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Versucht:{i}, rest:{MAX_VERSUCHT-i}");
                x = NutzerEingabe(MIN_WERT, MAX_WERT);
                if (x == MAGISCHE_ZAHL)
                {
                    Console.WriteLine();
                    Console.WriteLine("Bravo,du hast die magische Zahl gefunden!");
                    break;
                }
                else if (x < MAGISCHE_ZAHL) { Console.WriteLine($"Die magische Zahl ist groesser"); }
                else { Console.WriteLine("Die magische Zahl ist kleiner"); }
                if (i == MAX_VERSUCHT) 
                {
                    Console.WriteLine();
                    Console.WriteLine($"Ups,du hast leider Verloren und keine Versucht mehr, die magische Zahl war {MAGISCHE_ZAHL}!"); 
                }
            }
             
        }
    }
}
