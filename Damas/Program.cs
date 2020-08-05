using Damas.Dama;
using Damas.tabuleiro;
using System;

namespace Damas
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro tab = new Tabuleiro(10, 10);

            tab.ColocarPeca(new Peao(tab, Cor.Branca), new Posicao(0, 0));
            tab.ColocarPeca(new Peao(tab, Cor.Branca), new Posicao(3, 4));

            Tela.ImprimeTabuleiro(tab);
        }
    }
}
