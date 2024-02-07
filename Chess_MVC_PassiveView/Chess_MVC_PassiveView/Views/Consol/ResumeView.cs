namespace Chess_MVC_PassiveView.Views.Consol
{
    internal class ResumeView : IResumeView
    {
        public string ReadRestartGame()
        {
            var response = "";
            do
            {
                Console.WriteLine("Partida terminada. ¿Quieres jugar otra vez?");
                Console.WriteLine("1- Si");
                Console.WriteLine("*- No");
                response = Console.ReadLine();

            } while (string.IsNullOrEmpty(response));

            return response;
        }
    }
}
