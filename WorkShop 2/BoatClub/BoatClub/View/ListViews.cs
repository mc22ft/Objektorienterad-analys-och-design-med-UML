using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoatClub.Model;


namespace BoatClub.View
{
    class ListViews : ConsoleView
    {        
        public void CompactList(MemberList members)
        {
            var boat = new Boat();
            foreach (Member mObject in members.Members)
            {
                int boatCount = boat.CountBoats(mObject);
                Console.WriteLine("\nName: {0} MedlemsNr: {1} Antal båtar: {2}"
                      , mObject.Name, mObject.MemberId, boatCount);
            }
            ContinueOnKeyPressed();            
        }
                
        public void CompleteList(MemberList members)
        {
            var boat = new Boat();
            foreach (Member mObject in members.Members)
            {
                int boatCount = boat.CountBoats(mObject);
                Console.WriteLine("\nName: {0} PersonNr: {1} Medlemsnummer: {2} Antal båtar: {3}"
                     , mObject.Name, mObject.SocialNr, mObject.MemberId, boatCount);
                if (boatCount != 0)
                {
                    var boatview = new BoatView();
                    boatview.ShowBoats(mObject);                    
                }
            }
            ContinueOnKeyPressed();
        }
    }
}
