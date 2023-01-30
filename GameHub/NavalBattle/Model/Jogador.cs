using NavalBattle.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalBattle.Model
{
    internal class Jogador
    {
        private string _nome;
        private Tabuleiro _tabuleiro;
        private Navio _navio;

        public Jogador(string nome)
        {
            _nome = nome;
            _tabuleiro = new Tabuleiro();
            _navio = new Navio();
        }

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        public Tabuleiro Tabuleiro
        {
            get { return _tabuleiro; }
            set { _tabuleiro = value; }
        }

        public Navio Navio
        {
            get { return _navio; }
            set { _navio = value; }
        }

    }
}
