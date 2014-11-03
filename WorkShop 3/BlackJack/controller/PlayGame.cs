using BlackJack.model;
using BlackJack.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : IObserver 
    {
        private Game a_game;
        private IView a_view;

        public PlayGame(Game game, IView view)//
        {
            a_game = game;
            a_view = view;
        }

        public bool Play()//model.Game a_game, view.IView a_view
        {
            GameOn();            

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }
            
            //Meny val
            switch (a_view.GetMenyInput())
            {
                case PlayShoice.PlayNewGame:
                    a_game.NewGame();
                    break;
                case PlayShoice.Hit:
                    a_game.Hit();
                    break;
                case PlayShoice.Stand:
                    a_game.Stand();
                    break;
                case PlayShoice.Quit:
                    return false;
            }
            return true;           
        }

        private void GameOn()
        {
            a_view.DisplayWelcomeMessage();

            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());                        
        }

        //Till obsserver funktionen
        public void UpDate()
        {
            try
            {
                Thread.Sleep(2000);
                GameOn();
            }
            catch (Exception e)
            {
            }
        }
    } 
}
