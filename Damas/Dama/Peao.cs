using Damas.tabuleiro;


namespace Damas.Dama
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "o";
        }
    }
}
