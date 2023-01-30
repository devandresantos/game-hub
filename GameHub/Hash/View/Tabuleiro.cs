using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHub.Hash.View
{
    public class Tabuleiro
    {
        public void MostrarJogoDaVelha(string jogador, string[,] tabuleiro)
        {

            Console.Clear();
            Console.WriteLine("Jogo da velha\n");
            Console.WriteLine($" {tabuleiro[0, 0]} | {tabuleiro[0, 1]} | {tabuleiro[0, 2]} ");
            Console.WriteLine($"---|---|---");
            Console.WriteLine($" {tabuleiro[1, 0]} | {tabuleiro[1, 1]} | {tabuleiro[1, 2]} ");
            Console.WriteLine($"---|---|---");
            Console.WriteLine($" {tabuleiro[2, 0]} | {tabuleiro[2, 1]} | {tabuleiro[2, 2]} ");

            string nomeMarcador = "";
            if (jogador == "1") nomeMarcador = "xis";
            else if (jogador == "2") nomeMarcador = "círculo";

            Console.Write($"\njogador {jogador}, digite um dos número acima para marcar com {nomeMarcador}: ");

        }

    }
}
