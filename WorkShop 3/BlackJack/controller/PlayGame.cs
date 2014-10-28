using BlackJack.model;
using BlackJack.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame //: IObserver 
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
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            int input = a_view.GetInput();

            //Försökte att typovandla input till enum för att sedan köra en switch/case
            
            //string s = ((char)input).ToString();
            //var c = Convert.ToChar(((char)a_view.GetInput()).ToString()); //Ej med typovandlingen
            //PlayShoice MyStatus = (PlayShoice)Enum.Parse(typeof(PlayShoice), s);
                       
            
            if (input == (char)PlayShoice.PlayNewGame)                      //Lägg till enoum i IView ?? eller ?
            {
                a_game.NewGame();
            }
            else if (input == (char)PlayShoice.Hit)
            {
                a_game.Hit();
            }
            else if (input == (char)PlayShoice.Stand)
            {
                a_game.Stand();                                             //Väljer att stanna!
            }
            return input != (char)PlayShoice.Quit;
             
        }

        //Till obsserver funktionen
        //public void CardThrownUpDate()
        //{
        //    try
        //    {
        //        Thread.Sleep(2000);
        //    }
        //    catch (Exception e)
        //    {
        //    }
        //}
    }
    public enum PlayShoice
    {
        PlayNewGame = 'p',
        Hit = 'h',
        Stand = 's',
        Quit = 'q'
    };


}
