namespace SimuladorInvestimentos.Lib.Models
{
    public class Acoes : Investimento
    {
        public Acoes(decimal valorInvestido, int tempoMeses) : base(valorInvestido, tempoMeses)
        { }

        public override decimal CalcularRendimento()
        {
            decimal taxaJuros = 0.02m;
            return ValorInvestido * (1 + taxaJuros * TempoMeses);
        }
    }
}
