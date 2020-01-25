using System;
using System.Collections.Generic;

namespace CeaserCypher
{
    class Program
    {
        static void Main(string[] args)
        {
            //string message = "tqxxa yk zmyq ue dgbqdf mzp u my m bmddaf. u eqzp qymuxe fa ykeqxr ftmf oazfmuz hqdk zmefk ftuzse";
            Console.WriteLine("enter message to decrypt");
            string message = Console.ReadLine();
            Console.WriteLine("enter key:");
            message = message.ToLower();
            //int key = Convert.ToInt32(Console.ReadLine());
            //string encoded = Encypher(message, 46);
            //Console.WriteLine(encoded);
            
            //string decoded = Decypher(message, key);
            //Console.WriteLine(decoded + "\n\n\n");
            
            BruteForce(message);
            
            Console.WriteLine("Frequency Analysis \n\n\n" + FrequencyAnalysis(message));
            Console.ReadLine();


        }

        static string Decypher(string cypher, int key)
        {
            string decyphered = "";
            for (int x = 0; x < cypher.Length; x++)
            {
                
                if (Convert.ToInt32(cypher[x]) > 122 || Convert.ToInt32(cypher[x]) < 97)
                {
                    decyphered += cypher[x];
                }
                else if (Convert.ToInt32(cypher[x]) - key < 97)
                {
                    decyphered += Convert.ToChar(123 - (97 - (Convert.ToInt32(cypher[x]) - key)));

                }
                else
                {
                    decyphered += Convert.ToChar(Convert.ToInt32(cypher[x]) - key);
                }

            }
            return decyphered;
        }

        static string Encypher(string plainText, int key)
        {
            string encoded = "";

            for (int x = 0; x < plainText.Length; x++)
            {
                if (Convert.ToInt32(plainText[x]) > 122 || Convert.ToInt32(plainText[x]) < 97)
                {
                    encoded += plainText[x];
                }
                else if (Convert.ToChar(Convert.ToInt32(plainText[x]) + key) > 122)
                {
                    encoded += Convert.ToChar(96 + Convert.ToInt32(plainText[x]) + key - 122);
                }
                else
                {
                    encoded += Convert.ToChar(Convert.ToInt32(plainText[x]) + key);

                }
            }
            return encoded;
        }

        static void BruteForce(string cypher)
        {
            for (int x = 1; x < 26; x++)
            {
                Console.WriteLine(Decypher(cypher, x));
            }
        }

        static string FrequencyAnalysis(string cypher)
        {
            
            int[] frequency = new int[26];
            foreach (char letter in cypher)
            {
                if (char.IsLetter(letter))
                {
                    int index = Convert.ToInt32(letter) - 97;
                    frequency[index] += 1;
                }
            }
            int mostFrequentIndex = 0;

            for(int x = 0; x < 26; x++)
            {
                if (frequency[x] > frequency[mostFrequentIndex])
                {
                    mostFrequentIndex = x;
                }
            }
            int shift = 0;
            if (mostFrequentIndex + 97 - Convert.ToInt32('e') >= 0)
            {
                shift = mostFrequentIndex + 97 - Convert.ToInt32('e');
            }
            else
            {
                shift = mostFrequentIndex + 97 - Convert.ToInt32('e') + 26;
            }
            Console.WriteLine(shift);
            return Decypher(cypher, shift);

        

        }

        
    
    }
    
}
