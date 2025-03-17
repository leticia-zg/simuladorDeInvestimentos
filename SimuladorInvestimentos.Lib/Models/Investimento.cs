namespace SimuladorInvestimentos.Lib.Models
{
    public abstract class Investimento
    {
        public decimal ValorInvestido { get; set; }
        protected int TempoMeses { get; set; }
        private decimal Rendimento { get; set; }
        internal string TipoInvestimento { get; set; }
        protected internal decimal TaxaDeRendimento { get; set; }
        private protected int CodigoInvestimento { get; set; }

        public abstract decimal CalcularRendimento();

        public Investimento(decimal valorInvestido, int tempoMeses)
        {
            ValorInvestido = valorInvestido;
            TempoMeses = tempoMeses;
        }
    }
}
