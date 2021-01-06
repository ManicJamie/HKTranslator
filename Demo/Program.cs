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
                Console.WriteLine("Enter a scene name:");
                input = Console.ReadLine();
                Console.WriteLine("-> " + Translator.TranslateSceneName(input));
            }
        }
    }
}
