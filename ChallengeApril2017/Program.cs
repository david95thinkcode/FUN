using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChallengeApril2017
{
    class Program
    {
        public static SoundPlayer player = new SoundPlayer(@"../../RequiredFiles/Keyboard-Sound.wav");

        static void Main(string[] args)
        {
            showHead();
            bool restart = true;

            while (restart) 
            {
                Console.Clear();
                Console.WriteLine("Tapez un mot ou une phrase ci-dessous ");
                //user text will be yellow
                Console.ForegroundColor = ConsoleColor.Yellow;
                string expression = Console.ReadLine();
                Phrase somePhrase = new Phrase(expression);
                Console.ResetColor();

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("MENU");
                Console.WriteLine("1 - Afficher nombre de voyelles");
                Console.WriteLine("2 - Afficher nombre de consonnes");
                Console.WriteLine("N'importe quoi pour quitter\n");
                Console.ResetColor();

                Console.Write("Votre choix : ");
                try
                {
                    int choix = int.Parse(Console.ReadLine());

                    switch (choix)
                    {
                        case 1:
                            somePhrase.showVowels();
                            break;
                        case 2:
                            somePhrase.showConsonant();
                            break;
                        default:
                            break;
                    }
                }
                catch (System.FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mauvaise entrée, vous devez obligatoire entrer un chiffre !!");
                    restart = false;
                    Console.ResetColor();
                }

                //Reprendre ????
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n\nReprendre avec un autre mot ou une autre phrase ? [O/n] : ");
                Console.ResetColor();
                try
                {
                    char srestart = Char.Parse(Console.ReadLine());
                    if (srestart == 'o' || srestart == '0')
                        restart = true;
                    else
                        restart = false;
                }
                catch (System.FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Mauvaise entrée, vous devez obligatoire entrer une lettre entre O et N !!");
                    restart = false;
                    Console.ResetColor();
                }
                
            }

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
            Console.WriteLine("CHALLENGE NUMBER 1\n");            
            Console.ForegroundColor = ConsoleColor.Yellow;
            //On gère lorsque le fichier à jouer n'est pas trouvé
            try
            {
                player.PlayLooping();
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("\nFichier WAV non trouvé");
            }
            

            string presentation = "\nCe programme compte le nombre de voyelles et de consonnes dans une expressions ! ";
            writeSlowly(presentation);
            presentation = "\n -- Réalisé par : david95thinkcode";
            

            writeSlowly(presentation);
            
            presentation = "\n -- Version 1.0\n";
            writeSlowly(presentation);
            player.Stop();

            Console.WriteLine("\n##################################################\n");
            Console.WriteLine("\nCe message s'effacera dans 3 secondes");
            Thread.Sleep(5000);
            
            Console.ResetColor();
        }

        /// <summary>
        /// Ecris lentement du texte à l'écran
        /// </summary>
        /// <param name="texte"></param>
        static void writeSlowly(string texte)
        {
            int i = 0;
            char[] splitedText = new char[texte.Length];

            while (i < texte.Length)
            {
                splitedText[i] = texte.ElementAt(i);
                i++;
            }
            
            foreach (var item in texte)
            {
                Console.Write(item);
                Thread.Sleep(50);
            }
            
        }
    }
}
