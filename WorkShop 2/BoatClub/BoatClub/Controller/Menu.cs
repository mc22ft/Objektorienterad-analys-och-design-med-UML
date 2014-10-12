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
            var memberFunctions = new MemberFunction();
            var boatFunctions = new BoatFunctions();
            var listViews = new ListViews();
            var consoleView = new ConsoleView();

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
                        memberFunctions.CreateMember(members);                        
                        break;
                    case 2:                        
                        memberFunctions.GetMember(members);                                           
                        break;
                    case 3:                                                
                        memberFunctions.UpdateMember(members);
                        break;
                    case 4:
                        memberFunctions.RemoveMember(members);
                        break;
                    case 5:                            
                        boatFunctions.AddBoat(members);
                        break;
                    case 6:
                        boatFunctions.UpdateBoat(members);
                        break;
                    case 7:
                        boatFunctions.RemoveBoat(members);
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
