using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Tranferir");
            Console.WriteLine();

            Console.WriteLine("Conta Origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.WriteLine("Conta Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());
            Console.WriteLine("Valor R$: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Depositar");
            Console.WriteLine();

            Console.WriteLine("Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Valor R$: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Sacar");
            Console.WriteLine();

            Console.WriteLine("Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Valor R$: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");
            Console.WriteLine();

            if (listContas.Count == 0) {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            for (int i = 0; i < listContas.Count; i++) {
                Conta conta = listContas[i];
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir Conta");
            Console.WriteLine();
            Console.WriteLine("Tipo da Conta: 1 = Pessoa Fisica 2 = Pessoa Juridica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Nome do Cliente:");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Saldo Inicial:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Credito:");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu dispor!!!");
            Console.WriteLine("Informa a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpa tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

    }
}
