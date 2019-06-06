using System;
using System.Collections.Generic;
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
            //MessageBox.Show(Benutzername.Text);
            Spiel sp = new Spiel();
            sp.Oeffnen();
            Close();
        }
    }
}
