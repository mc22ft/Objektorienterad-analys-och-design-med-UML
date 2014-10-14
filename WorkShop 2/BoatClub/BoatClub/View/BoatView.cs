using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.Model;

namespace BoatClub.View
{
    class BoatView : ConsoleView
    {
        public void AddBoat(MemberList members)
        {
            Console.WriteLine("Skriv in det medlemsnumer som du ska registrera en ny båt på:");

            var boat = new Boat();
            boat.AddBoat(members);
            Console.WriteLine("\nDu har lagt till en båt.");
            ContinueOnKeyPressed();
        }

        public void UpDateBoat(MemberList members)
        {            
            Boat currentBoat = new Boat();
            Member currentMember = new Member();

            Console.WriteLine("Skriv in det medlemsnummer som du vill redigera en båt på.");
            currentMember = currentMember.ObjectFinder1(members);
            Console.WriteLine("Skriv in nummret på den båt du vill ändra på:");

            currentBoat.UpDateBoat(currentMember, currentBoat);      

            Console.WriteLine("\nDu har redigerat en båt.");
            ContinueOnKeyPressed();
        }

        public void RemoveBoat(MemberList members)
        {
            Boat currentBoat = new Boat();
            
            Console.WriteLine("Skriv in det medlemsnummer som du ska radera en båt på:");

            currentBoat.RemoveBoat(members);
           
            Console.WriteLine("\nDu har readerat en båt.");
            ContinueOnKeyPressed();       
        }

        public void ShowBoatTypeAndLength()
        {
            Console.WriteLine("Lägg till en båt typ:");
            Console.WriteLine("1 = Segelbåt");
            Console.WriteLine("2 = Motorseglare");
            Console.WriteLine("3 = Motorbåt");
            Console.WriteLine("4 = Kajak/Kanot");
            Console.WriteLine("5 = Övrigt");
        }

        public void ShowBoats(Member mObject)
        {
            var consoleView = new ConsoleView();
            int counter = 1;
            try
            {
                if (mObject.BoatList.Boats == null) { }
                foreach (Boat bObject in mObject.BoatList.Boats)
                {
                    Console.WriteLine("-------{0}--------", counter);
                    Console.WriteLine(bObject.BoatType);
                    Console.WriteLine("{0}m", bObject.BoatLength);
                    counter++;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nDet finns ingen båt på denna medlem.");
                ContinueOnKeyPressed();
                consoleView.GetMenuChoice();
            }
        }
    }
}
