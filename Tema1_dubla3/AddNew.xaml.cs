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
using Microsoft.Win32;
using Newtonsoft.Json;
namespace Tema1_dubla3
{
    /// <summary>
    /// Interaction logic for AddNew.xaml
    /// </summary>
    public partial class AddNew : Window
    {
        private List<WordEntry> wordEntries;
        // private List<string> suggestions = new List<string> { "Option 1", "Option 2", "Option 3" };
        private List<string> categories = new List<string>();
        private readonly JsonDataManager _jsonDataManager;
        private readonly ImageManager imageManager;
        public AddNew()
        {
            InitializeComponent();
            _jsonDataManager = new JsonDataManager("AddNew.json");
            imageManager = new ImageManager();
            LoadWordEntries();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string word = Word.Text;
            string category = Category.Text;
            string meaning = Meaning.Text;
            string imageName = Image.Text;

            try
            {
                string filePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "AddNew.json");

                List<WordEntry> entries;

                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    entries = JsonConvert.DeserializeObject<List<WordEntry>>(jsonData);
                }
                else
                {
                    entries = new List<WordEntry>();
                }

                if (entries.Any(entry => entry.Word.Equals(word, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Cuvantul exista deja în lista!");
                    return;
                }

                if (entries.Any(entry => entry.Meaning.Equals(meaning, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("Descrierea exista deja în lista!");
                    return;
                }

                if (SelectedImage.Source is BitmapImage bitmapImage)
                {
                    // Salvaream imaginii si obtinem calea catre aceasta
                    imageName = ImageManager.SaveImageToResources(bitmapImage.UriSource.AbsolutePath, "Images2");
                }

                if (string.IsNullOrEmpty(word) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(meaning))
                {
                    MessageBox.Show("Introduceti date in toate campurile!");
                    return;
                }

                WordEntry newEntry = new WordEntry
                {
                    Word = word,
                    Category = category,
                    Image = string.IsNullOrEmpty(imageName) ? "noimage.jpeg" : System.IO.Path.GetFileName(imageName),
                    Meaning = meaning
                };

                entries.Add(newEntry);

                string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
                File.WriteAllText(filePath, json);

                MessageBox.Show("Informatia a fost salvata cu succes!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A aparut o eroare in timpul salvarii informatiei: {ex.Message}");
            }
        }

        private string GetDefaultImagePath()
        {
            string defaultImage = "noimage.jpeg";
            string imagesDirectory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images2");
            return System.IO.Path.Combine(imagesDirectory, defaultImage);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ModAdministrativ modAdministrativ = new ModAdministrativ();
            modAdministrativ.Show();
            this.Close();
        }
        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string imagePath = openFileDialog.FileName;

                    // Afisam imaginea selectata in campul Image
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(imagePath);
                    bitmap.EndInit();
                    SelectedImage.Source = bitmap;

                    // Salvam calea catre imaginea selectata în textbox-ul Image
                    Image.Text = imagePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"A aparut o eroare in timpul selectarii imaginii: {ex.Message}");
                }
            }
        }
        private void SaveImageToResources(string imagePath)
        {
            string imagesDirectory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images2");

            if (!Directory.Exists(imagesDirectory))
            {
                Directory.CreateDirectory(imagesDirectory);
            }

            string imageName = System.IO.Path.GetFileName(imagePath);
            string destinationPath = System.IO.Path.Combine(imagesDirectory, imageName);

            File.Copy(imagePath, destinationPath, true);
        }
        
        private void Meaning_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        
        //cautare categorii
        private void LoadWordEntries()
        {
            string jsonFilePath = "AddNew.json"; // Calea catre fisierul JSON
            string jsonText = File.ReadAllText(jsonFilePath);
            wordEntries = JsonConvert.DeserializeObject<List<WordEntry>>(jsonText);

            categories.Clear(); // Curata lista pentru a o reincarca

            foreach (var entry in wordEntries)
            {
                categories.Add(entry.Category); // Adauga categoria in lista de categorii
            }

            // Obtine doar categoriile unice
            categories = categories.Distinct().ToList();

            // Actualizeaza ListBox-ul cu categoriile
            ListBox.ItemsSource = categories;
        }
        private void Category_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = Category.Text.ToLower();

            // Verificam daca textul introdus este o potrivire partiala cu una dintre categoriile existente
            bool foundMatch = categories.Any(suggestion => suggestion.ToLower().Contains(searchText));

            // Setam vizibilitatea ListBox-ului în functie de existenta unei potriviri partiale
            ListBox.Visibility = foundMatch ? Visibility.Visible : Visibility.Collapsed;

            // Actualizam ItemsSource cu elementele filtrate doar daca exista o potrivire parțiala
            ListBox.ItemsSource = foundMatch ? categories.Where(suggestion => suggestion.ToLower().Contains(searchText)).ToList() : null;
        }
        private void SearchText_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                if (ListBox.SelectedIndex != -1)
                {
                    Category.Text = ListBox.SelectedItem.ToString();
                    ListBox.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void ListBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedIndex != -1)
            {
               Category.Text = ListBox.SelectedItem.ToString();
                ListBox.Visibility = Visibility.Collapsed;
            }
        }
    }
}
