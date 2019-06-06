using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Supertetris
{
    /// <summary>
    /// Interaktionslogik für Benutzereingabe.xaml
    /// </summary>
    public partial class Benutzereingabe : Window
    {
        public Benutzereingabe()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show(Benutzername.Text);
            Spieler.Username = Benutzername.Text;
            DirectoryInfo[] Dir = new DirectoryInfo(@"../../src/").GetDirectories();
            // Write each directory name to a file.
            using (StreamWriter sw = new StreamWriter("Highscore.txt"))
            {
                foreach (DirectoryInfo dir in Dir)
                {
                    sw.WriteLine(Benutzername.Text);

                }
            }
            //MessageBox.Show(Benutzername.Text);
            Spiel sp = new Spiel();
            MessageBox.Show(Spieler.Username);
            sp.Show();
            Close();
        }
    }
}
