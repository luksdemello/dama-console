using Damas.Dama;
using Damas.tabuleiro;
using System;

namespace Damas
{
    class Program
    {
        static void Main(string[] args)
        {

            PosicaoDama pos = new PosicaoDama('c', 7);

            pos.ToPosicao();

            Console.WriteLine(pos.ToPosicao()); ;
            
        }
    }
}
