using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1_dubla3
{
    internal class WordManager
    {
        private List<WordEntry> wordEntries;
        private string jsonfilePath;

        public WordManager()
        {
            LoadWordEntries();
        }

        internal void LoadWordEntries()
        {
            string jsonFilePath = "AddNew.json";
            string jsonText = File.ReadAllText(jsonFilePath);
            wordEntries = JsonConvert.DeserializeObject<List<WordEntry>>(jsonText);
        }


        public void AddWordEntry(WordEntry entry)
        {
            wordEntries.Add(entry);
            SaveWordEntries();
        }
        public WordManager(string jsonFilePath)
        {
            this.jsonfilePath = jsonFilePath;
        }

        private void SaveWordEntries()
        {
            string json = JsonConvert.SerializeObject(wordEntries, Formatting.Indented);
            File.WriteAllText("AddNew.json", json);
        }
        public WordEntry GetWordEntry(string word)
        {
            return wordEntries.FirstOrDefault(entry => entry.Word == word);
        }

        public void RemoveWordEntry(WordEntry entry)
        {
            wordEntries.Remove(entry);
            SaveWordEntries(); // Pentru a salva modificarile in fisierul JSON
        }
        public void SaveWordEntries(List<WordEntry> entries)
        {
            string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
            File.WriteAllText("AddNew.json", json);
        }
    }
}
