using Chess_MVP_ModelViewPresenter.Controllers;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class SaveView
    {
        internal void Save(PlayController acceptorController)
        {
            if (acceptorController.Save())
            {
                Console.WriteLine("Partida Guardada");
            }
            else
            {
                Console.WriteLine("Ooops, en estos momentos no se puede guardar");
            }
        }
    }
}
