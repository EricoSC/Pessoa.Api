using Pessoa.Entity.Endereco;
using Pessoa.Entity.Pessoal;

namespace Pessoa.Api.Models.DTO.PessoalDTO
{
    public class ReadPessoalDTO
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public Adress Endereco { get; set; }
    }
}
