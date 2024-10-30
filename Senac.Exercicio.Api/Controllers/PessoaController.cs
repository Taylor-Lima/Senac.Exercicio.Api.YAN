using Microsoft.AspNetCore.Mvc;
using Senac.Exercicio.Domain.DTO;
using Senac.Exercicio.Domain.Entities;
using Senac.Exercicio.Service;


namespace Senac.Exercicio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController
    {
        [HttpGet]
        public List<PessoaEntity> ObterPessoas()
            => new PessoaService().ObterPessoas();

        [HttpPost]
        public bool GravarPessoa(PessoaInputModel input)
            => new PessoaService().GravarPessoa(input);
    }
}
//