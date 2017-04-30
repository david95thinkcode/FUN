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
        /// Contient chaque voyelle sans doublons contenu de la phrase et le nombre de fois trouvé
        /// </summary>
        public char[,] eachVowel = new char[2,6];
        /// <summary>
        /// Contient chaque consonne sans doublons contenu de la phrase 
        /// </summary>
        public char[] eachConsonant = new char[20];

        public Phrase()
        {

        }

        public Phrase(String somePhrase)
        {
            numberOfVowels = 0;
            numberOfConsonant = 0;
            
            if (somePhrase.Length == 0)
            {
                Console.WriteLine("Phrase invalide");
            }
            else
            {
                char[] splitedPhrase = new char[somePhrase.Length];
                Console.WriteLine("Nombre de caractères : {0} \n", somePhrase.Count());
                int indexOFCounter = 0;
                int v = 0,
                    c = 0,
                    evColonne = 0;

                //On place chaque caractère de somePhrase dans chaque cellule de splitedPhrase

                while (indexOFCounter < somePhrase.Length)
                {
                    splitedPhrase[indexOFCounter] = somePhrase.ElementAt(indexOFCounter);
                    //Console.WriteLine("SplitedTable[{0}] = {1}", indexOFCounter, (splitedPhrase[indexOFCounter]));

                    /**
                     * Si splitPhrase[indexOFCounter] une voyelle, on l'ajoute à eachVowel... 
                     * si et seulement si eachVowel ne le contient pas
                     * Si splitPhrase[indexOFCounter] une consonne, on l'ajoute à eachConsonnant... 
                     * si et seulement si eachConsonnant ne le contient pas
                     */
                    if (tabVowels.Contains(splitedPhrase[indexOFCounter]))
                    {
                        while (evColonne < tabVowels.Length) //On parcours eachVowels
                        {
                            Thread.Sleep(1000);
                            //Voyelle contenu dans le eachVowels ? Non ==> on ajoute, Oui ==> on incrémente son nombre
                            if (eachVowel[0, evColonne] == splitedPhrase[indexOFCounter])
                            {
                                eachVowel[1, evColonne]++;
                                Console.WriteLine(eachVowel[1, evColonne]);
                            }
                            else if (eachVowel[0, evColonne] != (splitedPhrase[indexOFCounter]))
                            {
                                eachVowel[0, v] = splitedPhrase[indexOFCounter];
                                Console.WriteLine("eachVowel[0, {0}] = {1} ", evColonne, eachVowel[0, evColonne]);
                                v++;
                            }

                            evColonne++; //on passe à la colonne suivante donc la voyelle suivante du tableau tabVowels
                        }
                        numberOfVowels++;
                        //evColonne = 0;
                        //v = 0;
                        
                    }

                    //Remplissage de eachConsonnant
                    else if (tabConsonant.Contains(splitedPhrase[indexOFCounter]))
                    {
                        
                        if (eachConsonant.Contains(splitedPhrase[indexOFCounter]))
                        {

                        }
                        else if (!(eachConsonant.Contains(splitedPhrase[indexOFCounter])))
                        {
                            eachConsonant[c] = splitedPhrase[indexOFCounter];
                            c++;
                        }
                        numberOfConsonant++;
                    }

                    indexOFCounter++;
                }
                /*
                //Recherche des voyelle                                             s
                foreach (var item in eachVowel)
                {
                    if (tabVowels.Contains(item))
                    {
                        Console.WriteLine("Voyelle trouvée :  {0} ", item);
                    }
                }
                */

                Console.WriteLine("\n");
                foreach (var items in eachConsonant)
                {
                    if (tabConsonant.Contains(items))
                    {
                        Console.WriteLine("Consonne trouvée :  {0} ", items);
                    }
                }

                Console.WriteLine("Nombre de voyelles = {0} ", numberOfVowels );
                Console.WriteLine("Nombre de consonnes = {0} ", numberOfConsonant);
            }
        }

        private int getConsonant()
        {

            return 0;
        }

        private int getVowels()
        {

            return 3;
        }

    }
}
