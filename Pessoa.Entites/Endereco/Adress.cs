using Pessoa.Entity.Pessoal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pessoa.Entity.Endereco;

public class Adress
{
    [Key]
    [Required]
    public int EnderecoId { get; set; }
    public string Bairro { get; set; }
    public string Pais { get; set; }
    public string Estado { get; set; }
    public string Cidade { get; set; }
    public string CEP { get; set; }
    public string Rua { get; set; }
    public int Numero { get; set; }

    public int PessoaId { get; set; }
    [JsonIgnore]
    public People Pessoa { get; set; }

}