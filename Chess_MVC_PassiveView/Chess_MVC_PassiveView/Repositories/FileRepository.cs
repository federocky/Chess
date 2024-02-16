using Chess_MVC_PassiveView.Enums;

namespace Chess_MVC_PassiveView.Repositories
{
    internal class FileRepository : IRepository
    {
        private string filesFolder { get; set; }

        public FileRepository()
        {
            filesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\DatosPartidas");
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

    }
}
