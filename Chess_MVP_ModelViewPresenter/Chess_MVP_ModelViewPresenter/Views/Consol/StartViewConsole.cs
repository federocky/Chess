﻿using Chess_MVP_ModelViewPresenter.Presenters;
using Chess_MVP_ModelViewPresenter.Views.Menus;

namespace Chess_MVP_ModelViewPresenter.Views.Consol
{
    internal class StartViewConsole
    {
        internal void Interact(StartPresenter startPresenter)
        {
            Console.WriteLine("Bienvenido al ajedrez!!");
            new StartMenu(startPresenter).Execute();

        }
    }
}
