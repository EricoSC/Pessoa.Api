using AutoMapper;
using Pessoa.Api.Models.DTO.PessoalDTO;
using Pessoa.Entity.Pessoal;

namespace Pessoa.Api.Profiles
{
    public class PessoalProfile : Profile
    {
        public PessoalProfile()
        {
            CreateMap<CreatePessoalDTO, People>();
            CreateMap<People, ReadPessoalDTO>();
            CreateMap<UpdatePessoalDTO, People>();
        }
    }
}
