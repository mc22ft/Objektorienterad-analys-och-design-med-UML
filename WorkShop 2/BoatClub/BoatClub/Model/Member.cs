using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BoatClub.Model
{
    public class Member
    {
        //Namn Personnummer och ett unikt id

        private string _name;
        private int _socialNr;
        private int _memberId;        
        public BoatList BoatList;  

        public Member()
        {                       
        }

        public int MemberId
        {
            get
            {
                return _memberId;
            }
            set
            {
                _memberId = value;
            }
        }
        
        public string Name
        {            
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int SocialNr
        {
            get
            {
                return _socialNr;
            }
            set
            {
                _socialNr = value;
            }
        }
       
        public int SetMemberId(MemberList members)
        {
            int HighestNumber = 1;
            if (members.Members.Count == 0)
            {
                throw new InvalidOperationException("Empty list");
            }
            int maxNr = int.MinValue;
            foreach (Member type in members.Members)
            {
                if (type.MemberId > maxNr)
                {
                    maxNr = type.MemberId;
                    HighestNumber = maxNr;
                    HighestNumber++;
                }
            }
            return HighestNumber;
        }

        public void CreateMember(MemberList members, string Name, int SocialNr)
        {
            int MemberId = SetMemberId(members);
            Member currentMember = new Member();
            currentMember.MemberId = MemberId;
            currentMember.Name = Name;
            currentMember.SocialNr = SocialNr;
            
            members.Add(currentMember);
        }

        public Member ShowMember(MemberList members)
        {
            //Member currentMember = new Member();
            
            Member currentMember = ObjectFinder1(members);
            return currentMember;
        }        

        public void RemoveMember(MemberList members)
        {
            Member currentObject = new Member();
            currentObject = ObjectFinder1(members);
            members.Members.Remove(currentObject);            
        }

        public void UpDateMember(Member currentMember)
        {
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
                                currentMember.SocialNr = int.Parse(Console.ReadLine());
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
        }


        //Hämtar ett objekt
        public Member ObjectFinder1(MemberList members)
        {
            Member member = new Member();

            while (true)
            {
                try
                {

                    int IDtoFind = Convert.ToInt32(Console.ReadLine());
                    member = members.Members.Find(x => x.MemberId == IDtoFind);

                    if (member == null)
                    {
                        Console.WriteLine("\nHittade inte medlemen, försök igen.");
                    }
                    else
                    {
                        return member;
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Fel vid inmatning, försök igen.");
                }

            }
        }
    }
}