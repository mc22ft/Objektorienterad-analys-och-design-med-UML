using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.Model;
using BoatClub.Serializer;
using BoatClub.View;

namespace BoatClub.Controller
{
    class Menu
    {
        public void run()
        {
            MemberList members = new MemberList();          
            
            var serializer = new SerializerXML();
           
            var listViews = new ListViews();
            var consoleView = new ConsoleView();
            var memberview = new MemberView();
            var boatview = new BoatView();

            members = serializer.SerializerXMLIsNullOrNot(members);            
            
            do
            {
                int choise = consoleView.GetMenuChoice();

                switch (choise)
                {
                    case 0:                        
                        Environment.Exit(0);
                        break;
                    case 1:
                        memberview.CreateMember(members);
                        break;
                    case 2:
                        memberview.ShowMember(members);                        
                        break;
                    case 3: 
                        memberview.UpDateMember(members);
                        break;
                    case 4:
                        memberview.RemoveMember(members);
                        break;
                    case 5:                     
                        boatview.AddBoat(members);
                        break;
                    case 6:
                        boatview.UpDateBoat(members);
                        break;
                    case 7:
                        boatview.RemoveBoat(members);
                        break;
                    case 8:
                        listViews.CompactList(members);
                        break;
                    case 9:
                        listViews.CompleteList(members);
                        break;
                }
                serializer.SerializeToXML(members);
                Console.Clear();

            } while (true);
            
        }        
        
    }
}
