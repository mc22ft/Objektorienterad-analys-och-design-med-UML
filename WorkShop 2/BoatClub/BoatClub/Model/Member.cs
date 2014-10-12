using BoatClub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BoatClub
{
    public class Member
    {
        //Namn Personnummer och ett unikt id

        private string _name;
        private long _socialNr;
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
        public long SocialNr
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

       //Får ut det unika id och sätter det
        public void setMemberId(MemberList members)
        {            
            int HighestNumber = 1;
            foreach (Member obj in members.Members)
            {
                if (obj.MemberId >= HighestNumber)
                {
                    HighestNumber++;
                }
            }
            MemberId = HighestNumber;             
        }
    }
}