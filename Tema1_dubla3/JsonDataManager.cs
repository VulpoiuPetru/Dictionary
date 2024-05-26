using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Tema1_dubla3
{
    internal class JsonDataManager
    {
        private readonly string _filePath;

        public JsonDataManager(string filePath)
        {
            _filePath = filePath;
        }

        public List<WordEntry> LoadWordEntries()
        {
           
                string jsonText = File.ReadAllText(_filePath);
                return JsonConvert.DeserializeObject<List<WordEntry>>(jsonText);
           
            
        }
        public void SaveWordEntries(List<WordEntry> entries)
        {
           
                string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            
           
        }
    }
}
