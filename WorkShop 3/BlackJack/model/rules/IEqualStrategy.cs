using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IEqualStrategy
    {
        bool IfEqual(Player a_player);
    }
}
