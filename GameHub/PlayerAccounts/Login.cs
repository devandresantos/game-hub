using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameHub.PlayerAccounts
{
    public class Login
    {
        private bool _logado;

        public bool Logado
        {
            get { return _logado; }
            set { _logado = value; }
        }

        public bool FazLogin()
        {
            int loginsCorretos = 0;

            for (int x = 0; x < 2; x++)
            {
                Console.WriteLine("\n--------------- Login ---------------\n");
                Console.Write("Informe seu nome de usuário: ");
                string nomeUsuario = Console.ReadLine();

                Console.Write("Informe sua senha: ");
                string senhaUsuario = Console.ReadLine();

                Console.ReadKey();

                string caminhoArquivo = "dadosDosUsuarios.json";

                if (File.Exists(caminhoArquivo))
                {

                    string conteudoArquivo = File.ReadAllText(caminhoArquivo);
                    List<JsonElement> objetos = JsonSerializer.Deserialize<List<JsonElement>>(conteudoArquivo);

                    for (int i = 0; i < objetos.Count; i++)
                    {
                        string nome = objetos[i].GetProperty("Nome").GetString();
                        string senha = objetos[i].GetProperty("Senha").GetString();

                        if (nome == nomeUsuario && senha == senhaUsuario)
                        {
                            Console.Clear();
                            Console.WriteLine("Bem vindo(a) ao GameHub\n");
                            Console.WriteLine($"{nome}, você está logado!\n");
                            Logado = true;
                            loginsCorretos++;
                            break;
                            //return true;
                        }
                    }

                    if (!Logado)
                    {
                        Console.WriteLine("Erro de login!");
                    }

                    Console.ReadKey();
                    //return false;

                }
                else
                {
                    Console.WriteLine("Nenhum usuário cadastrado!");
                    Console.ReadKey();
                    //return false;
                }

                Console.Clear();
            }

            if (loginsCorretos == 2) return true;
            else return false;
        }

    }
}
