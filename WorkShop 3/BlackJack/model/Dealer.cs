﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player//, ISubject
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;
        private List<IObserver> m_subscribers;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IEqualStrategy m_EqualRule;
        
        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_EqualRule = a_rulesFactory.GetEqualRule();
            m_subscribers = new List<IObserver>();
        }

        public void Register(IObserver a_subscriber)
        {
            m_subscribers.Add(a_subscriber);
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(this, a_player); //m_deck,   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {                
                GetNewCard(a_player, true);                

                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player, Dealer a_dealer)
        {
            //Vem vinner vid lika???            
            if (m_EqualRule.IfEqual(a_player, a_dealer))
            {
                //return true = Dealer is winner at equal over 17
                //return false = player is winner at equal over 17
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
                ShowHand();           

                foreach (var hand in GetHand())
                {
                    hand.Show(true);
                }
                
                while (m_hitRule.DoHit(this))
                {                   
                    GetNewCard(this, true);                   
                }
            }
            return true;
        }
        
        public void GetNewCard(Player a_player, bool x)
        {
            
            Card c = m_deck.GetCard();
            c.Show(x);
            a_player.DealCard(c);
            
            Notify(); //Observer
            
        }
        
        public void Notify()
        {
            foreach (var subscriber in m_subscribers)
            {
                subscriber.UpDate();
            }
        }
        
    }
}
