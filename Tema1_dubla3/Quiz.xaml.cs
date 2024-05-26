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
    /// Interaction logic for Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
        private List<WordEntry> wordEntries;
        private List<WordEntry> gameWords;
        private int currentWordIndex = 0;
        private int currentGameIndex = 1;
        private int correctAnswers = 0;
        private int totalWords = 5; 
        GameManager gameManager;
        public Quiz()
        {
            InitializeComponent();
            gameManager = new GameManager();
            LoadWordEntries();
            StartNewGame();
        }
        private void LoadWordEntries()
        {
            string jsonFilePath = "AddNew.json";
            // string jsonText = File.ReadAllText(jsonFilePath);
            string jsonText = File.ReadAllText(jsonFilePath);
            wordEntries = JsonConvert.DeserializeObject<List<WordEntry>>(jsonText);
        }
        private void StartNewGame()
        {
            // Selectarea aleatoriu 5 cuvinte pentru joc
            //gameWords = wordEntries.OrderBy(x => Guid.NewGuid()).Take(totalWords).ToList();
            //currentWordIndex = 0;
            //currentGameIndex = 1;
            //correctAnswers = 0;
            gameManager.StartNewGame(wordEntries, 5);
            Result.Content = "Result"; // Elimina continutul label-ului Result
            Result.Background = Brushes.Gray;
            Answer.Text = ""; // sterge textul din TextBox Answer
            Numberofanswers.Content = "1/5"; // Resetare numar de raspunsuri
            Next.Content = "Next"; // Resetare text buton Next
            DisplayNextWord();
        }
        private void ResetGame()
        {
            StartNewGame();
            Result.Content = "Result"; // Elimina continutul label-ului Result
            Result.Background = Brushes.Gray;
            Answer.Text = ""; // sterge textul din TextBox Answer
            Numberofanswers.Content = "1/5"; // Resetare numar de raspunsuri
            Next.Content = "Next"; // Resetare text buton Next
        }
        private string GetDefaultImagePath(string imageName)
        {
            string imagesDirectory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images2");
            string imagePath = System.IO.Path.Combine(imagesDirectory, imageName);
            return File.Exists(imagePath) ? imagePath : null;
        }
        private void DisplayNextWord()
        {
            WordEntry currentWord = gameManager.GetCurrentWord();
            if (currentWord != null)
            {
                bool showDescription = string.IsNullOrEmpty(currentWord.Image) || new Random().Next(2) == 0;
                if (showDescription)
                {
                    // afisare descriere
                    DescriptionOrImageLabel.Content = new TextBlock { TextWrapping = TextWrapping.Wrap, Text = currentWord.Meaning };
                }
                else
                {
                    string imagePath = GetDefaultImagePath(currentWord.Image);
                    if (currentWord.Image != "noimage.jpeg" && imagePath != null)
                    {
                        // afiseaza imaginea daca exista
                        DescriptionOrImageLabel.Content = new Image
                        {
                            Source = new BitmapImage(new Uri(imagePath)),
                            Stretch = Stretch.Uniform,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Width = 200,
                            Height = 200
                        };
                    }
                    else
                    {
                        //afiseaza descrierea in caul in care nu este imagine
                        DescriptionOrImageLabel.Content = new TextBlock { TextWrapping = TextWrapping.Wrap, Text = currentWord.Meaning };
                    }
                }
                if (gameManager.GetCurrentGameIndex() == gameManager.GetTotalWordsCount())
                {
                    Next.Visibility = Visibility.Collapsed;
                    Finish.Visibility = Visibility.Visible;
                }
                else
                {
                    Next.Visibility = Visibility.Visible;
                    Finish.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                MessageBox.Show($"Your score: {gameManager.GetCorrectAnswersCount()}/{gameManager.GetTotalWordsCount()}");
            }
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            WordEntry currentWord = gameManager.GetCurrentWord();
            string userAnswer = Answer.Text.Trim();
            if (gameManager.SubmitAnswer(userAnswer))
            {
                Result.Content = "Correct!";
                Result.Background = Brushes.Green;
            }
            else
            {
                Result.Content = $"Incorrect! Correct answer is: {currentWord.Word}";
                Result.Background = Brushes.Red;
            }
            gameManager.MoveToNextWord();
            Numberofanswers.Content = $"{gameManager.GetCurrentGameIndex()}/{gameManager.GetTotalWordsCount()}";
            DisplayNextWord();
        }
        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            WordEntry currentWord = gameManager.GetCurrentWord();
            string userAnswer = Answer.Text.Trim();
            if (gameManager.SubmitAnswer(userAnswer))
            {
                Result.Content = "Correct!";
                Result.Background = Brushes.Green;
            }
            else
            {
                Result.Content = $"Incorrect! Correct answer is: {currentWord.Word}";
                Result.Background = Brushes.Red;
            }
            MessageBox.Show($"Your score: {gameManager.GetCorrectAnswersCount()}/{gameManager.GetTotalWordsCount()}");
            StartNewGame();
            
        }
    }
}
