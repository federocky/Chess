using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class PlayController : Controller
    {
        public PlayController(Board board, ViewFactory viewFactory) : base(board, viewFactory)
        {
        }
        public void control()
        {

        }
    }
}
