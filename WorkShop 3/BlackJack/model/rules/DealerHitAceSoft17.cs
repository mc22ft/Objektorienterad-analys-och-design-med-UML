using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealerHitAceSoft17 : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(Player a_dealer)
        {
            //Regel för soft17 för dealer
            int d_score = a_dealer.CalcScore();
            if (d_score == g_hitLimit)
            {
                foreach (Card c in a_dealer.GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace && d_score >= g_hitLimit)
                    {                        
                        d_score -= 10;
                    }
                }
            }
            return d_score <= g_hitLimit;
        }
    }
}
