using NavalBattle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NavalBattle.View
{

     interface ITabuleiro
    {
        void MostraTabuleiro(Navio navio);
    }
    public class Tabuleiro : ITabuleiro
    {
        string[] letras = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o" };

        private int _posicaoLinha;

        public int PosicaoLinha
        {
            get { return _posicaoLinha; }
            set { _posicaoLinha = value; }
        }

        private int _posicaoColuna;

        public int PosicaoColuna
        {
            get { return _posicaoColuna; }
            set { _posicaoColuna = value; }
        }

        private static readonly int Q_LINHAS = 15;
        private static readonly int Q_COLUNAS = 15;

        public string[,] posicoesNavios = new string[Q_LINHAS, Q_COLUNAS];

        string[,] tabuleiro = {
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" },
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" },
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" },
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" },
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" },
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" },
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" },
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" },
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" },
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" },
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" },
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" },
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" },
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" },
            { "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -", "  -" }
        };

        public List<string> nomeNavio = new List<string>();
        public List<int[]> posicaoNavio = new List<int[]>();

        public void MostraTabuleiro(Navio navio)
        {

            //Console.Clear();
            Console.WriteLine("BATALHA NAVAL\n");

            Console.WriteLine("   a  b  c  d  e  f  g  h  i  j  k  l  m  n  o");

            for(int i = 0; i < Q_LINHAS; i++)
            {
                Console.Write(letras[i]);
                for (int j = 0; j < Q_COLUNAS; j++)
                {
                    Console.Write(tabuleiro[i, j]);
                }
                Console.Write("\n");
            }

            Console.WriteLine("");
            Console.WriteLine($"Tiros na água: { navio.TirosAgua }");
            Console.WriteLine($"Tiros no navio: { navio.TirosNavio }");
            Console.WriteLine("");

            Console.ReadKey();

        }

        public void ObtemPosicaoNavio()
        {
            Console.WriteLine("");
            Console.Write("Informe a coordenada do início do navio: ");

            string posicaoNavio = Console.ReadLine();

            PosicaoLinha = Array.IndexOf(letras, posicaoNavio[0].ToString());
            PosicaoColuna = Array.IndexOf(letras, posicaoNavio[1].ToString());

        }

        string nomeIDNavio;

        public void DesenhaNavio(int tamanhoNavio, string orientacaoNavio)
        {

            switch (tamanhoNavio)
            {
                case 2:
                    nomeIDNavio = "Submarino";
                    break;
                case 3:
                    nomeIDNavio = "Contratorpedeiro";
                    break;
                case 4:
                    nomeIDNavio = "Navio-tanque";
                    break;
                case 5:
                    nomeIDNavio = "Porta-aviões";
                    break;
            }

            nomeNavio.Add(nomeIDNavio);

            for (int i = 0; i < tamanhoNavio; i++)
            {
                tabuleiro[PosicaoLinha, PosicaoColuna] = "  #";

                posicaoNavio.Add(new int[] { PosicaoLinha, PosicaoColuna });

                if (orientacaoNavio == "Vertical") PosicaoLinha++;
                else if (orientacaoNavio == "Horizontal") PosicaoColuna++;
            }

            Console.Clear();

        }

        public void AlteraTabuleiro(string localTiro, int[] posicaoTiro)
        {
            tabuleiro[posicaoTiro[0], posicaoTiro[1]] = localTiro;
        }

        public void ResetaTabuleiro()
        {
            for (int i = 0; i < Q_LINHAS; i++)
            {
                for (int j = 0; j < Q_COLUNAS; j++)
                {
                    tabuleiro[i, j] = "  -";
                }
            }
        }
    }
}