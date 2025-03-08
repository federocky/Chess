using Chess_MVP_ModelViewPresenter.Controllers;
using Chess_MVP_ModelViewPresenter.Repositories;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class LoadView
    {
        public void Load(StartController startController)
        {
            var savedGames = startController.GetSavedGames();
            
            if(savedGames.Count == 0)
            {
                Console.WriteLine("No hay partidas guardadas!!");
            }
            else
            {
                var error = false;
                int parsedOption = 0;

                do
                {

                    Console.WriteLine("Elegir una partida");
                    for (int i = 0; i < savedGames.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}- {savedGames[i]}");
                    }
                    var response = Console.ReadLine();

                    if (string.IsNullOrEmpty(response) || !int.TryParse(response, out parsedOption) || parsedOption <= 0 || parsedOption > savedGames.Count) error = true;
                } while (error);

                var selectedGame = savedGames[parsedOption - 1];

                startController.Load(selectedGame);
            }               
        }

    }
}
