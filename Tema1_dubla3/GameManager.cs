using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1_dubla3
{
    internal class GameManager
    {
        
        private List<WordEntry> gameWords;
        private int currentWordIndex = 0;
        private int currentGameIndex = 1;
        private int correctAnswers = 0;

        public void StartNewGame(List<WordEntry> wordEntries, int totalWords)
        {
            gameWords = wordEntries.OrderBy(x => Guid.NewGuid()).Take(totalWords).ToList();
            currentWordIndex = 0;
            currentGameIndex = 1;
            correctAnswers = 0;
        }

        public WordEntry GetCurrentWord()
        {
            return currentWordIndex < gameWords.Count ? gameWords[currentWordIndex] : null;
        }

        public bool SubmitAnswer(string userAnswer)
        {
            WordEntry currentWord = GetCurrentWord();
            if (currentWord != null && userAnswer.Equals(currentWord.Word, StringComparison.OrdinalIgnoreCase))
            {
                correctAnswers++;
                return true;
            }
            return false;
        }

        public int GetCorrectAnswersCount()
        {
            return correctAnswers;
        }

        public int GetTotalWordsCount()
        {
            return gameWords.Count;
        }

        public void MoveToNextWord()
        {
            currentWordIndex++;
            currentGameIndex++;
        }

        public int GetCurrentGameIndex()
        {
            return currentGameIndex;
        }
    }
}
