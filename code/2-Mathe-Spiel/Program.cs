using System;

namespace jeux_de_math
{
    class Program
    {
        enum Operator
        {
            ADDITION=1,
            SUBTRAKTION,//2
            MULTIPLIKATION,//3
        }
        static bool Frage(int min, int max)
        {
            Random rand = new Random(); 
            int a = rand.Next(min, max + 1);  
            int b = rand.Next(min, max + 1);
            Operator zeichen =(Operator)rand.Next(1, 4); 
            bool loesung = true;
            int x = 0;
            string eingabe ="";
            bool test_while = true;
            while (test_while)
            {
                 switch (zeichen)
                 {
                     case Operator.ADDITION:
                         Console.Write($"{a} + {b} = ");
                         break;
                     case Operator.SUBTRAKTION:
                         Console.Write($"{a} - {b} = ");
                         break;
                     case Operator.MULTIPLIKATION:
                         Console.Write($"{a} x {b} = ");
                         break;
                     default:
                         Console.WriteLine("Falshe Operator");
                         break;
                 }
                eingabe = Console.ReadLine();
                // convert  to int
                try
                {
                    x = Convert.ToInt32(eingabe);
                    test_while = false;   
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("try again!");
                    Console.WriteLine();
                }
            }
            if ((a + b) == x || (a-b) == x || (a*b) == x ){loesung = true; } 
            else {loesung = false; }                                                       

            return loesung;
        }

        static void Main(string[] args)
        {
           const int MIN_WERTE = 1;
           const int MAX_WERTE = 10;
           const int FRAGE_ANZAHL = 6;
           int punkt = 0;

            //boucle for
            for (int i=0; i<FRAGE_ANZAHL; i++)
            {
                Console.WriteLine($"Frage n°{i+1}/{FRAGE_ANZAHL}");
                bool antwort = Frage(MIN_WERTE, MAX_WERTE);
                if (antwort)
                {
                    Console.WriteLine("richtige Antwort");
                    punkt++;
                }
                else { Console.WriteLine("falsche Antwort"); }
                Console.WriteLine();
            }
            //anzahl der punkt
             Console.WriteLine($"Anzahl der Punkten: {punkt}/{FRAGE_ANZAHL}");
            // bewertung
            int durschnitt = FRAGE_ANZAHL / 2;
            if (punkt == FRAGE_ANZAHL) { Console.WriteLine("ausgezeichnet"); }
            else if (punkt == 0) { Console.WriteLine("wiederholen Sie Mathematik"); }
            else if (punkt > durschnitt) { Console.WriteLine("nicht schlecht"); }
            else { Console.WriteLine("kann besser sein"); } 
           
        }
    }
}