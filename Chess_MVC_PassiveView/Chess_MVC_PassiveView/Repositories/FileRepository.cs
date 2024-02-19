using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Repositories
{
    internal class FileRepository : IRepository
    {
        private string filesFolder { get; set; }

        public FileRepository()
        {
            filesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Data");
        }

        public bool Save(string data, string fileName, PieceColor playerColor)
        {
            if (!Directory.Exists(filesFolder))
            {
                Directory.CreateDirectory(filesFolder);
            }

            string filePath = Path.Combine(filesFolder, fileName + ".txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {            
                    writer.Write(data + ";" + playerColor.ToString());
                }                
            }
            catch
            {
                return false;
            }

            return true;
        }

        public SavedGame Load(string fileName)
        {
            string filePath = Path.Combine(filesFolder, fileName + ".txt");

            try
            {
                if (File.Exists(filePath))
                {
                    var file = File.ReadAllText(filePath);
                    var game = new SavedGame(file);
                    return game;
                }
            }
            catch
            {
                //TODO: Handle exceptions
            }

            return new SavedGame();
        }


        public List<string> GetSavedGamesList()
        {
            List<string> savedGames = new List<string>();

            try
            {
                if (Directory.Exists(filesFolder))
                {
                    string[] files = Directory.GetFiles(filesFolder, "*.txt");
                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(file);
                        savedGames.Add(fileName);
                    }
                }
            }
            catch
            {
                //TODO: handle exceptions
            }

            return savedGames;
        }
    }    
}
