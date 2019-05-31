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
        public static void Speichern(string Wert, string Name)
        {
            StreamReader stream = new StreamReader(@"../../src/Highscore.txt");
            // Create a file to write to.
            while (stream.EndOfStream == false)
            {
                string line = stream.ReadLine();
            }
        }


        public static List<string> Lesen()
        {
            // Open the file to read from.
            
            int counter = 0;
            string line;
            List<string> Highscores = new List<string>();

            // Read the file and display it line by line.  
            StreamReader file = new StreamReader(@"../../src/Highscore.txt");
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
