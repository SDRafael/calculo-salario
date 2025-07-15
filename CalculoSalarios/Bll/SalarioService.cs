using CalculoSalarios.DAL;
using CalculoSalarios.Models;
using System;
using System.Collections.Generic;


namespace CalculoSalarios.BLL
{
    public class SalarioService
    {
        private readonly SalarioRepository _repository = new SalarioRepository();
        private const int RegistrosPorPagina = 20;
               
        public void CalcularSalarios(decimal bonus, decimal descontos)
        {
            _repository.CalcularSalarios(bonus, descontos);
        }
        public List<PessoaSalarioView> ObterSalarios(int paginaAtual, string cargo = "")
        {
            int offset = paginaAtual * RegistrosPorPagina;
            return _repository.ObterSalarios(offset, RegistrosPorPagina, cargo);
        }

        public int ObterTotalPaginas(string cargo = "")
        {
            int totalRegistros = _repository.ObterTotalRegistros(cargo);
            return (int)Math.Ceiling((double)totalRegistros / RegistrosPorPagina);
        }

        public List<Cargo> ObterTodosCargos()
        {
            return _repository.ObterTodosCargos();
        }


    }
}
