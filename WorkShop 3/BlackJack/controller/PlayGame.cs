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


            //PlayShoice input = a_view.GetMenyInput();

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
            //Missupfattade regeln där lite. In i view sen tillbaka
            //int input = a_view.GetInput();

            //Försökte att typovandla input till enum för att sedan köra en switch/case
            
            //string s = ((char)input).ToString();
            //var c = Convert.ToChar(((char)a_view.GetInput()).ToString()); //Ej med typovandlingen
            //PlayShoice MyStatus = (PlayShoice)Enum.Parse(typeof(PlayShoice), s);
                       
            
            //if (input == (char)PlayShoice.PlayNewGame)                      //Lägg till enoum i IView ?? eller ?
            //{
            //    a_game.NewGame();
            //}
            //else if (input == (char)PlayShoice.Hit)
            //{
            //    a_game.Hit();
            //}
            //else if (input == (char)PlayShoice.Stand)
            //{
            //    a_game.Stand();                                             //Väljer att stanna!
            //}
            //return input != (char)PlayShoice.Quit;
             
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
            //try
            //{
                Thread.Sleep(2000);
                GameOn();
            //}
            //catch (Exception e)
            //{
            //}
        }
    }

    //public enum PlayShoice
    //{
    //    PlayNewGame = 'p',
    //    Hit = 'h',
    //    Stand = 's',
    //    Quit = 'q'
    //};


}
