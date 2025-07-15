using System;

namespace CalculoSalarios.Models
{
    public class Pessoa
    {
        public string Matricula { get; set; } 
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Pais { get; set; }
        public string Usuario { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string Cpf { get; set; }
        
        public bool Ativo { get; set; }
    }
}
