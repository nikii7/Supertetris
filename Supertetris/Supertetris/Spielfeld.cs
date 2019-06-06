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

namespace Supertetris
{
    public class Spielfeld
    {
        private int Rows;
        private int Cols;
        private int Score;
        private int LinesFilled;
        private Figuren currTetramino;//Stein der gerade runterfällt
        private Label[,] Blockcontrols;//2D Array
        static private Brush NoBrush = Brushes.Transparent; // Static wenn multiplayer
        static private Brush SilverBrush = Brushes.Gray;//Sind fix

        public Spielfeld(Grid Spielifeldi)// Jede Zeile des Grids ein eigenes Label. Jedem Label einen Grauen Border(Raster). Konstruktor 
        {
            Rows = Spielifeldi.RowDefinitions.Count;//Schauen wie gros das grid ist
            Cols = Spielifeldi.ColumnDefinitions.Count;//Schauen wie gros das grid ist
            Score = 0;
            LinesFilled = 0;

            Blockcontrols = new Label[Cols, Rows]; // In jedem Grid feld eine Referenz auf label. Gut, da über array labels manipulieren.
            for (int i = 0; i < Cols; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    Blockcontrols[i, j] = new Label();//Initialisieren in jedem block ein label
                    Blockcontrols[i, j].Background = NoBrush;
                    Blockcontrols[i, j].BorderBrush = SilverBrush;
                    Blockcontrols[i, j].BorderThickness = new Thickness(1, 1, 1, 1);
                    Grid.SetRow(Blockcontrols[i, j], j);//Hier setzt man Referenzen von Labels in Zellen von Grid
                    Grid.SetColumn(Blockcontrols[i, j], i);//Hier setzen wir Referenzen von Labels in Zellen von Grid
                    Spielifeldi.Children.Add(Blockcontrols[i, j]);
                }
            }
            currTetramino = new Figuren();//Spielstein machen
            currFigurDraw();
        }
        public int getScore()
        {
            return Score;
        }
        public int getLines()
        {
            return LinesFilled;
        }
        private void currFigurDraw()
        {
            //Wo malen;
            Point Position = currTetramino.getCurrPosition();
            //Was malen?
            Point[] Shape = currTetramino.getCurrShape();
            // Farbe
            Brush Color = currTetramino.getCurrColor();

            foreach (Point S in Shape)
            {
                //Labels inerhalb Blockcontrol manipulirern. (int) macht double werte in int.
                //(Cols / 2) -1: damit neue steine in mitte sind.  + 2 Da 22 zeilen in die Höhe geht
                Blockcontrols[(int)(S.X + Position.X) + ((Cols / 2) - 1), (int)(S.Y + Position.Y) + 2].Background = Color;
            }
        }
        private void currFigurErase()
        {
            //Wo malen;
            Point Position = currTetramino.getCurrPosition();
            //Was malen?
            Point[] Shape = currTetramino.getCurrShape();

            foreach (Point S in Shape)
            {
                //Labels inerhalb Blockcontrol manipulirern. (int) macht doubble werte in int.
                //(Cols / 2) -1: damit neue steine in mitte sind.  + 2 Da 22 zeilen in die Höhe geht
                Blockcontrols[(int)(S.X + Position.X) + ((Cols / 2) - 1), (int)(S.Y + Position.Y) + 2].Background = NoBrush;
            }
        }
        private void CheckRows()
        {
            bool full;
            for (int i = Rows - 1; i > 0; i--)// Läuft grid von unten nach oben durch
            {
                full = true;//Gehen aus das jede Zeile voll ist
                for (int j = 0; j < Cols; j++) //geht reihe von links nach rechts durch
                {
                    if (Blockcontrols[j, i].Background == NoBrush)//schaut ob reihe voll ist
                    {
                        full = false;
                    }
                }
                if (full)
                {
                    RemoveRow(i);
                    Score += 100;
                    LinesFilled += 1;
                }
            }

        }
        private void RemoveRow(int row)//Übergibt aktuelle Zeile
        {
            for (int i = row; i > 2; i--)// 2 Da die oberen 2 zeilen(22) nicht ausgefüllt sind
            {
                for (int j = 0; j < Cols; j++)// geht von l nach r
                {
                    //Alle Zeilen gehen eins runter mit [j, i-1]
                    Blockcontrols[j, i].Background = Blockcontrols[j, i - 1].Background;
                }
            }
        }
        //Spiellogik:
        public void CurrFigurMovLeft()
        {
            Point position = currTetramino.getCurrPosition();
            Point[] Shape = currTetramino.getCurrShape();
            bool move = true;
            currFigurErase(); //Vereinfachung der SL. Muss nicht alles abfragen.
            foreach (Point S in Shape)
            {   //Schritt den wir machen ((int)(S.X + position.X) + ((Cols/2)-1)-1)
                if (((int)(S.X + position.X) + ((Cols / 2) - 1) - 1) < 0)//Checkt ob es OutOfRange ist
                {
                    move = false;
                }
                //Checkt ob was Farbiges im weg ist(Block)
                else if (Blockcontrols[((int)(S.X + position.X) + ((Cols / 2) - 1) - 1), (int)(S.Y + position.Y) + 2].Background != NoBrush)
                {
                    move = false;
                }
            }
            if (move)
            {
                currTetramino.movLeft();//Aktuelles Objekt nach links
                currFigurDraw();

            }
            else
            {
                currFigurDraw();
            }
        }
        public void CurrFigurMovRight()
        {
            Point position = currTetramino.getCurrPosition();
            Point[] Shape = currTetramino.getCurrShape();
            bool move = true;
            
            foreach (Point S in Shape)
            {   //Schritt den wir machen ((int)(S.X + position.X) + ((Cols/2)-1)-1)
                if (((int)(S.X + position.X) + ((Cols / 2) - 1) + 1) >= Cols)//Checkt ob es OutOfRange ist
                {
                    move = false;
                }
                //Checkt ob was Farbiges im wg ist(Block)
                else if (Blockcontrols[((int)(S.X + position.X) + ((Cols / 2) - 1) + 1), (int)(S.Y + position.Y) + 2].Background != NoBrush)
                {
                    move = false;
                }
            }
            
            if (move)
            {
                currTetramino.movRight();
                currFigurDraw();

            }
            else
            {
                currFigurDraw();
            }
        }
        public void CurrFigurMovDown()
        {
            Point position = currTetramino.getCurrPosition();
            Point[] Shape = currTetramino.getCurrShape();
            bool move = true;
            currFigurErase();
            foreach (Point S in Shape)
            {   //Schritt den wir machen ((int)(S.X + position.X) + ((Cols/2)-1)-1)
                if (((int)(S.Y + position.Y) + 2 + 1) >= Rows)//Checkt ob es OutOfRange ist
                {
                    move = false;
                }
                //Checkt ob block drunter ist
                else if (Blockcontrols[((int)(S.X + position.X) + ((Cols / 2) - 1)), (int)(S.Y + position.Y) + 2 + 1].Background != NoBrush)
                {
                    move = false;
                }
            }
            if (move)
            {
                currTetramino.movDown();
                currFigurDraw();

            }
            else
            {
                currFigurDraw();
                CheckRows();//Prüfen ob mit liegendem setien rows gefüllt wurden
                currTetramino = new Figuren();//neuer stein

            }
        }
        public void CurrFigurMovRotate()
        {
            Point position = currTetramino.getCurrPosition();
            Point[] Shape = currTetramino.getCurrShape();
            Point[] S = new Point[4];
            bool move = true;
            Shape.CopyTo(S, 0);// ab index 0 copy machen
            currFigurErase();
            for (int i = 0; i < S.Length; i++)
            {
                double x = S[i].X;//Rotation
                S[i].X = S[i].Y + -1;// aktuelle x coordinate überschreiben //Rotation
                S[i].Y = x;//Rotation
                if (((int)(S[i].Y + position.Y) + 2) >= Rows)
                {
                    move = false;
                }
                else if (((int)(S[i].X + position.X) + ((Cols / 2) - 1)) < 0)//Nix plus da schon rotation //nicht nach Links raus
                {
                    move = false;
                }
                else if (((int)(S[i].X + position.X) + ((Cols / 2) - 1)) >= Rows)//Nix plus da schon rotation //nicht nach rechts raus
                {
                    move = false;
                }
                //wenn anderer Block im Weg ist
                else if (Blockcontrols[((int)(S[i].X + position.X)) + ((Cols / 2) - 1), (int)(S[i].Y + position.Y) + 2].Background != NoBrush)
                {
                    move = false;
                }
            }
            if (move)
            {
                currTetramino.movRotate();
                currFigurDraw();
            }
            else
            {
                currFigurDraw();

            }
        }
    }
}
