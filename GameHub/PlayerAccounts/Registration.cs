using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace GameHub.PlayerAccounts
{
    internal class Registration
    {
        public bool VerificaConta()
        {
            Console.WriteLine("Bem vindo(a) ao GameHub\n");

            Console.WriteLine("1 - Fazer login");
            Console.WriteLine("2 - Fazer cadastro");
            Console.Write("\nEscolha uma das opções: ");

            string op = Console.ReadLine();

            Login login = new Login();

            switch (op)
            {
                case "1":
                    return login.FazLogin();
                case "2":
                    return CadastraJogador();
                default:
                    return false;
            }
        }

        public bool CadastraJogador()
        {
            Console.WriteLine("\n--------------- Cadastro ---------------\n");

            Console.Write("Informe um nome de usuário: ");
            string nomeUsuario = Console.ReadLine();

            Console.Write("Informe uma senha: ");
            string senhaUsuario = Console.ReadLine();


            var dados = new
            {
                Nome = nomeUsuario,
                Senha = senhaUsuario
            };

            string caminhoArquivo = "dadosDosUsuarios.json";

            List<Object> dadosList = new List<Object>();
            if (File.Exists(caminhoArquivo))
            {
                string conteudoArquivo = File.ReadAllText(caminhoArquivo);
                dadosList = JsonSerializer.Deserialize<List<Object>>(conteudoArquivo);
            }

            dadosList.Add(dados);

            string json = JsonSerializer.Serialize(dadosList);
            File.WriteAllText(caminhoArquivo, json);

            Console.WriteLine("\nJogador cadastrado com sucesso!");
            Console.ReadKey();

            Login login = new Login();

            return login.FazLogin();

        }
    }
}
