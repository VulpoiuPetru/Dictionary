using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Tema1_dubla3
{
    internal class ImageManager
    {
        
        public static string SaveImageToResources(string imagePath, string destinationDirectory)
        {
           
                if (!Directory.Exists(destinationDirectory))
                    Directory.CreateDirectory(destinationDirectory);

                string imageName = Path.GetFileName(imagePath);
                string destinationPath = Path.Combine(destinationDirectory, imageName);

                File.Copy(imagePath, destinationPath, true);

                return destinationPath;
        }
    }
}
