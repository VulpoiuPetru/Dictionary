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
using static System.Net.Mime.MediaTypeNames;
using System.Xml;
using Newtonsoft.Json;

namespace Tema1_dubla3
{
    /// <summary>
    /// Interaction logic for ModAdministrativ.xaml
    /// </summary>
    public partial class ModAdministrativ : Window
    {
        public ModAdministrativ()
        {
            InitializeComponent();
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            AddNew addNew = new AddNew();
            addNew.Show();
            this.Close();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            Modify modify = new Modify();
            modify.Show();
            this.Close();
        }

        private void Delte_Click(object sender, RoutedEventArgs e)
        {
            DeleteWord deleteWord = new DeleteWord();
            deleteWord.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
