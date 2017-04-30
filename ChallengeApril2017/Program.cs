using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApril2017
{
    class Program
    {
        static void Main(string[] args)
        {
            showHead();

            Console.WriteLine("Tapez un mot ou une phrase ci-dessous ");
            //user text will be yellow
            Console.ForegroundColor = ConsoleColor.Yellow;
            string expression = Console.ReadLine();
            Phrase somePhrase = new Phrase(expression);
            Console.ResetColor();
            somePhrase.showVowels();
            somePhrase.showConsonant();

            showFoot();
        }

        static void showFoot()
        {
            Console.ResetColor();
            Console.WriteLine("\n\n##################################################");
            Console.WriteLine("Fin du programme.\n");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("\nAppuyez sur une touche pour continuer... ");
            Console.ReadKey();
        }

        static void showHead()
        {
            Console.Title = "****** HOW MANY VOWELS AND CONSONANTS ******";
            Console.WriteLine("CHALLENGE NUMBER 1");
            Console.WriteLine("##################################################\n");

            Console.ResetColor();
        }
    }
}
