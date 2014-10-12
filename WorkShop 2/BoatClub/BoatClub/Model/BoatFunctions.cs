using BoatClub.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    class BoatFunctions
    {
        public void AddBoat(MemberList members)
        {
            var consoleView = new ConsoleView();
            Boat myBoat = new Boat();
            Member currentMember = new Member();

            Console.WriteLine("Skriv in det medlemsnumer som du ska registrera en ny båt på:");           
            currentMember = SharedMethods.ObjectFinder(members);            
            if (currentMember.BoatList == null)
            {
                currentMember.BoatList = new BoatList();
            }

            int index = members.Members.IndexOf(currentMember);
            consoleView.showBoatTypeAndLength();
            SharedMethods.AddBoatTypeAndLength(myBoat);
            currentMember.BoatList.Add(myBoat);
            members.Members.RemoveAt(index);
            members.Members.Insert(index, currentMember);
            consoleView.ContinueOnKeyPressed();
        }

        public void UpdateBoat(MemberList members)
        {
            var consoleView = new ConsoleView();
            Boat myBoat = new Boat();
            Member currentMember = new Member();            
            
            Console.WriteLine("Skriv in det medlemsnummer som du vill redigera en båt på.");
            currentMember = SharedMethods.ObjectFinder(members);  
            Console.WriteLine("Skriv in nummret på den båt du vill ändra på:");
            
            consoleView.showBoats(currentMember);
            int choise = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Du har valt att ändra på båt nr {0}", choise);
            int boatIndex = choise - 1;

            consoleView.showBoatTypeAndLength();
            SharedMethods.AddBoatTypeAndLength(myBoat);

            currentMember.BoatList.Add(myBoat);
            currentMember.BoatList.Boats.RemoveAt(boatIndex);
            Console.WriteLine("\nBåten har redigerats.");
            consoleView.ContinueOnKeyPressed();
                            
        }

        //Tar bort ett båt obj
        public void RemoveBoat(MemberList members)
        {
            var consoleView = new ConsoleView();
            Member removeBoatObj = new Member();
            Console.WriteLine("Skriv in det medlemsnummer som du ska radera en båt på:");
            while (true)
            {
                try
                {                    
                    removeBoatObj = SharedMethods.ObjectFinder(members);
                    int counter = 1;
                    Console.WriteLine("Välj nummer på den båt som ska raderas:");
                    foreach (Boat bObj in removeBoatObj.BoatList.Boats)
                    {
                        Console.WriteLine("{0}: {1} med längd {2}m", counter, bObj.BoatType, bObj.BoatLength);
                        counter++;
                    }
                    int choice = Convert.ToInt32(Console.ReadLine());
                    choice--;
                    removeBoatObj.BoatList.Boats.RemoveAt(choice);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ange ett giltigt nummer.");                    
                }                
            }
            Console.WriteLine("\nBåten har tagits bort.");
            consoleView.ContinueOnKeyPressed();            
        }
    }
}
