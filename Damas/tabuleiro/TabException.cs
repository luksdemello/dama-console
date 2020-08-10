using System;

namespace Damas.tabuleiro
{
    class TabException : Exception
    {
        public TabException(string msg) : base (msg)
        {
        }
    }
}
