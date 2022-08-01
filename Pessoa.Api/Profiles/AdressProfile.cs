using AutoMapper;
using Pessoa.Api.Models.DTO.EnderecoDTO;
using Pessoa.Entity.Endereco;
using Pessoa.Entity.Pessoal;

namespace Pessoa.Api.Profiles
{
    public class AdressProfile:Profile
    {

        public AdressProfile()
        {
            CreateMap<CreateEnderecoDTO, Adress>();
            CreateMap<People, ReadEnderecoDTO>();
            CreateMap<UpdateEnderecoDTO, Adress>();
        }
    }
}
