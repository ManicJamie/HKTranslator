using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HKTranslator;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        { 
            string input;
            while (true)
            {
                Console.WriteLine("Enter a scene or transition name:");
                input = Console.ReadLine();
                if (input.Contains("[")) Console.WriteLine("-> " + Translator.TranslateTransitionName(input));
                else Translator.TranslateSceneName(input);
            }
        }
    }
}
