using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nefedov_SpellChecker
{
    class Program
    {
        static void Main()
        {
            //A user input of a dictionary.
            string dict;
            //A user input of a sentence.
            string sentence;
            //A maximum word length.
            int maxLength = 50;
            //A word separators.
            string[] separators = { " ", ",", ".", "!", "?", "\\", ";", ":", "[", "]", "(", ")" };
            string pattern = @"([ ,.!?\\;:\[\]\(\)])";

            //A user input of a dictionary (words from zero to fifty characters long). 
            do
            {
                Console.WriteLine("Write your dictionary (words from zero to fifty characters long):");
                dict = Console.ReadLine();
            }
            while (dict.Length == 0);

            string[] dictionary = dict.Split(separators, StringSplitOptions.None);
            for (int i = 0; i < dictionary.Length; i++)
                if (maxLength < dictionary[i].Length)
                    dictionary[i] = dictionary[i].Substring(0, maxLength);
            Console.WriteLine("===");

            //A user input of a sentence (words up to fifty characters long).
            Console.WriteLine("Write your sentence (words up to fifty characters long):");
            sentence = Console.ReadLine();

            string[] words = Regex.Split(sentence, pattern).Where(str => str.Length > 0).ToArray();
            for (int i = 0; i < words.Length; i++)
                if (maxLength < words[i].Length)
                    words[i] = words[i].Substring(0, maxLength);
            Console.WriteLine("===");

            //A spell checker.
            SpellChecker spellChecker = new();
            spellChecker.Check(dictionary, words, separators);

            //A spell check result.
            string result = string.Join("", words);
            if (result == "{?}")
                result = "Empty string";
            Console.WriteLine(result);

            // Writing results to a text file.
            Writer writer = new();
            writer.FileWriter(dict, sentence, result);
        }
    }
}
