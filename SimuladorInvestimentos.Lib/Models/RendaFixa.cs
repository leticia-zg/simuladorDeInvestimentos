namespace SimuladorInvestimentos.Lib.Models
{
    public class RendaFixa : Investimento
    {
        public RendaFixa(decimal valorInvestido, int tempoMeses) : base(valorInvestido, tempoMeses)
        { }

        public override decimal CalcularRendimento()
        {
            decimal taxaJuros = 0.005m;
            return ValorInvestido * (1 + taxaJuros * TempoMeses);
        }
    }
}
