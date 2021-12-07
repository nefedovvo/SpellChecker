using System;
using System.Collections.Generic;
using System.Linq;

namespace Nefedov_SpellChecker
{
    class SpellChecker
    {
        public void Check(string[] dictionary, string[] words, string[] separators)
        {
            //A list of corrections set (if more than one possible correction is left).
            List<string> correctionsSet = new();
            //A counter of possible corrections.
            int counter = 0;

            for (int i = 0; i < words.Length; i++)
            {
                //If a dictionary does not contain a word.
                if (!dictionary.Contains(words[i], StringComparer.InvariantCultureIgnoreCase))
                    for (int j = 0; j < dictionary.Length; j++)
                        if (LevenshteinCalculation.LevenshteinDistance(words[i].ToLower(), dictionary[j].ToLower()) == 1 && !separators.Contains(words[i]))
                        {
                            counter++;
                            correctionsSet.Add(dictionary[j]);
                        }

                //If no corrections can be found, print "{W?}".
                if (!dictionary.Contains(words[i], StringComparer.InvariantCultureIgnoreCase) && !separators.Contains(words[i]))
                    if (counter == 0)
                        words[i] = $"{{{words[i]}?}}";
                //If exactly one correction is left, print that word.
                if (counter == 1)
                    words[i] = correctionsSet[0];
                //If more than one possible correction is left, print the set of corrections as "{W1 W2 · · ·}".
                else if (counter > 0)
                    words[i] = $"{{{string.Join(" ", correctionsSet)}?}}";
                //Reset the counter and clear the correction set.
                counter = 0;
                correctionsSet.Clear();
            }
        }
    }
}
