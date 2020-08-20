using Damas.tabuleiro;


namespace Damas.Dama
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "O";
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null;
        }



        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);


            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);

            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }


            // Capturar Pecas
            if (Tab.PosicaoValida(new Posicao(Posicao.Linha - 1, Posicao.Coluna - 1)))
            {
                Posicao InimigoEsquerda = new Posicao(Posicao.Linha - 1, Posicao.Coluna - 1);

                if (ExisteInimigo(InimigoEsquerda))
                {
                    pos.DefinirValores(InimigoEsquerda.Linha - 1, InimigoEsquerda.Coluna - 1);
                    if (Tab.PosicaoValida(pos) && PodeMover(pos))
                    {

                        mat[pos.Linha, pos.Coluna] = true;

                    }
                }

            }


            if (Tab.PosicaoValida(new Posicao(Posicao.Linha - 1, Posicao.Coluna + 1)))
            {
                Posicao InimigoDireita = new Posicao(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (ExisteInimigo(InimigoDireita))
                {
                    pos.DefinirValores(InimigoDireita.Linha - 1, InimigoDireita.Coluna + 1);
                    if (Tab.PosicaoValida(pos) && PodeMover(pos))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                }

            }


            if (Tab.PosicaoValida(new Posicao(Posicao.Linha + 1, Posicao.Coluna - 1)))
            {
                Posicao InimigoEsquerda = new Posicao(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (ExisteInimigo(InimigoEsquerda))
                {
                    pos.DefinirValores(InimigoEsquerda.Linha + 1, InimigoEsquerda.Coluna - 1);
                    if (Tab.PosicaoValida(pos) && PodeMover(pos))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                }

            }


            if (Tab.PosicaoValida(new Posicao(Posicao.Linha + 1, Posicao.Coluna + 1)))
            {
                Posicao InimigoDireita = new Posicao(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (ExisteInimigo(InimigoDireita))
                {
                    pos.DefinirValores(InimigoDireita.Linha + 1, InimigoDireita.Coluna + 1);
                    if (Tab.PosicaoValida(pos) && PodeMover(pos))
                    {
                        mat[pos.Linha, pos.Coluna] = true;
                    }
                }

            }


            return mat;
        }
    }
}
