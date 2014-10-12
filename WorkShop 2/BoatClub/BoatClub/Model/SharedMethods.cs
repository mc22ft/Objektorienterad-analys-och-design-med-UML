using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoatClub.Model
{
    class SharedMethods
    {              

        //funktion som returnerar ett Member obj
        public static Member ObjectFinder(MemberList members)
        {
            Member member = new Member();

            while (true)
            {
                try
                {
                    
                    int IDtoFind = Convert.ToInt32(Console.ReadLine());
                    if (IDtoFind < 0 || IDtoFind > members.Members.Count())
                    {
                        Console.WriteLine("\nHittade inte medlemen, försök igen.");
                    }
                    else
                    {
                        foreach (Member item in members.Members)
                        {
                            if (item.MemberId == IDtoFind)
                            {
                                member = item;
                                break;
                            }
                        }
                        return member;
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Fel vid inmatning, försök igen.");
                }
                
            }                 
        }

        public static int CountBoats(Member member)
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

       public static void AddBoatTypeAndLength(Boat boatObject)
        {
            while (true) //IF satis
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
    }
}
