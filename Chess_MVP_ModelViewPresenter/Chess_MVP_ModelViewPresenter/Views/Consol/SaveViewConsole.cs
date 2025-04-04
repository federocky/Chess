﻿using Chess_MVP_ModelViewPresenter.Presenters;

namespace Chess_MVP_ModelViewPresenter.Views.Consol
{
    internal class SaveViewConsole
    {
        internal void Save(PlayPresenter acceptorPresenter)
        {
            if (acceptorPresenter.Save())
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
