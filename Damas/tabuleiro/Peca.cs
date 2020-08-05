using System;

namespace Damas.tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int QtdMovimentos { get; set; }
        public Tabuleiro Tab { get; set; }

        public Peca(Posicao posicao, Cor cor, int qtdMovimentos, Tabuleiro tab)
        {
            Posicao = posicao;
            Cor = cor;
            QtdMovimentos = qtdMovimentos;
            Tab = tab;
        }
    }
}
