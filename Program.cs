using System;

class Program
{
    static void Main(string[] args)
    {
        // Variáveis de controle da conta
        bool contaAberta = false;
        string nome = "";
        double saldo = 0;
        double limiteChequeEspecial = 0;
        int opcao = -1;

        while (opcao != 4)
        {
            // Chamada das funções do professor
            ExibirTitulo();
            ExibirMenu();
            
            // Valida se a entrada é um número
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida!");
                continue;
            }

            // Impede acessar outras opções se a conta não estiver aberta
            if (opcao > 0 && opcao < 4 && !contaAberta)
            {
                Console.WriteLine("\n-> Erro: Você precisa abrir uma conta primeiro (Opção 0)!");
                continue;
            }

            switch (opcao)
            {
                case 0:
                    ExibirTitulo();
                    Console.WriteLine();
                    Console.Write("Nome: ");
                    nome = Console.ReadLine();
                    Console.Write("Depósito inicial: ");
                    saldo = double.Parse(Console.ReadLine());
                    Console.Write("Limite de cheque especial: ");
                    limiteChequeEspecial = double.Parse(Console.ReadLine());
                    contaAberta = true;
                    break;

                case 1:
                    ExibirTitulo();
                    Console.WriteLine();
                    Console.WriteLine($"Seu saldo é de: R$ {saldo:F2}");
                    Console.WriteLine($"Limite de cheque especial: R$ {limiteChequeEspecial:F2}");
                    break;

                case 2:
                    ExibirTitulo();
                    Console.WriteLine();
                    Console.WriteLine($"Cliente: {nome}.");
                    Console.Write("Informe um valor para saque: ");
                    double valorSaque = double.Parse(Console.ReadLine());

                    if (saldo - valorSaque < -limiteChequeEspecial)
                    {
                        Console.WriteLine("\n-> Seu limite atual não permite esta operação!");
                    }
                    else
                    {
                        saldo -= valorSaque;
                        
                        if (saldo < 0)
                        {
                            Console.WriteLine("-> Você está utilizando seu cheque especial");
                        }
                        
                        Console.WriteLine($"-> Seu saldo é de R$ {saldo:F2}");
                    }
                    break;

                case 3:
                    ExibirTitulo();
                    Console.WriteLine();
                    Console.WriteLine($"Cliente: {nome}.");
                    Console.Write("Informe um valor para depósito: ");
                    double valorDeposito = double.Parse(Console.ReadLine());
                    
                    saldo += valorDeposito;
                    Console.WriteLine($"\n-> Seu saldo atual é de R$ {saldo:F2}");
                    break;

                case 4:
                    ExibirTitulo();
                    Console.WriteLine();
                    Console.WriteLine("Obrigado por utilizar nossos serviços");
                    Console.WriteLine($"\nValor a receber: R$ {saldo:F2}");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }

    // Função exata enviada na imagem do professor
    static void ExibirTitulo()
    {
        string TITULO = @"---- MongaBank - Seu dinheiro rende mais! ----" + "\n";
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine(TITULO);
        Console.ResetColor();
    }

    // Função exata enviada na imagem do professor
    static void ExibirMenu()
    {
        Console.WriteLine("Selecione uma opção abaixo:\n");
        Console.BackgroundColor = ConsoleColor.White;

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("0 - Abrir Conta Corrente");

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("1 - Saldo");

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("2 - Saque");

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("3 - Depósito");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("4 - Encerrar conta e sair");

        Console.ResetColor();
        Console.Write("\nOpção: ");
    }
}
