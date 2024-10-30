using Microsoft.AspNetCore.Mvc;
using Senac.Exercicio.Domain.DTO;
using Senac.Exercicio.Domain.Entities;
using Senac.Exercicio.Infraestrutura.Repository;
using Senac.Exercicio.Service;


namespace Senac.Exercicio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController
    {
        [HttpGet, Route("cpf")]
        public List<PessoaEntity> ObterPessoas(string cpf)
            => new PessoaService().ObterPessoas(cpf);

        [HttpPost, Route("nome")]
        public List<PessoaEntity> ObterPessoasPorNome(string nome)
            => new PessoaRepository().ObterPessoasPorNome(nome);

        [HttpGet, Route("all")]
        public List<PessoaEntity> ObterPessoas()
            => new PessoaService().ObterPessoas();

        [HttpPost]
        public bool GravarPessoa(PessoaInputModel input)
            => new PessoaService().GravarPessoa(input);
    }
}
//