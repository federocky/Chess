﻿namespace Chess_MVP_ModelViewPresenter.Controllers
{
    internal class NullController : AcceptorController
    {

        public override bool IsNull()
        {
            return true;
        }
    }
}
