namespace CalculoSalarios.Models
{
    public class PessoaSalarioView
    {
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public decimal SalarioBase { get; set; }
        public decimal Bonus { get; set; }
        public decimal Descontos { get; set; }
        public decimal SalarioLiquido { get; set; }
    }

}
