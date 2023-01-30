using System;
using HashGame = GameHub.Hash.Model.Jogo;
using NavalBattleGame = NavalBattle.Model.Jogo;
using GameHub.PlayerAccounts;

namespace GameHub
{
    class Program
    {
        static void Main()
        {

            Registration registration = new Registration();
            bool logado = registration.VerificaConta();

            if (logado)
            {
                Console.WriteLine("Escolha um dos jogos abaixo:\n");

                Console.WriteLine("1 - Jogo da velha");
                Console.WriteLine("2 - Batalha naval");

                string op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        HashGame hashGame = new HashGame();
                        hashGame.Jogar();
                        break;
                    case "2":
                        NavalBattleGame navalBattleGame = new NavalBattleGame();
                        navalBattleGame.Jogar();
                        break;
                }
            }

        }
    }
}