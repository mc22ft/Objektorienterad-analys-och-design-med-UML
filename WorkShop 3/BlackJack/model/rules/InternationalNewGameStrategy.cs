﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {

        public bool NewGame(Dealer a_dealer, Player a_player) //Deck a_deck, 
        {



            a_dealer.GetNewCard(a_player, true);
            a_dealer.GetNewCard(a_dealer, true);
            a_dealer.GetNewCard(a_player, true);

            //Card c;

            //c = a_deck.GetCard();
            //c.Show(true);
            //a_player.DealCard(c);

            //c = a_deck.GetCard();
            //c.Show(true);
            //a_dealer.DealCard(c);

            //c = a_deck.GetCard();
            //c.Show(true);
            //a_player.DealCard(c);

            return true;
        }
    }
}
