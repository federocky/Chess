using Chess_MVC_PassiveView.Models;
using Chess_MVC_PassiveView.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_MVC_PassiveView.Constrollers
{
    internal class ResumeController : Controller
    {
        public ResumeController(Board board, ViewFactory viewFactory) : base(board, viewFactory)
        {
        }
        public bool control()
        {
            return true;
        }
    }
}
