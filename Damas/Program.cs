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
                PartidaDama partida = new PartidaDama();


                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimeTabuleiro(partida.Tab);



                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoDama().ToPosicao();

                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoDama().ToPosicao();

                    partida.ExecutaMovimento(origem, destino);
                }

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
