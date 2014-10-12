using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    public class BoatList
    {
        private List<Boat> _boats; 
        //List konstruktor
        public BoatList()
        {
            _boats = new List<Boat>();            
        }

        //List property
        public List<Boat> Boats
        {
            get
            {
                return _boats;
            }           
        }

        public void Add(Boat obj)
        {
             _boats.Add(obj);
        }        
    }
}
