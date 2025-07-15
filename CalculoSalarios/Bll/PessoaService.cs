using CalculoSalarios.DAL;
using CalculoSalarios.Models;
using System.Collections.Generic;

namespace CalculoSalarios.BLL
{
    public class PessoaService
    {
        private readonly PessoaRepository pessoaRepository;
        private readonly CargoRepository cargoRepository;

        public PessoaService()
        {
            pessoaRepository = new PessoaRepository();
            cargoRepository = new CargoRepository();
        }

        public void AdicionarPessoa(Pessoa pessoa)
        {
            pessoaRepository.Inserir(pessoa);
        }

        public List<Cargo> ObterCargosAtivos()
        {
            return cargoRepository.ObterCargosAtivos();
        }
        public void ExcluirPessoaPorEmail(string matricula)
        {
            pessoaRepository.ExcluirPessoaPorEmail(matricula);
        }
    }
}
