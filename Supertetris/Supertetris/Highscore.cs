using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Supertetris
{
    class Highscore
    {
        public static void Speichern(string Wert)
        {
            string path = @"../../src/Highscore.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(Wert);
                }
            }
        }


        public static List<string> Lesen()
        {
            string path = @"../../src/Highscore.txt";
            // Open the file to read from.
            
            int counter = 0;
            string line;
            List<string> Highscores = new List<string>();

            // Read the file and display it line by line.  
            StreamReader file =
                new StreamReader(@"../../src/Highscore.txt");
            while ((line = file.ReadLine()) != null)
            {
                Highscores.Add(line);
                counter++;
            }

            file.Close();
            return Highscores;
        }
    }
}
