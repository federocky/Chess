namespace Chess_MVC_PassiveView.Views.Consol
{
    internal class ErrorView : IErrorView
    {
        public void ShowErrorSaving(string message)
        {
            Console.WriteLine("Error al guardar datos en el archivo: " + message);
        }
    }
}
