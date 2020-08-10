using Damas.Dama;
using Damas.tabuleiro;
using System;

namespace Damas
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Peao(tab, Cor.Branca), new Posicao(0, 0));
                tab.ColocarPeca(new Peao(tab, Cor.Preta), new Posicao(3, 4));

                Tela.ImprimeTabuleiro(tab);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
