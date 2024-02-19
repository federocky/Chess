using Chess_MVC_PassiveView.Enums;
using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Repositories
{
    internal interface IRepository
    {
        public bool Save(string data, string fileName, PieceColor playerColor);
        public SavedGame Load(string fileName);
        public List<string> GetSavedGamesList();
    }
}
