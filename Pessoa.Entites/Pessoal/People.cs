using Pessoa.Entity.Endereco;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pessoa.Entity.Pessoal
{
    public class People
    {
        [Key]
        [Required]
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public Adress Endereco { get; set; }
    }
}
