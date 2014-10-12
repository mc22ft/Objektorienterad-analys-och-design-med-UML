using BoatClub.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    class MemberFunction
    {
        public void CreateMember(MemberList members)
        {
            var consoleView = new ConsoleView();
            Member mObj = new Member();  
            
            mObj.setMemberId(members);
            
            Console.WriteLine("Skriv in ditt namn: ");
            mObj.Name = Console.ReadLine();
            
            Console.WriteLine("Skriv in ditt personummer: ");

            while (true)
            {
                try
                {
                    mObj.SocialNr = long.Parse(Console.ReadLine());                    
                    break; 
                }
                catch
                {
                    Console.WriteLine("Fel inmatning! Försök igen");
                }
            }                      
            members.Add(mObj);
            consoleView.ContinueOnKeyPressed();
        }

        public void GetMember(MemberList members)
        {
            var consoleView = new ConsoleView();
            Member currentMember = new Member();
            Console.WriteLine("Skriv in det medlemsnumer som du vill se:");

            currentMember = SharedMethods.ObjectFinder(members);
            Console.WriteLine("\nNamn: {0}", currentMember.Name);
            Console.WriteLine("MedlemsNr: {0}", currentMember.MemberId);
            Console.WriteLine("PersonNr: {0}", currentMember.SocialNr);

            consoleView.showBoats(currentMember);                    
            consoleView.ContinueOnKeyPressed();           
        }

        public void UpdateMember(MemberList members)
        {
            var consoleView = new ConsoleView();
            Member currentMember = new Member();

            Console.WriteLine("Skriv in det medlemsnumer som du vill redigera uppgifter på:");            
            currentMember = SharedMethods.ObjectFinder(members);

            Console.WriteLine("Skriv in nummret på det fält du vill ändra på:");            
            Console.WriteLine("1: {0}", currentMember.Name);
            Console.WriteLine("2: {0}", currentMember.SocialNr);
            int choise;
            while (true)
            {
                choise = Convert.ToInt32(Console.ReadLine());
                if (choise == 1 || choise == 2)
                {
                    if (choise == 1)
                    {
                        Console.WriteLine("Ändra {0} till: ", currentMember.Name);
                        currentMember.Name = Console.ReadLine();
                    }
                    if (choise == 2)
                    {
                        Console.WriteLine("Ändra {0} till: ", currentMember.SocialNr);

                        while (true)
                        {
                            try
                            {
                                currentMember.SocialNr = long.Parse(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Fel inmatning, försök igen");
                            }
                        }

                    }
                    break;
                }
                else
                {
                        Console.WriteLine("Fel inmatning, försök igen.");
                }
            }      
            consoleView.ContinueOnKeyPressed();
        }

        public void RemoveMember(MemberList members)
        {
            var consoleView = new ConsoleView();
            Member removeObj = new Member();
            Console.WriteLine("Skriv in det medlemsnumer som ska raderas:");
            removeObj = SharedMethods.ObjectFinder(members);
            members.Members.Remove(removeObj);
            consoleView.ContinueOnKeyPressed();
        }
    }
}
