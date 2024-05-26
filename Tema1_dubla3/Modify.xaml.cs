using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; // Adăugat pentru a folosi clasa File
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
    /// Interaction logic for Modify.xaml
    /// </summary>
    public partial class Modify : Window
    {
        private List<WordEntry> wordEntries;
        // private List<string> suggestions = new List<string> { "Option 1", "Option 2", "Option 3" };
        private List<string> categories = new List<string>();
        private WordManager wordManager; 
        private ImageManager imageManager; 
        public Modify()
        {
            InitializeComponent();
            LoadWordEntries();
            wordManager = new WordManager(); 
            imageManager = new ImageManager(); 
           
        }
        private void LoadWordEntries()
        {

            string jsonFilePath = "AddNew.json"; // Calea catre fisierul JSON
            string jsonText = File.ReadAllText(jsonFilePath);
            wordEntries = JsonConvert.DeserializeObject<List<WordEntry>>(jsonText);

            categories.Clear(); // Curata lista pentru a o reincarca

            foreach (var entry in wordEntries)
            {
                categories.Add(entry.Word); // Adauga cuvantul in lista de categorii
            }

            // Actualizeaza ListBox-ul cu cuvintele
            ListBox.ItemsSource = categories;
        }
        private void Word_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Meaning_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            //ListBox.Visibility = string.IsNullOrWhiteSpace(searchText) ? Visibility.Collapsed : Visibility.Visible;
            string searchText = SearchText.Text.ToLower();
            // Actualizare ItemsSource cu elementele filtrate
            ListBox.ItemsSource = categories.Where(suggestion => suggestion.ToLower().Contains(searchText)).ToList();
            // Seteaza vizibilitatea ListBox-ului in funcție de existenta textului în TextBox
            ListBox.Visibility = string.IsNullOrWhiteSpace(searchText) ? Visibility.Collapsed : Visibility.Visible;
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

        private void ListBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedIndex != -1)
            {
                SearchText.Text = ListBox.SelectedItem.ToString();
                ListBox.Visibility = Visibility.Collapsed;
            }
        }

       
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
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

                    // Actualizam imaginea folosind calea catre resursele aplicatiei
                    string imagePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images2", selectedEntry.Image);

                    // Verificam dacă fisierul imaginei exista în resursele aplicatiei
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
                            MessageBox.Show("Eroare la incarcarea imaginii: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fisierul imaginii nu exista in resursele aplicatiei.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecteaza un cuvant din lista de cautare.");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(ListBox.SelectedIndex != -1)
            {
                string selectedWord= ListBox.SelectedItem.ToString();
                WordEntry selectedEntry = wordEntries.FirstOrDefault(entry => entry.Word == selectedWord);
                if (selectedEntry != null)
                {
                    selectedEntry.Word=Word.Text;
                    selectedEntry.Category=Category.Text;
                    selectedEntry.Meaning=Meaning.Text;
                    selectedEntry.Image=Image.Text;
                    ////coverteste lista de WordEntry in Json
                    //string jsonText= JsonConvert.SerializeObject(wordEntries,Formatting.Indented);

                    ////Scrie datle in fisierul JSON
                    //string jsonFilePath = "AddNew.json";
                    //File.WriteAllText(jsonFilePath,jsonText);
                    // salveaza modificarile folosind WordManager
                    wordManager.SaveWordEntries(wordEntries);
                }
                else
                {
                    MessageBox.Show("Selecteaza un cuvant din lista de cautare.");
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ModAdministrativ modAdministrativ= new ModAdministrativ(); ;
            modAdministrativ.Show();
            this.Close();
        }
    }
}
