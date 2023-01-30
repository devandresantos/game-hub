using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalBattle.Model
{
    public class Navio
    {

        string[] letras = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o" };

        enum Orientacao
        {
            Vertical,
            Horizontal
        }

        private List<string> _nomeNavio = new List<string>();

        public List<string> NomeNavio
        {
            get { return _nomeNavio; }
            set { _nomeNavio = value; }
        }

        private List<int[]> _listaDeNavios = new List<int[]>();

        public List<int[]> ListaDeNavios
        {
            get { return _listaDeNavios; }
            set { _listaDeNavios = value; }
        }

        private int _tamanhoNavio;

        public int TamanhoNavio
        {
            get { return _tamanhoNavio; }
            set { _tamanhoNavio = value; }
        }

        private string _orientacaoNavio;

        public string OrientacaoNavio
        {
            get { return _orientacaoNavio; }
            set { _orientacaoNavio = value; }
        }

        private string _localTiro;

        public string LocalTiro
        {
            get { return _localTiro; }
            set { _localTiro = value; }
        }

        private int[] _posicaoTiro = new int[2];

        public int[] PosicaoTiro
        {
            get { return _posicaoTiro; }
            set { _posicaoTiro = value; }
        }

        private int _tirosAgua = 0;

        public int TirosAgua
        {
            get { return _tirosAgua; }
            set { _tirosAgua = value; }
        }

        private int _tirosNavio;

        public int TirosNavio
        {
            get { return _tirosNavio; }
            set { _tirosNavio = value; }
        }

        private bool _acertouNavio;

        public bool AcertouNavio
        {
            get { return _acertouNavio; }
            set { _acertouNavio = value; }
        }

        private bool _jogadorVenceu = false;

        public bool JogadorVenceu
        {
            get { return _jogadorVenceu; }
            set { _jogadorVenceu = value; }
        }

        public void ObtemInformacoesSobreNavio()
        {
            
            Console.WriteLine("");
            Console.WriteLine("1 - Porta-aviões");
            Console.WriteLine("2 - Navio-tanque");
            Console.WriteLine("3 - Contratorpedeiro");
            Console.WriteLine("4 - Submarino");

            Console.Write("\nEscolha o tipo de navio que deseja incluir: ");
            string opcaoTipoNavio = Console.ReadLine();

            switch (opcaoTipoNavio)
            {
                case "1":
                    TamanhoNavio = 5;
                    break;
                case "2":
                    TamanhoNavio = 4;
                    break;
                case "3":
                    TamanhoNavio = 3;
                    break;
                case "4":
                    TamanhoNavio = 2;
                    break;
            }

            Console.WriteLine("");
            Console.WriteLine($"1 - { Orientacao.Vertical }");
            Console.WriteLine($"2 - { Orientacao.Horizontal }");

            Console.Write("\nInforme a orientação do navio: ");
            string opcaoOrientacaoNavio = Console.ReadLine();

            switch (opcaoOrientacaoNavio)
            {
                case "1":
                    OrientacaoNavio = Orientacao.Vertical.ToString();
                    break;
                case "2":
                    OrientacaoNavio = Orientacao.Horizontal.ToString();
                    break;
            }
        }

        public void AtacaNavioInimigo()
        {
            Console.Write("Informe uma posição para atirar: ");
            string posicaoTiro = Console.ReadLine();

            int posicaoLinha = Array.IndexOf(letras, posicaoTiro[0].ToString());
            int posicaoColuna = Array.IndexOf(letras, posicaoTiro[1].ToString());
            bool tiroNaAgua = true;

            foreach (int[] navio in ListaDeNavios)
            {
                if(navio[0] == posicaoLinha && navio[1] == posicaoColuna)
                {
                    Console.WriteLine("\nAcertou o navio!");
                    AcertouNavio = true;
                    TirosNavio++;
                    LocalTiro = "  x";
                    tiroNaAgua = false;
                    navio[0] = -1;
                    navio[1] = -1;
                }
            }

            if (tiroNaAgua)
            {
                LocalTiro = "  ~";
                TirosAgua++;
                Console.WriteLine($"Tiro na água!");
            }
           
            PosicaoTiro[0] = posicaoLinha;
            PosicaoTiro[1] = posicaoColuna;

            List<int> partesAfundadas = new List<int>();

            foreach (int[] navio in ListaDeNavios)
            {
                foreach(int coordenada in navio)
                {
                    partesAfundadas.Add(coordenada);
                }
            }

            if(partesAfundadas.All(x => x == -1))
            {
                Console.WriteLine("Você venceu!");
                JogadorVenceu = true;
            }

            Console.ReadKey();
            Console.Clear();

        }

    }
}
