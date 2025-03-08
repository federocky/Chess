using Chess_MVP_ModelViewPresenter.Enums;
using Chess_MVP_ModelViewPresenter.Models;

namespace Chess_MVP_ModelViewPresenter.Repositories
{
    internal interface IRepository
    {
        public bool Save(string data, string fileName, PieceColor playerColor);
        public SavedGame Load(string fileName);
        public List<string> GetSavedGamesList();
    }
}
