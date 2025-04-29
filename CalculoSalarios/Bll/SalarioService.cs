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

        public List<PessoaSalario> ObterSalarios(int paginaAtual)
        {
            int offset = paginaAtual * RegistrosPorPagina;
            return _repository.ObterSalarios(offset, RegistrosPorPagina);
        }

        public int ObterTotalPaginas()
        {
            int totalRegistros = _repository.ObterTotalRegistros();
            return (int)Math.Ceiling((double)totalRegistros / RegistrosPorPagina);
        }

        public void CalcularSalarios(decimal bonus)
        {
            _repository.CalcularSalarios(bonus);
        }
    }
}
