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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Supertetris
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer Timer;
        Spielfeld SF;
        static public Label Username1 { get; set; }
        public MainWindow()
        {
            

            //Test
            Highscore.Speichern("123", "Thomas");
            Highscore.Speichern("100", "Niki");
            foreach (var i in Highscore.Lesen())
            {
                MessageBox.Show(i);
            }

            Benutzereingabe bng = new Benutzereingabe();
            bng.Show();
            GamePause();


            //Content="Name" Height="56" Name="Username1" FontSize="28" FontWeight="Bold"
            //Username.Content = "";
            //Username.Height = 56;
            //Username.FontSize = 28;
            //Username1 = Username;
        }
        public void Oeffnen()
        {
            MainWindow ofn = new MainWindow();
            ofn.Show();
            Username.Content = Spieler.Username;
        }
        void MainWindow_Initilized(object sender, EventArgs e)
        {
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(timer);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 400);
            Gamestart();
        }
        private void Gamestart()
        {
            MainGrid.Children.Clear();
            SF = new Spielfeld(MainGrid);
            Timer.Start();
        }
        private void GamePause()
        {
            if (Timer.IsEnabled)
            {
                Timer.Stop();
            }
            else Timer.Start();
        }
        private void timer(object sender, EventArgs e)
        {
            Scores.Content = SF.getScore().ToString("00000");
            Lines.Content = SF.getScore().ToString("00000");
            SF.CurrFigurMovDown();

        }
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    if (Timer.IsEnabled)
                    {
                        SF.CurrFigurMovLeft();
                    }
                    break;
                case Key.Right:
                    if (Timer.IsEnabled)
                    {
                        SF.CurrFigurMovRight();
                    }
                    break;
                case Key.Down:
                    if (Timer.IsEnabled)
                    {
                        SF.CurrFigurMovDown();
                    }
                    break;
                case Key.Up:
                    if (Timer.IsEnabled)
                    {
                        SF.CurrFigurMovRotate();
                    }
                    break;
                case Key.S:
                    Gamestart();
                    break;
                case Key.P:
                    GamePause();
                    break;
                default:
                    break;
            }
        }
    }
}
