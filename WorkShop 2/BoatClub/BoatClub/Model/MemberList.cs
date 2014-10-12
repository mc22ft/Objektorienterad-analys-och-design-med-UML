using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoatClub.Model
{
    public class MemberList
    {        
        private List<Member> _members;

        //List konstruktor
        public MemberList()
        {
            _members = new List<Member>();            
        }

        //List property
        public List<Member> Members
        {
            get
            {
                return _members;
            }           
        }

        public void Add(Member obj)
        {
            _members.Add(obj);
        }

        
    }
}
