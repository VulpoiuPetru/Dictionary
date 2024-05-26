using Newtonsoft.Json;
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
    /// Interaction logic for Searchword.xaml
    /// </summary>
    public partial class Searchword : Window
    {
        private List<WordEntry> wordEntries;
        // private List<string> suggestions = new List<string> { "Option 1", "Option 2", "Option 3" };
        private List<string> categories = new List<string>();
        private List<WordEntry> wordEntries1;
        private List<string> categories1 = new List<string>();

        public Searchword()
        {
            InitializeComponent();
            LoadWordEntries();
            LoadWordEntries1();
            // Asocierea evenimentului ListBox_SelectionChanged_3 cu metoda ListBox_SelectionChanged_3
            ListBox1.SelectionChanged += ListBox_SelectionChanged_3;
        }
        private void LoadWordEntries()
        {

            string jsonFilePath = "AddNew.json"; // Calea catre fisierul JSON
           // string jsonText = File.ReadAllText(jsonFilePath);
            string jsonText=File.ReadAllText(jsonFilePath);
            wordEntries = JsonConvert.DeserializeObject<List<WordEntry>>(jsonText);

            categories.Clear(); // Curata lista pentru a o reincarca

            foreach (var entry in wordEntries)
            {
                categories.Add(entry.Word); // Adauga cuvantul in lista de categorii
            }

            // Actualizeaza ListBox-ul cu cuvintele
            ListBox.ItemsSource = categories;
        }

       
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            // Afiseaza elementele ascunse
            Word.Visibility = Visibility.Visible;
            Category.Visibility = Visibility.Visible;
            //Image.Visibility = Visibility.Visible;
            Meaning.Visibility = Visibility.Visible;
            SelectedImage.Visibility = Visibility.Visible;

            //afisarea etichetelor ascunse
            WordLabel.Visibility = Visibility.Visible;
            CategoryLabel.Visibility = Visibility.Visible;
            //ImageLabel.Visibility = Visibility.Visible;
            MeaningLabel.Visibility = Visibility.Visible;
            if (ListBox.SelectedIndex != -1)
            {
                string selectedWord = ListBox.SelectedItem.ToString();
                WordEntry selectedEntry = wordEntries.FirstOrDefault(entry => entry.Word == selectedWord);

                if (selectedEntry != null)
                {
                    Word.Text = selectedEntry.Word;
                    Category.Text = selectedEntry.Category;
                    Meaning.Text = selectedEntry.Meaning;
                    Image.Text = selectedEntry.Image;

                    // Actualizăm imaginea folosind calea către resursele aplicației
                    string imagePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images2", selectedEntry.Image);

                    // Verificăm dacă fișierul imaginei există în resursele aplicației
                    if (File.Exists(imagePath))
                    {
                        try
                        {
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.UriSource = new Uri(imagePath);
                            bitmap.EndInit();
                            SelectedImage.Source = bitmap;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Eroare la încărcarea imaginii: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fișierul imaginii nu există în resursele aplicației.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selectează un cuvânt din lista de căutare.");
            }
        }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            //ListBox.Visibility = string.IsNullOrWhiteSpace(searchText) ? Visibility.Collapsed : Visibility.Visible;
            string searchText = SearchText.Text.ToLower();
            // Actualizare ItemsSource cu elementele filtrate
            ListBox.ItemsSource = categories.Where(suggestion => suggestion.ToLower().Contains(searchText)).ToList();
            // Setează vizibilitatea ListBox-ului în funcție de existența textului în TextBox
            ListBox.Visibility = string.IsNullOrWhiteSpace(searchText) ? Visibility.Collapsed : Visibility.Visible;

        }
        private void ListBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedIndex != -1)
            {
                SearchText.Text = ListBox.SelectedItem.ToString();
                ListBox.Visibility = Visibility.Collapsed;
            }
        }
        private void SearchText_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (ListBox.SelectedIndex != -1)
                {
                    SearchText.Text = ListBox.SelectedItem.ToString();
                    ListBox.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void Word_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Meaning_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void LoadWordEntries1()
        {

            string jsonFilePath = "AddNew.json"; // Calea catre fisierul JSON
            string jsonText = File.ReadAllText(jsonFilePath);
            wordEntries1 = JsonConvert.DeserializeObject<List<WordEntry>>(jsonText);

            categories1.Clear(); // Curata lista pentru a o reincarca

            foreach (var entry in wordEntries)
            {
                categories1.Add(entry.Category); // Adauga cuvantul in lista de categorii
            }

            // Actualizeaza ListBox-ul cu cuvintele
            ListBox.ItemsSource = categories1;
        }
        
        private void Searchcategory_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = Searchcategory.Text.ToLower();

            // Filtram lista de categorii pentru a elimina duplicatelor si pentru a o afisa in ListBox1
            ListBox1.ItemsSource = categories1
                .Where(suggestion => suggestion.ToLower().Contains(searchText))
                .Distinct() // Eliminam duplicatele
                .ToList();

            // Setam vizibilitatea ListBox1 in funcție de existenta textului in TextBox
            ListBox1.Visibility = string.IsNullOrWhiteSpace(searchText) ? Visibility.Collapsed : Visibility.Visible;

            // Filtrare si afisare cuvinte din categoria selectata în ListBox_SelectionChanged_2
            if (!string.IsNullOrEmpty(searchText))
            {
                // Filtram lista de intrari dupa categoria selectata si eliminam duplicatelor
                List<string> filteredWords = wordEntries1
                    .Where(entry => entry.Category.Equals(searchText, StringComparison.OrdinalIgnoreCase))
                    .Select(entry => entry.Word)
                    .Distinct() // Eliminam duplicatele
                    .ToList();

                // Actualizam ListBox-ul cu cuvintele din categoria selectata
                ListBox.ItemsSource = filteredWords;

                // Daca exista cuvinte in lista filtrata, afisam ListBox-ul
                ListBox.Visibility = filteredWords.Any() ? Visibility.Visible : Visibility.Collapsed;
            }
            else
            {
                // Daca nu exista text în Searchcategory, ascundem ListBox-ul
                ListBox.Visibility = Visibility.Collapsed;
            }
        }
        private void SearchText_PreviewKeyDown1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (ListBox.SelectedIndex != -1)
                {
                    Category.Text = ListBox1.SelectedItem.ToString();
                    ListBox1.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void ListBox_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox1.SelectedIndex != -1)
            {
                Searchcategory.Text = ListBox1.SelectedItem.ToString();
                ListBox1.Visibility = Visibility.Collapsed;
            }
        }
    }
}
