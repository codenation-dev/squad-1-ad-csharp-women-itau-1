using AutoMapper;
using ProjetoFinal.DTOs;
using ProjetoFinal.Models;

namespace ProjetoFinal
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Ambiente, AmbienteDTO>().ReverseMap();
            CreateMap<Erro, ErroDTO>().ReverseMap();
            CreateMap<Nivel, NivelDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}