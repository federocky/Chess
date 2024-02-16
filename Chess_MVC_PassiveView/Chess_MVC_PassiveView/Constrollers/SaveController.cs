using Chess_MVC_PassiveView.Models;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class SaveController : InGameController
    {
        string[] datos = { "Dato1", "Dato2", "Dato3" };

        // Ruta del archivo de texto
        string rutaArchivo = "datos.txt";

        public SaveController(Board board, Turn turn, GameStatus gameStatus, Session session) : base(board, turn, gameStatus, session)
        {
        }

        public override void Control()
        {
            //TODO: guardar partida actual.
            try
            {
                // Abre el archivo en modo de escritura (si no existe, lo crea)
                using (StreamWriter escritor = new StreamWriter(rutaArchivo))
                {
                    // Escribe cada dato en una línea del archivo
                    foreach (string dato in datos)
                    {
                        escritor.WriteLine(dato);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar datos en el archivo: " + ex.Message);
            }
        }
    }
}
