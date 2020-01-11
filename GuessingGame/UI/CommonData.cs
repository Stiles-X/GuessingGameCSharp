﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GuessingGame.UI
{
    class CommonData
    {
        public static readonly string help = "Usage: (h)elp, (v)ersion, (s)ingle, (m)ulti\n(a)bout, (l)icense, (q)uit, (e)xit";
        public static readonly string version = "0.0.0";
        public static readonly string license = "All rights reserved. (C) 2020.";
        public static readonly string about = "Developed by Github/Stiles-X\nA library for guessing games\nExtensible, and codable\nSampleUIAttached";
        public static readonly string not_found = $"Command not found.\n{help}";
        public static readonly string s = "Entering single-player game";
        public static readonly string m = "Entering multi-player game";
        public static readonly string AsciiLogoV = GetAsciiLogo("v" + CommonData.version);
        public static void ClearAsciiLogoV()
        {
            Console.Clear();
            Console.WriteLine(AsciiLogoV);
            Console.WriteLine("___________________________________________");
        }
        public static string GetAsciiLogo(string text = "")
        {
            return
                @"

   _____                     _             
  / ____|                   (_)            
 | |  __ _   _  ___  ___ ___ _ _ __   __ _ 
 | | |_ | | | |/ _ \/ __/ __| | '_ \ / _` |
 | |__| | |_| |  __/\__ \__ \ | | | | (_| |
  \_____|\__,_|\___||___/___/_|_| |_|\__, |
  / ____|                             __/ |
 | |  __  __ _ _ __ ___   ___        |___/ 
 | | |_ |/ _` | '_ ` _ \ / _ \             
 | |__| | (_| | | | | | |  __/             
  \_____|\__,_|_| |_| |_|\___|" + $"{text}    \n";
        }
        public static string input(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }
        public static int intput(string question)
        {
            string strAnswer = input(question);
            var s = strAnswer;
            if (strAnswer == "cls" | strAnswer == "clear") { ClearAsciiLogoV(); }
            if (s == "q" | s == "quit" | s == "e" | s == "exit") { throw new QuitException(); }
            bool CanParse = (int.TryParse(strAnswer, out int intAnswer));
            if (!CanParse)
            {
                return intput(question);
            } else
            {
                return intAnswer;
            }
        }
        public class QuitException : Exception
        {
            public QuitException() { }
            public QuitException(string message) : base(message) { }
        }
    }
}
