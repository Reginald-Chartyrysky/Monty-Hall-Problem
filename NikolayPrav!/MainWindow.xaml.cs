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

namespace NikolayNePrav_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Hide();
            Console.WriteLine("start");

           double vsegoKoef = 0;
            for (int y= 0; y < 100; y++) { 
            int victories = 0;
            for (int i = 0; i < 100; i++)
            {
               
                for (int j = 0; j < 100; j++)
                {
                    victories += PlayGame(3);
                }
              
            }
            double koef = (double)victories / (double)(100 * 100);
                vsegoKoef += koef;
            Console.WriteLine(koef);
            }
           Console.WriteLine("Rez: " + (vsegoKoef /= 100));
        }


        public int PlayGame(int maxNumber)
         {
            Random rnd = new Random();
            
            List<int> doors = new List<int> ();
            for(int i = 1; i < maxNumber + 1; i++)
            {
                doors.Add (i);
            }

            int prize = rnd.Next(1,maxNumber+1);
            int choose = rnd.Next(1, maxNumber+1);
            List<int> toRemove = new List<int>();

            
            foreach(int door in doors)
            {
                if (door != prize && door != choose)
                {
                    toRemove.Add(door);
                }
            }

            foreach(int doorToRem in toRemove)
            {
                if(doors.Count > 2)
                {
                    doors.Remove(doorToRem);
                }
            }

            foreach(int door in doors)
            {
                if (door != choose)
                {
                    choose = door;
                    break;
                }
            }

            if (choose == prize)
            {

                return 1;
            }
            else
            {
             
                return 0;
            }

        }

    }
}
