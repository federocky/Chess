using Chess_MVC_PassiveView.Enums;

namespace Chess_MVC_PassiveView.Repositories
{
    internal interface IRepository
    {
        public bool Save(string data, string fileName, PieceColor playerColor);
    }
}
