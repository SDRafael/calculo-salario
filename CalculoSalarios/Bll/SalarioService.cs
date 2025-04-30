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
               
        public void CalcularSalarios(decimal bonus)
        {
            _repository.CalcularSalarios(bonus);
        }
        public List<PessoaSalario> ObterSalarios(int paginaAtual, int cargoId = 0)
        {
            int offset = paginaAtual * RegistrosPorPagina;
            return _repository.ObterSalarios(offset, RegistrosPorPagina, cargoId);
        }

        public int ObterTotalPaginas(int cargoId = 0)
        {
            int totalRegistros = _repository.ObterTotalRegistros(cargoId);
            return (int)Math.Ceiling((double)totalRegistros / RegistrosPorPagina);
        }

        public List<Cargo> ObterTodosCargos()
        {
            return _repository.ObterTodosCargos();
        }


    }
}
