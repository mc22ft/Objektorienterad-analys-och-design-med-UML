using BoatClub.View;
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
                try
                {
                    typeNr = Convert.ToInt16(value);
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
                catch (Exception)
                {                    
                    _boatType = value;
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

        public void AddBoat(MemberList members)
        {
            Boat myBoat = new Boat();
            Member currentMember = new Member();
            var boatview = new BoatView();

            currentMember = currentMember.ObjectFinder1(members);
            if (currentMember.BoatList == null)
            {
                currentMember.BoatList = new BoatList();
            }

            int index = members.Members.IndexOf(currentMember);
            boatview.ShowBoatTypeAndLength();

            AddBoatTypeAndLength(myBoat);
            currentMember.BoatList.Add(myBoat);
            members.Members.RemoveAt(index);
            members.Members.Insert(index, currentMember);
        }
        public void UpDateBoat(Member currentMember, Boat currentBoat)
        {
            var boatview = new BoatView();
            boatview.ShowBoats(currentMember);
            int choise = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Du har valt att ändra på båt nr {0}", choise);
            int boatIndex = choise - 1;

            boatview.ShowBoatTypeAndLength();
            AddBoatTypeAndLength(currentBoat);

            currentMember.BoatList.Add(currentBoat);
            currentMember.BoatList.Boats.RemoveAt(boatIndex);
        }
        public void RemoveBoat(MemberList members)
        {
            Member currrentMember = new Member();
            while (true)
            {
                try
                {
                    currrentMember = currrentMember.ObjectFinder1(members);
                    int counter = 1;
                    Console.WriteLine("Välj nummer på den båt som ska raderas:");
                    foreach (Boat bObj in currrentMember.BoatList.Boats)
                    {
                        Console.WriteLine("{0}: {1} med längd {2}m", counter, bObj.BoatType, bObj.BoatLength);
                        counter++;
                    }
                    int choice = Convert.ToInt32(Console.ReadLine());
                    choice--;
                    currrentMember.BoatList.Boats.RemoveAt(choice);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ange ett giltigt nummer.");
                }
            }
        }

        public void AddBoatTypeAndLength(Boat boatObject)
        {
            while (true)
            {
                try
                {
                    int TypeNr = Convert.ToInt16(Console.ReadLine());
                    if (TypeNr >= 1 && TypeNr <= 5)
                    {
                        string BoatType = Convert.ToString(TypeNr);
                        boatObject.BoatType = BoatType;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Fel nummer i inmatningen, välj 1-5.");
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Fel i inmatning, försök igen.");
                }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Ange längden på båten i m.");
                    double BoatLength = Convert.ToDouble(Console.ReadLine());

                    boatObject.BoatLength = BoatLength;
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ange rätt inmatning i meter, försök igen.");
                }
            }
        }

        public int CountBoats(Member member)
        {
            int countBoat = 0;
            if (member.BoatList == null)
            {
                countBoat = 0;
            }
            else
            {
                countBoat = member.BoatList.Boats.Count();
            }
            return countBoat;
        }        
    }        
}
