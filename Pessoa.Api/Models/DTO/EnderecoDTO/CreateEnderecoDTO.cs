namespace Pessoa.Api.Models.DTO.EnderecoDTO
{
    public class CreateEnderecoDTO
    {
        public string Uf { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }

    }
}
