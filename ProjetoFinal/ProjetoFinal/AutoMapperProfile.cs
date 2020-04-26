using AutoMapper;
using ProjetoFinal.DTOs;
using ProjetoFinal.Models;

namespace ProjetoFinal
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Evento, EventoDTO>().ReverseMap();
        }
    }
}