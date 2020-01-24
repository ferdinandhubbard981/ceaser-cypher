﻿using System;
using System.Collections.Generic;

namespace CeaserCypher
{
    class Program
    {
        static void Main(string[] args)
        {
            //string message = "tqxxa yk zmyq ue dgbqdf mzp u my m bmddaf. u eqzp qymuxe fa ykeqxr ftmf oazfmuz hqdk zmefk ftuzse";
            string message = "my name is rupert and i send email to ";
            string encoded = Encypher(message, 46);
            //Console.WriteLine(encoded);
            
            string decoded = Decypher(message, 12);
            Console.WriteLine(decoded + "\n\n\n");
            
            BruteForce(encoded);
            
            //Console.WriteLine("Frequency Analysis \n\n\n" + FrequencyAnalysis(encoded));
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
                    decyphered += Convert.ToChar(122 - (97 - (Convert.ToInt32(cypher[x]) - key)));

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
                    encoded += Convert.ToChar(97 + Convert.ToInt32(plainText[x]) + key - 122);
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
            if (Convert.ToInt32(frequency[mostFrequentIndex]) - 101 < 0)
            {
                shift = Convert.ToInt32(frequency[mostFrequentIndex]) - 101 + 26;
            }
            else
            {
                shift = Convert.ToInt32(frequency[mostFrequentIndex]) - 101;
            }
            return Decypher(cypher, shift);

        

        }

        
    
    }
    
}