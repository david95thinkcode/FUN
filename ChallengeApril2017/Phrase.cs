using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChallengeApril2017
{
    
    class Phrase
    {
        public int numberOfVowels { get; set; }
        public int numberOfConsonant { get; set; }
        public char[] tabVowels = {'a','e','i','o','u','y' };
        public char[] tabConsonant = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
        /// <summary>
        /// Contient chaque voyelle de la phrase 
        /// </summary>
        string[,] eachVowel;
        /// <summary>
        /// Contient chaque consonne de la phrase 
        /// </summary>
        /// 
        string[,] eachConsonant;

        public Phrase(String somePhrase)
        {
            numberOfVowels = 0;
            numberOfConsonant = 0;

            if (somePhrase.Length == 0)
            {
                Console.WriteLine("Expression vide ");
            }
            else
            {
                char[] splitedPhrase = new char[somePhrase.Length];
                //Console.WriteLine("Nombre de caractères : {0} \n", somePhrase.Count());
                int indexOFCounter = 0;
                int v = 0,
                    c = 0;

                /**
                 * Pour des soucis de mémoire, on compte d'abords le nombre de voyelles et de consonnes
                 * On construit un tableau avec le nombre de string pour recupérer les voyelles,
                 * On construit un tableau avec le nombre de string pour recupérer les voyelles
                 */
                int h = 0; //Va servir à parcourir chaque caractère de la phrase
                while (h < somePhrase.Length)
                {
                    if (tabVowels.Contains(somePhrase.ElementAt(h)))
                    {
                        numberOfVowels++;
                    }
                    else if (tabConsonant.Contains(somePhrase.ElementAt(h)))
                    {
                        numberOfConsonant++;
                    }
                    h++;
                }


                /**  On définie une taille pour eachVowel et eachConsonnant
                 * le tableau eachVowel aura une lenght égale à numberOfVowel
                 * le tableau eachConsonnant aura une lenght égale à numberOfConsonnant
                 */
                
                eachVowel = new string[2, numberOfVowels];
                eachConsonant = new string[2, numberOfConsonant];

                //On place chaque caractère de somePhrase dans chaque cellule de splitedPhrase
                while (indexOFCounter < somePhrase.Length)
                {
                    splitedPhrase[indexOFCounter] = somePhrase.ElementAt(indexOFCounter);

                    /** Remplissage eachVowels et eachConsonnant
                     * ///////////////////////////////
                     * Si splitPhrase[indexOFCounter] une voyelle, on l'ajoute à eachVowel... 
                     * Si splitPhrase[indexOFCounter] une consonne, on l'ajoute à eachConsonnant... 
                     */
                if (tabVowels.Contains(splitedPhrase[indexOFCounter]))
                    {
                        //On enregistre la voyelle et son index
                        eachVowel[0, v] = string.Concat(splitedPhrase[indexOFCounter]);
                        eachVowel[1, v] = string.Concat(indexOFCounter); //Convertion de indexofCounter (int) en string
                        
                        v++; //Passe à la cellule suivante de eachVowel
                    }

                    //Remplissage de eachConsonnant
                    else if (tabConsonant.Contains(splitedPhrase[indexOFCounter]))
                    {
                        eachConsonant[0, c] = string.Concat(splitedPhrase[indexOFCounter]);
                        eachConsonant[1, c] = string.Concat(indexOFCounter); //Convertion de indexofCounter (int) en string

                        c++; //Passe à la cellule suivante de eachConsonant
                    }

                    indexOFCounter++; 
                }
            }
         
        }

        public void showVowels()
        {
            int i = 0;
            Console.WriteLine("\nNombre de voyelles : {0} \n", numberOfVowels);
            Console.Write("Voulez-vous plus de détails ? [O/n] ");
            char choicedetail = char.Parse((Console.ReadLine()).ToUpper()); //get user choice in a char
            Console.WriteLine(" ");

            //user want details
            if (choicedetail == 'O')
            {
                Console.WriteLine("Voici les voyelles : ");
                foreach (var item in eachVowel)
                {
                    //Console.WriteLine("  {0} -- {1}(èm) lettre", item.)
                    Console.Write(" {0} - ", item);
                }
            }
            else
            {

            }
            
        }

        public void showConsonant()
        {
            Console.WriteLine("\nNombre de consonnes : {0} \n", numberOfConsonant);
            Console.Write("Voulez-vous plus de détails ? [O/n] ");
            char choicedetail = char.Parse((Console.ReadLine()).ToUpper()); //get user choice in a char
            Console.WriteLine(" ");

            //user want details
            if (choicedetail == 'O')
            {
                Console.WriteLine("Voici les consonnes : ");
                foreach (var item in eachConsonant)
                {
                    //Console.WriteLine("  {0} -- {1}(èm) lettre", item.)
                    Console.Write(" {0} - ", item);
                }
            }
            else
            {

            }
        }

    }
}
