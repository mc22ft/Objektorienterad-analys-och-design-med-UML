using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    public class Boat
    {

        private string _boatType;
        private double _boatLength;
        
        public Boat()
        {            
        }

        public string BoatType 
        {
            get
            {
                return _boatType;
            }

            set
            {
                int typeNr;
                if (value is string)
                {
                    _boatType = value;
                }
                else{
                switch (typeNr = Convert.ToInt32(value))
                {
                    case 1:
                            _boatType = "Segelbåt";                        
                        break;
                    case 2:
                            _boatType = "Motorseglare";                        
                        break;
                    case 3:                        
                            _boatType = "Motorbåt";
                        break;
                    case 4:                        
                            _boatType = "Kajak/Kanot";                        
                        break;
                    case 5:                        
                            _boatType = "Övrigt";
                        break;
                }  
                    }
            }            
        }

        public double BoatLength 
        {
            get
            {
                return _boatLength;
            }
            set
            {
                _boatLength = value;
            }     
        }


        
    }
        
}
