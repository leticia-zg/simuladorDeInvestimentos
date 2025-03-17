using SimuladorInvestimentos.Lib.Models;

namespace SimuladorInvestimentos.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Simulador de Investimentos");
            Console.WriteLine();

            decimal valorInvestido = ObterValorInvestido(args);
            int tempoMeses = ObterTempoMeses(args);
            Investimento investimento = EscolherTipoInvestimento(args, valorInvestido, tempoMeses);

            if (investimento == null) 
            {
                Console.WriteLine("Nenhum investimento foi selecionado corretamente.");
                return;
            }

            decimal rendimento = investimento.CalcularRendimento();
            Console.WriteLine($"Valor final após {tempoMeses} meses: {rendimento:C}");

            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        private static decimal ObterValorInvestido(string[] args)
        {
            const string mensagemValor = "Por favor, digite o valor investido:";
            const string campoValor = "valor investido";
            return ObterValor(args, 0, campoValor, mensagemValor);
        }

        private static decimal ObterValor(string[] args, int index, string campo, string mensagem)
        {
            decimal valor = 0; 
            if (args.Length > index && decimal.TryParse(args[index], out valor))
            {
                return valor;
            }

            Console.WriteLine(mensagem);
            string input = Console.ReadLine();
            while (!decimal.TryParse(input, out valor))
            {
                Console.WriteLine("Valor inválido. Tente novamente:");
                input = Console.ReadLine();
            }

            return valor;
        }

        private static int ObterTempoMeses(string[] args)
        {
            const string mensagemTempo = "Por favor, digite o tempo em meses para o investimento:";
            return ObterInteiro(args, 1, "tempo de meses", mensagemTempo);
        }

        private static int ObterInteiro(string[] args, int index, string campo, string mensagem)
        {
            int tempoMeses = 0; 
            if (args.Length > index && int.TryParse(args[index], out tempoMeses))
            {
                return tempoMeses;
            }

            Console.WriteLine(mensagem);
            string input = Console.ReadLine();
            while (!int.TryParse(input, out tempoMeses))
            {
                Console.WriteLine("Valor inválido. Tente novamente:");
                input = Console.ReadLine();
            }

            return tempoMeses;
        }

        private static Investimento EscolherTipoInvestimento(string[] args, decimal valorInvestido, int tempoMeses)
        {
            Console.WriteLine("Escolha o tipo de investimento:");
            Console.WriteLine("1 - Renda Fixa");
            Console.WriteLine("2 - Ações");

            int tipoInvestimento = ObterTipoInvestimento(args);

            return tipoInvestimento switch
            {
                1 => new RendaFixa(valorInvestido, tempoMeses),
                2 => new Acoes(valorInvestido, tempoMeses),
                _ => null 
            };
        }

        private static int ObterTipoInvestimento(string[] args)
        {
            int tipoEscolha = 0;
            if (args.Length > 2 && int.TryParse(args[2], out tipoEscolha))
            {
                return tipoEscolha;
            }

            Console.WriteLine("Por favor, digite a opção de tipo de investimento (1 ou 2):");
            while (!int.TryParse(Console.ReadLine(), out tipoEscolha) || (tipoEscolha != 1 && tipoEscolha != 2))
            {
                Console.WriteLine("Opção inválida. Digite 1 para Renda Fixa ou 2 para Ações.");
            }

            return tipoEscolha;
        }
    }
}
