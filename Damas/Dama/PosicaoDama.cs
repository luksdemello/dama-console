

using Damas.tabuleiro;

namespace Damas.Dama
{
    class PosicaoDama
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoDama(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        public Posicao ToPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
