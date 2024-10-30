using Senac.Exercicio.Domain.Entities;
using Senac.Exercicio.Infraestrutura.Data;
using System.Data;

namespace Senac.Exercicio.Infraestrutura.Repository
{
    public class PessoaRepository
    {
        public List<PessoaEntity> ObterPessoas()
        {
            BancoInstance banco;
            DataTable retorno = new DataTable();
            using(banco=new BancoInstance())
            {
                banco.Banco.ExecuteQuery(@"select * from Pessoa order by Nome",out retorno); 
            }
            return ConvertList(retorno);
        }
        //
        public bool Gravar(PessoaEntity obj)
        {
            BancoInstance banco;
            using(banco =new BancoInstance()) 
            {
                return banco.Banco.ExecuteNonQuery(@"insert into Pessoa (Nome, Cpf, DataNascimento, Situacao) values (@nome, @cpf, @dtNasc, @situacao)", "@nome", obj.Nome, "@cpf", obj.Cpf, "@dtNasc", obj.DataNascimento, "@situacao", obj.Situacao);
            }
        }

        private List<PessoaEntity> ConvertList(DataTable dtDados)
        {
            List<PessoaEntity> listaRetorno = new List<PessoaEntity>();

            //Verificando se a consulta retornou alguma informação
            if(dtDados.Rows.Count == 0 ) 
                return listaRetorno;//A consolta não encontrou nada, retorna a lista vazia

            for(int i = 0; i < dtDados.Rows.Count; i++)
            {
                listaRetorno.Add(new PessoaEntity(
                    Convert.ToInt32(dtDados.Rows[i]["Id"]),
                    dtDados.Rows[i]["Nome"].ToString(),
                    dtDados.Rows[i]["Cpf"].ToString(),
                    Convert.ToDateTime(dtDados.Rows[i]["DataNascimento"].ToString()),
                    Convert.ToBoolean(dtDados.Rows[i]["Situacao"].ToString())));
            }
            return listaRetorno;
        }
    }
}
