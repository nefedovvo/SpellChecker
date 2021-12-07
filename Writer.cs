using System.IO;

namespace Nefedov_SpellChecker
{
    public class Writer
    {
        public void FileWriter(string dictionary, string sentence, string result)
        {
            // A file path and name.
            string directory = Directory.GetCurrentDirectory() + "\\Log";
            string fileName = directory + "\\" + "Nefedov_SpellChecker" + ".txt";

            // If the folder does not exist, it will create.
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            // Writing results to a text file.
            using (StreamWriter sw = new StreamWriter(fileName, true))
                sw.WriteLine("{0}\n===\n{1}\n===\n{2}\n", dictionary, sentence, result);
        }
    }
}
