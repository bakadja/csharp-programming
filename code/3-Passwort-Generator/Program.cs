using System; 
using MesFonctions; 

namespace generateur_mot_de_passe
{
    class Program
    {
        enum NutzerAngabe
        {
            KLEINEBUCHSTABLE = 1,
            KLEINEBUCHSTABLE_UND_GROSSEBUCHSTABLE,
            ZEICHEN_UND_ZIFFERN,
            ZEICHEN_ZIFFERN_UND_SONDERZEICHEN   //4
        }
        static void Main(string[] args)
        {
            //Frage stellen
            int laenge_passwort = Outils.FrageNachPositivNichtNullZahl("laenge des Passworts: ");
            Console.WriteLine();
            NutzerAngabe wahl = (NutzerAngabe)Outils.FrageNachEingebeneZahl("Wollen Sie ein Passwort mit:\n" +
                "1- nur kleinen Buchstablen\n" +
                "2-kleinen- und grossen Buchstablen\n" +
                "3-Zeichen und Ziffern\n" +
                "4-Zeichen,Ziffern und Sonderzeichen: \n" +
                "Ihre Wahl : ", 1, 4); 

            // zufälliges passwort
            string k_buchstable = "abcdefghijklmnopqrstuvwxyz";  // kleine buchstable index[0-25]
            string g_buchstable = k_buchstable.ToUpper();     // kleine buchstäbliche Zeichen in Großbuchstaben umwandeln
            string ziffern = "0123456789";
            string sonderzeichen = "#$%&€§+-*/";
            string alphabet = "";
            switch (wahl)
            {
                case NutzerAngabe.KLEINEBUCHSTABLE:
                    alphabet = k_buchstable;
                    break;

                case NutzerAngabe.KLEINEBUCHSTABLE_UND_GROSSEBUCHSTABLE:
                    alphabet = k_buchstable + g_buchstable;  
                    break;

                case NutzerAngabe.ZEICHEN_UND_ZIFFERN:
                    alphabet = k_buchstable + g_buchstable + ziffern;
                    break;

                case NutzerAngabe.ZEICHEN_ZIFFERN_UND_SONDERZEICHEN:
                    alphabet = k_buchstable + g_buchstable + ziffern + sonderzeichen;
                    break;

                default:
                    break;
            }
            Random rand = new Random();  
            int l_alphabet = alphabet.Length; // länge alphabet 

            //Schleife über die Länge des Passworts und mehrere Passwörter erstellen
            const int ANZAHLPASWORT = 10;
            for (int j = 0; j < ANZAHLPASWORT; j++)
            {
                string passwort = "";
                for (int i = 0; i < laenge_passwort; i++)
                {
                    int index = rand.Next(0, l_alphabet);
                    passwort += alphabet[index];                // passwort = passwort + alphabet[index]  
                }
                Console.WriteLine("Passwort: " + passwort);
            }
            Console.WriteLine();
        }
    }
}