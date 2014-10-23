using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IEqualStrategy m_EqualRule;
        
        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_EqualRule = a_rulesFactory.GetEqualRule();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {

                //m_hitRule.GetNewCard(a_player, Deck m_deck);

                var c = GetNewCard();

                //Card c;
                //c = m_deck.GetCard();
                //c.Show(true);
                //a_player.
                DealCard(c);

                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {


            //Vem vinner vid lika???


            //m_EqualRule.IfEqual(this);


            if (m_EqualRule.IfEqual(this))
            {
                //true = Dealer winner
                //false = player winner
                return true; 
            }

            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (CalcScore() > g_maxScore)
            {
                return false;
            }
            return CalcScore() >= a_player.CalcScore();
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }





        //Min implentation

        public bool Stand()
        {
            if (m_deck != null)
            {   
                //Visar player hand
                ShowHand();                

                //Loopar igenom handen
                foreach (var hand in GetHand())
                {
                    hand.Show(true);
                }

                //
                while (m_hitRule.DoHit(this))
                {
                    m_hitRule.DoHit(this);
                    var c = GetNewCard();
                    //Card c = m_deck.GetCard();
                    //c.Show(true);                    
                    DealCard(c);
                }
            }
            return true;
        }




        private Card GetNewCard()
        {
            Card c;
            c = m_deck.GetCard();
            c.Show(true);
            //a_player.DealCard(c);
            return c;
        }





    }
}
