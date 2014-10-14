using BoatClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.View
{
    class MemberView : ConsoleView
    {
        public void CreateMember(MemberList members)
        {
            string Name;
            int SocialNr;  
            
            while (true)
            {
                try
                {
                    Console.WriteLine("Skriv in ditt namn: ");
                    Name = Console.ReadLine();
                    break; 
                }
                catch
                {
                    Console.WriteLine("Fel inmatning! Försök igen");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Skriv in ditt personummer: ");
                    SocialNr = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Fel inmatning! Försök igen");
                }
            }

            var member = new Member();
            member.CreateMember(members, Name, SocialNr);

            Console.WriteLine("\nDu har lagt in en medlem.");
            ContinueOnKeyPressed();  
        }

        public void ShowMember(MemberList members)
        {          

            Console.WriteLine("Skriv in det medlemsnummer som du vill titta på:");
            var member = new Member();

            Member currentMember = member.ShowMember(members);            

            Console.WriteLine("\nNamn: {0}", currentMember.Name);
            Console.WriteLine("MedlemsNr: {0}", currentMember.MemberId);
            Console.WriteLine("PersonNr: {0}", currentMember.SocialNr);

            var boatView = new BoatView();
            boatView.ShowBoats(currentMember);  
                  
            ContinueOnKeyPressed();           
        }

        public void UpDateMember(MemberList members)
        {
            Member currentMember = new Member();
            Console.WriteLine("Skriv in det medlemsnummer som du vill redigera uppgifter på:");

            var member = new Member();
            currentMember = member.ObjectFinder1(members);

            Console.WriteLine("Skriv in nummret på det fält du vill ändra på:");
            Console.WriteLine("1: {0}", currentMember.Name);
            Console.WriteLine("2: {0}", currentMember.SocialNr);
            
            member.UpDateMember(currentMember);
            Console.WriteLine("\nDu har updaterat en medlem.");
            ContinueOnKeyPressed();
        }        

        public void RemoveMember(MemberList members)
        {            
            Console.WriteLine("Skriv in det medlemsnummer som ska raderas:");
            var member = new Member();
            member.RemoveMember(members);
            Console.WriteLine("\nDu har raderat en medlem.");
            ContinueOnKeyPressed();
        }
       
    }
}
