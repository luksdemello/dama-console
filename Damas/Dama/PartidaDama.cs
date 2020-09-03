using Damas.tabuleiro;
using System.Collections.Generic;

namespace Damas.Dama
{
    class PartidaDama
    {
        public Tabuleiro Tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        public HashSet<Peca> Capturadas;

        public PartidaDama()
        {
            Tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tab.RetirarPeca(origem);
            p.ImcrementarMovimentos();
            Tab.ColocarPeca(p, destino);



            int linhaMedia = destino.Linha - origem.Linha;
            int colunaMedia = destino.Coluna - origem.Coluna;

            if (linhaMedia == -2 && colunaMedia == -2) 
            {
                Posicao posP = new Posicao(destino.Linha + 1, destino.Coluna + 1);
                Peca capturada = Tab.RetirarPeca(posP);
                Capturadas.Add(capturada);
            }

            if (linhaMedia == -2 && colunaMedia == 2)
            {
                Posicao posP = new Posicao(destino.Linha + 1, destino.Coluna - 1);
                Peca capturada = Tab.RetirarPeca(posP);
                Capturadas.Add(capturada);
            }

            if (linhaMedia == 2 && colunaMedia == -2)
            {
                Posicao posP = new Posicao(destino.Linha - 1, destino.Coluna + 1);
                Peca capturada = Tab.RetirarPeca(posP);
                Capturadas.Add(capturada);
            }

            if (linhaMedia == 2 && colunaMedia == 2)
            {
                Posicao posP = new Posicao(destino.Linha - 1, destino.Coluna - 1);
                Peca capturada = Tab.RetirarPeca(posP);
                Capturadas.Add(capturada);
            }

        }

        

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);

            Peca p = Tab.Peca(destino);

            if (p is Peao)
            {
                if (p.Cor == Cor.Branca && destino.Linha == 0 || p.Cor == Cor.Preta && destino.Linha == 7)
                {
                    p.Tab.RetirarPeca(destino);
                    Pecas.Remove(p);
                    Peca dama = new Dama(Tab, p.Cor);
                    Tab.ColocarPeca(dama, destino);
                    Pecas.Add(dama);
                }
            }
            

            if (FinalizaPartida())
            {
                Terminada = true;
            }
            else
            {
                Terminada = false;
                Turno++;
                MudaJogador();
            }
        }

        public bool FinalizaPartida()
        {
            int contBranca = 0;
            int contPreta = 0;

            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    Posicao posicao = new Posicao(i, j);

                    if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor == Cor.Branca)
                    {
                        contBranca += 1;
                    }

                    if (Tab.Peca(posicao) != null && Tab.Peca(posicao).Cor == Cor.Preta)
                    {
                        contPreta += 1;
                    }
                }
            }

            if (contBranca == 0 || contPreta == 0)
            {
                return true;

            }
            return false;

        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (Tab.Peca(pos) == null)
            {
                throw new TabException("There is no piece in the chosen position");
            }
            if (JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabException("The piece chosen is not your!");
            }
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabException("There is no possible movements for this piece!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabException("Invalid target position!");
            }
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoDama(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas()
        {
            // pecas brancas
            ColocarNovaPeca('a', 1, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('a', 3, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('b', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('c', 1, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('c', 3, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('e', 3, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('f', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('g', 1, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('g', 3, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('h', 2, new Peao(Tab, Cor.Branca));

            //Pecas pretas
            ColocarNovaPeca('a', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('b', 6, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('b', 8, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('c', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('d', 6, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('f', 6, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('f', 8, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('g', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('h', 6, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('h', 8, new Peao(Tab, Cor.Preta));
        }
    }
}
