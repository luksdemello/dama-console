using Damas.tabuleiro;
using System;

namespace Damas
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(10, 10);

            Tela.ImprimeTabuleiro(tab);
        }
    }
}
