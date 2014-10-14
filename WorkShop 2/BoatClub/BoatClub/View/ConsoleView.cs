using BoatClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoatClub.View
{
    class ConsoleView
    {
        public int GetMenuChoice()
        {                           
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("             Båtklubben                     ");
            Console.WriteLine("--------------------------------------------");
            Console.ResetColor();

            Console.WriteLine("\n0. Spara och Avsluta.\n");

            Console.WriteLine("- Medlem -");
            Console.WriteLine("1. Lägg till en medlem.");
            Console.WriteLine("2. Titta på en specifik medlems uppgifter.");
            Console.WriteLine("3. Ändra en medlems uppgifter.");
            Console.WriteLine("4. Ta bort en medlem.\n");

            Console.WriteLine("- Båt -");
            Console.WriteLine("5. Registrera en ny båt på en medlem med båttyp och längd.");
            Console.WriteLine("6. Redigera en båt.");
            Console.WriteLine("7. Ta bort en båt.\n");

            Console.WriteLine("- Listor -");
            Console.WriteLine("8. “kompakt lista” Namn, medlemsnummer och antal båtar.");
            Console.WriteLine("9. “fullständig lista” Namn, personnummer, medlemsnummer och båtinformation.");

            Console.WriteLine("\n-------------------------------------------\n");

            int choise = 0;
            do
            {
                Console.Write("Ange menyval [0-9]: ");
                if (int.TryParse(Console.ReadLine(), out choise) && choise >= 0 && choise <= 9)
                {
                    return choise;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\nDu måste ange ett nummer mellan 0-9, försök igen.\n");
                    Console.ResetColor();
                }
            }
            while (true);
        }

        public void ContinueOnKeyPressed()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n       Tryck tangent för att fortsätta        ");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
            return;
        }
        
    }
}
