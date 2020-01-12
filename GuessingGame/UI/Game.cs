﻿using System;
using System.Collections.Generic;
using System.Text;
using GuessingGame.Core;

namespace GuessingGame.UI
{
    enum PlayerMode
    {
        s,
        m
    }
    class Game
    {
        private static void Guess(API api)
        {
            int answer = Misc.intput(
                    $"{api.GetLeftGuesses()} guesses left. Choose between (including) {api.GetMin()} and {api.GetMax()}: "
                    );
            if (api.GetLeftGuesses() > 0)
            {
                bool Correct = api.Guess(answer);
                if (Correct) { Console.WriteLine("Congratulations, you did it! Incredible job!"); }
                else { Guess(api); }
            }   else { Console.WriteLine("Sorry, you ran out of tries"); }
        }

        public static void FlexPlayer(PlayerMode playerMode)
        {
            Misc.ClearAsciiLogoV();
            API api = new API();
            try
            {
                api.SetMin(Misc.intput("Enter Min Number: "));
                api.SetMax(Misc.intput("Enter Max Number: "));
                api.SetAllowedGuesses(Misc.intput("Enter Number of Guesses: "));
                if (playerMode == PlayerMode.s)
                {
                    Console.WriteLine("Choosing correct answer randomly...");
                    api.SetCorrectRandom();
                }
                else if (playerMode == PlayerMode.m)
                {
                    api.SetCorrect(Misc.intput("Enter 'Correct' Number: "));
                }
                Guess(api);
                Console.ReadLine();
            } catch (Misc.QuitException) { }
            UI.Main(new string[0]);
        }
    }
}
