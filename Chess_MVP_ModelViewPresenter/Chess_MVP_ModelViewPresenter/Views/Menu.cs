using Chess_MVP_ModelViewPresenter.Utils;

namespace Chess_MVP_ModelViewPresenter.Views
{
    internal class Menu
    {
        private static readonly string OPTION = "----- Elige una opción -----";

        private List<Command> commandSet { get; set; }

        public Menu()
        {
            commandSet = new List<Command>();
        }

        public void Execute()
        {
            var commands = new List<Command>();

            for (int i = 0; i < commandSet.Count; i++)
            {               
                commands.Add(commandSet[i]); //TODO: do i need this loop?                
            }

            bool error;
            string option;
            int parsedOption = 0;

            do
            {
                error = false;
                Console.WriteLine();
                Console.WriteLine(OPTION);
                for (int i = 0; i < commands.Count; i++)
                {
                    Console.WriteLine(i + 1 + ") " + commands[i].GetTitle());
                }

                option = Console.ReadLine();

                if (string.IsNullOrEmpty(option) || !int.TryParse(option, out parsedOption) || parsedOption <= 0 || parsedOption > commands.Count) error = true;

            } while (error);

            commands[parsedOption - 1].Execute();

        }

        protected void AddCommand(Command command)
        {
            commandSet.Add(command);
        }
    }
}
