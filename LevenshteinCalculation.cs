namespace Nefedov_SpellChecker
{
    class LevenshteinCalculation
    {
        static int Minimum(int a, int b) => a < b ? a : b;
        static int Minimum(int a, int b, int c) => (a = a < b ? a : b) < c ? a : c;

        //The Levenshtein distance is a string metric for measuring the difference between two sequences (words).
        public static int LevenshteinDistance(string firstWord, string secondWord)
        {
            var n = firstWord.Length + 1;
            var m = secondWord.Length + 1;
            var matrixD = new int[n, m];

            //Deletion and insertion costs.
            const int deletionCost = 1;
            const int insertionCost = 1;

            //A matrix for the first word.
            for (var i = 0; i < n; i++)
            {
                matrixD[i, 0] = i;
            }

            //A matrix for the second word.
            for (var j = 0; j < m; j++)
            {
                matrixD[0, j] = j;
            }

            for (var i = 1; i < n; i++)
            {
                for (var j = 1; j < m; j++)
                {
                    //Substitution cost.
                    var substitutionCost = firstWord[i - 1] == secondWord[j - 1] ? 0 : 1;

                    //Minimum between delete, insert and replace operations.
                    matrixD[i, j] = Minimum(matrixD[i - 1, j] + deletionCost,      
                                            matrixD[i, j - 1] + insertionCost,         
                                            matrixD[i - 1, j - 1] + substitutionCost);

                    //Damerau–Levenshtein distance (taking into account the operation of transposition).
                    if (i > 1 && j > 1
                    && firstWord[i - 1] == secondWord[j - 2]
                    && firstWord[i - 2] == secondWord[j - 1])
                    {
                        matrixD[i, j] = Minimum(matrixD[i, j],
                                           matrixD[i - 2, j - 2] + substitutionCost);
                    }
                }
            }

            return matrixD[n - 1, m - 1];
        }
    }
}
