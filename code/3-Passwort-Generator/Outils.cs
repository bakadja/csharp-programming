using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesFonctions
{
	static class Outils
	{
        public static int FrageNachPositivNichtNullZahl(string frage) 
        {
            return FrageNachEingebeneZahl(frage, 1, int.MaxValue,"Fehler!, die Zahl musst positiv und nicht null sein ");
        }
        public static int FrageNachEingebeneZahl(String frage, int min, int max, string eigeneFehlerNachricht = null) // optionaler Parameter
        {
            int zahl = FrageNachZahl(frage);
            if ((zahl < min) || (zahl > max))
            {
                if (eigeneFehlerNachricht != null) { Console.WriteLine(eigeneFehlerNachricht); } 
                else { Console.WriteLine($"Fehler! Die eingebene Zahl muss zwischen {min} und {max} sein "); }
                Console.WriteLine(); 
            }    
            else { return zahl; } 
            return FrageNachEingebeneZahl(frage, min, max, eigeneFehlerNachricht);
        }
        public static int FrageNachZahl(string frage)
        {
            while (true)
            {
                Console.Write(frage);
                string antwort = Console.ReadLine();
                //convert to int 
                try
                {
                    int x = Convert.ToInt32(antwort);
                    return x;  
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ups,Try again!");
                    Console.WriteLine();
                }
            }
        }
    }
}


