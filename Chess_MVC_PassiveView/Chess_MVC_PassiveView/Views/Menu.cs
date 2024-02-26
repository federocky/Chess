using Chess_MVC_PassiveView.Utils;

namespace Chess_MVC_PassiveView.Views
{
    internal class Menu
    {
        private static readonly string OPTION = "----- Elige una opción -----";

        private List<Command> commandSet { get; set; }

        public Menu(IEnumerable<Command> commandSet)
        {
            this.commandSet = new List<Command>(commandSet);
        }

        public Command Execute()
        {
            var commands = new List<Command>();

            for (int i = 0; i < commandSet.Count; i++)
            {
                if (commandSet[i].IsActive())
                {
                    commands.Add(commandSet[i]);
                }
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

            return commands[parsedOption - 1];

        }
    }
}
