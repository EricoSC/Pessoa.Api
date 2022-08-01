using Pessoa.Api.Models.DTO.EnderecoDTO;
using Pessoa.Entity.Endereco;

namespace Pessoa.Api.Models.DTO.PessoalDTO
{
    public class CreatePessoalDTO
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public Adress Endereco { get; set; }
    }
}
