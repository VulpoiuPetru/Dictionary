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

namespace Tema1_dubla3
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            // Specificați calea către fișierul text
            string filePath = "Login.txt";

            // Datele de scris în fișier, fiecare pereche userID,password pe o linie
            string dataToWrite = "userID1,password1\nuserID2,password2\npetru,123\n";

            try
            {
                // Scrierea datelor în fișierul text
                File.WriteAllText(filePath, dataToWrite);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la scrierea datelor în fișierul text: " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userID = userIDTextBox.Text;
            string password = passwordTextBox.Password;

            string filePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Login.txt");
            if (File.Exists(filePath))
            {
                try
                {
                    // Citirea liniilor din fisierul text
                    string[] lines = File.ReadAllLines(filePath);

                    // Iterarea prin fiecare linie si verificarea datelor de autentificare
                    foreach (string line in lines)
                    {
                        // Separarea liniei în UserID și Password
                        string[] parts = line.Split(',');

                        // Verificarea daca datele introduse coincid cu cele din fișierul text
                        if (parts.Length == 2 && parts[0] == userID && parts[1] == password)
                        {
                            // Creeaza o instanta a ferestrei ModAdminstrativ
                            ModAdministrativ modAdministrativ = new ModAdministrativ();
                            // Afiseaza fereastra ModAdimin
                            modAdministrativ.Show();
                            this.Close();
                            return;
                        }
                    }

                    MessageBox.Show("Autentificare eșuată! Verificați datele introduse.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare la citirea datelor din fișierul text: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fișierul fisier.txt nu există în directorul aplicației.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
