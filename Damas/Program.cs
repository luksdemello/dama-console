﻿using Damas.Dama;
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
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);


                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoDama().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicaoPossiveis = partida.Tab.Peca(origem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimeTabuleiro(partida.Tab, posicaoPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoDama().ToPosicao();
                        partida.ValidarPosicaoDestino(origem, destino);

                        partida.RealizaJogada(origem, destino);
                    }
                    catch (TabException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                        Console.ReadLine();
                    }
                }
                Console.WriteLine();
                Console.WriteLine("FIM DA PARTIDA");
                Console.WriteLine("GANHADOR: " + partida.JogadorAtual);

                
            }
            catch (TabException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
