using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class GameIsEqualStrategy : IEqualStrategy
    {
        public bool IfEqual(Player a_player, Dealer a_dealer)
        {
            const int g_hitLimit = 17;
            
            if (a_player.CalcScore() >= g_hitLimit && a_player.CalcScore() == a_dealer.CalcScore())
            {
                return true;
            }
            
            return false;
        }
    }
}
