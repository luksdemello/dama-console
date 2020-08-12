using Damas.tabuleiro;
using System;


namespace Damas.Dama
{
    class PartidaDama
    {
        public Tabuleiro Tab { get; private set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool Terminada { get; private set; }

        public PartidaDama()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.ImcrementarMovimentos();
            Peca pecaCapturada = Tab.RetirarPeca(destino);
            Tab.ColocarPeca(p, destino);
        }

        private void ColocarPecas()
        {
            // Pecas brancas
            Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDama('a', 1).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDama('a', 3).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDama('b', 2).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDama('c', 1).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDama('c', 3).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDama('d', 2).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDama('e', 1).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDama('e', 3).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDama('f', 2).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDama('g', 1).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDama('g', 3).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Branca), new PosicaoDama('h', 2).ToPosicao());

            //Pecas pretas
            Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDama('a', 6).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDama('a', 8).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDama('b', 7).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDama('c', 6).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDama('c', 8).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDama('d', 7).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDama('e', 6).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDama('e', 8).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDama('f', 7).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDama('g', 6).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDama('g', 8).ToPosicao());
            Tab.ColocarPeca(new Peao(Tab, Cor.Preta), new PosicaoDama('h', 7).ToPosicao());

        }
    }
}
