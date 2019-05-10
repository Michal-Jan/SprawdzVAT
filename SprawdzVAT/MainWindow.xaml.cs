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

namespace SprawdzVAT
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        statusService.WeryfikacjaVAT weryfikacja = new statusService.WeryfikacjaVAT();
        public MainWindow()
        {
            InitializeComponent();
            FocusManager.SetFocusedElement(this, nipTextBox);
            Keyboard.Focus(nipTextBox);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string numerNIP = nipTextBox.Text;

            //System.Text.RegularExpressions.Regex.Replace(numerNIP, "[^0-9.]", "");
                
            if (numerNIP.Length == 10)
            {
                string wynik = Convert.ToString(weryfikacja.SprawdzNIP(numerNIP).Komunikat);
                wynikLabel.Content = wynik;
            }
            else
            {
                wynikLabel.Content = "Nieprawidłowa ilość cyfr w numerze.";
            }
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sprawdzButton, e);
            }
        }
    }
}
