﻿using System;
using System.Collections.Generic;
using System.Text;
using GuessingGame.Core;

namespace GuessingGame
{
    class TestStart
    {
        public static void TestMain()
        {
            CoreGame game = new CoreGame
            {
                Min = 1,
                Max = 10,
                Correct = 5,
                AllowedGuesses = 5
            };
            GuessTest(game.Random(), game);
            GuessTest(game.Random(), game);
            GuessTest(game.Random(), game);
            Console.Read();
        }
        public static void GuessTest(int guess, CoreGame game)
        {
            Console.WriteLine($"We have {game.AllowedGuesses - game.UsedGuesses} guesses left!");
            bool correct = game.Guess(guess);
            Console.WriteLine($"We guessed {guess.ToString()} and the answer is {correct}!");
        }
    }
}
