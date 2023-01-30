using GameHub.Hash.Model;
using NavalBattle.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NavalBattle.Model
{
    interface IJogar
    {
        void Jogar();
    }
    internal class Jogo
    {

        private Jogador jogador1;
        private Jogador jogador2;

        public Jogo()
        {
            jogador1 = new Jogador("jogador 1");
            jogador2 = new Jogador("jogador 2");
        }

        public void Jogar()
        {

            

            MostrarRanking();



            Console.ReadKey();

            const int QTDE_NAVIOS = 10;

            for (int i = 0; i < QTDE_NAVIOS; i++)
            {
                Console.Clear();
                Console.WriteLine("jogador 1\n");
                jogador1.Tabuleiro.MostraTabuleiro(jogador1.Navio);
                jogador1.Navio.ObtemInformacoesSobreNavio();
                jogador1.Tabuleiro.ObtemPosicaoNavio();
                jogador1.Tabuleiro.DesenhaNavio(jogador1.Navio.TamanhoNavio, jogador1.Navio.OrientacaoNavio);
                jogador1.Tabuleiro.MostraTabuleiro(jogador1.Navio);
                jogador1.Navio.NomeNavio = jogador1.Tabuleiro.nomeNavio;
                jogador1.Navio.ListaDeNavios = jogador1.Tabuleiro.posicaoNavio;
                jogador1.Tabuleiro.ResetaTabuleiro();
                jogador1.Tabuleiro.MostraTabuleiro(jogador1.Navio);
            }

            for (int i = 0; i < QTDE_NAVIOS; i++)
            {
                Console.Clear();
                Console.WriteLine("jogador 2\n");
                jogador2.Tabuleiro.MostraTabuleiro(jogador2.Navio);
                jogador2.Navio.ObtemInformacoesSobreNavio();
                jogador2.Tabuleiro.ObtemPosicaoNavio();
                jogador2.Tabuleiro.DesenhaNavio(jogador2.Navio.TamanhoNavio, jogador2.Navio.OrientacaoNavio);
                jogador2.Tabuleiro.MostraTabuleiro(jogador2.Navio);
                jogador2.Navio.NomeNavio = jogador2.Tabuleiro.nomeNavio;
                jogador2.Navio.ListaDeNavios = jogador2.Tabuleiro.posicaoNavio;
                jogador2.Tabuleiro.ResetaTabuleiro();
                jogador2.Tabuleiro.MostraTabuleiro(jogador2.Navio);
            }

            //Console.WriteLine("\nPressione qualquer tecla para iniciar o jogo...");
            Console.ReadKey();

            bool alternaJogador = true;
            bool vitoriaJogador1 = false;
            bool vitoriaJogador2 = false;

            while (true)
            {
                if (alternaJogador)
                {
                    Console.Clear();
                    Console.WriteLine("jogador 1\n");
                    jogador2.Tabuleiro.MostraTabuleiro(jogador2.Navio);
                    jogador2.Navio.AtacaNavioInimigo();
                    jogador2.Tabuleiro.AlteraTabuleiro(jogador2.Navio.LocalTiro, jogador2.Navio.PosicaoTiro);
                    jogador2.Tabuleiro.MostraTabuleiro(jogador2.Navio);

                    if (jogador2.Navio.AcertouNavio)
                    {
                        jogador2.Navio.AcertouNavio = false;
                        alternaJogador = true;
                    }
                    else
                    {
                        alternaJogador = false;
                    }

                    if (jogador2.Navio.JogadorVenceu)
                    {
                        Console.WriteLine("O jogador 1 venceu!");
                        vitoriaJogador1 = true;
                        jogador2.Navio.JogadorVenceu = false;
                        break;
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("jogador 2\n");
                    jogador1.Tabuleiro.MostraTabuleiro(jogador1.Navio);
                    jogador1.Navio.AtacaNavioInimigo();
                    jogador1.Tabuleiro.AlteraTabuleiro(jogador1.Navio.LocalTiro, jogador1.Navio.PosicaoTiro);
                    jogador1.Tabuleiro.MostraTabuleiro(jogador1.Navio);

                    if (jogador1.Navio.AcertouNavio)
                    {
                        jogador1.Navio.AcertouNavio = false;
                        alternaJogador = false;
                    }
                    else
                    {
                        alternaJogador = true;
                    }

                    if (jogador1.Navio.JogadorVenceu)
                    {
                        Console.WriteLine("O jogador 2 venceu!");
                        vitoriaJogador2 = true;
                        jogador1.Navio.JogadorVenceu = false;
                        break;
                    }

                }
            }

            // navalBattleRanking

            var dadosJogador1 = new
            {
                NomeJogador = "jogador 1",
                TirosNavio = jogador2.Navio.TirosNavio,
                TirosAgua = jogador2.Navio.TirosAgua,
                Vitoria = vitoriaJogador1
            };

            var dadosJogador2 = new
            {
                NomeJogador = "jogador 2",
                TirosNavio = jogador1.Navio.TirosNavio,
                TirosAgua = jogador1.Navio.TirosAgua,
                Vitoria = vitoriaJogador2
            };

            SalvaRanking(dadosJogador1, dadosJogador2);

            //Console.WriteLine("ACERTOU NAVIO JG1: " + jogador2.Navio.TirosNavio);
            //Console.WriteLine("TIRO NA ÁGUA JG1: " + jogador2.Navio.TirosAgua);

            //Console.WriteLine("ACERTOU NAVIO JG2: " + jogador1.Navio.TirosNavio);
            //Console.WriteLine("TIRO NA ÁGUA JG2: " + jogador1.Navio.TirosAgua);

            //Console.ReadKey();

        }

        public void SalvaRanking(Object dadosJogador1, Object dadosJogador2)
        {
          

            string caminhoArquivo = "navalBattleRanking.json";

            List<Object> dadosList = new List<Object>();
            if (File.Exists(caminhoArquivo))
            {
                string conteudoArquivo = File.ReadAllText(caminhoArquivo);
                dadosList = JsonSerializer.Deserialize<List<Object>>(conteudoArquivo);
            }

            dadosList.Add(dadosJogador1);
            dadosList.Add(dadosJogador2);

            string json = JsonSerializer.Serialize(dadosList);
            File.WriteAllText(caminhoArquivo, json);
        }

        public void MostrarRanking()
        {
            Console.Clear();
            Console.WriteLine("Ranking dos melhores jogadores:\n");


            string caminhoArquivo = "navalBattleRanking.json";

            if (File.Exists(caminhoArquivo))
            {

                string conteudoArquivo = File.ReadAllText(caminhoArquivo);
                List<JsonElement> objetos = JsonSerializer.Deserialize<List<JsonElement>>(conteudoArquivo);

                var counts = new Dictionary<string, (int tirosNavio, int tirosAgua, int vitoria)>();

                foreach (var item in objetos)
                {
                    var name = item.GetProperty("NomeJogador").GetString();
                    var tirosNavio = item.GetProperty("TirosNavio").GetInt32();
                    var tirosAgua = item.GetProperty("TirosAgua").GetInt32();
                    var vitoria = item.GetProperty("Vitoria").GetBoolean() ? 1 : 0;

                    if (counts.ContainsKey(name))
                    {
                        var currentCount = counts[name];
                        counts[name] = (currentCount.tirosNavio + tirosNavio, currentCount.tirosAgua + tirosAgua, currentCount.vitoria + vitoria);
                    }
                    else
                    {
                        counts[name] = (tirosNavio, tirosAgua, vitoria);
                    }
                }

                foreach (var count in counts)
                {
                    Console.WriteLine("Nome do jogador: {0}", count.Key);
                    Console.WriteLine("Tiros nos navios: {0}", count.Value.tirosNavio);
                    Console.WriteLine("Tiros na água: {0}", count.Value.tirosAgua);
                    Console.WriteLine("Vitórias: {0}", count.Value.vitoria);
                    Console.WriteLine();
                }

                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Nenhum ranking foi gravado!");
                Console.ReadKey();
            }




        }

    }
}
