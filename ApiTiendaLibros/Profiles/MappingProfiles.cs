using ApiTiendaLibros.Dtos;
using AutoMapper;
using Core.Entities;


namespace ApiTiendaLibros.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Cliente, ClienteDto>()
            .ReverseMap();
        CreateMap<Cliente, ClientesListDto>()
            //.ForMember(dest => dest.Cliente, origen => origen.MapFrom(origen => origen.Cliente.nombre_Cliente))
            .ReverseMap()
            .ForMember(origen => origen.libros_Cliente, dest => dest.Ignore());
        CreateMap<Cliente, ClienteAddUpdateDto>()
            .ReverseMap()
            .ForMember(origen => origen.libros_Cliente, dest => dest.Ignore());
        CreateMap<Libro, LibroDto>()
            .ForMember(dest => dest.Cliente, origen => origen.MapFrom(origen => origen.Cliente.nombre_Cliente))
            .ReverseMap()
            .ForMember(origen => origen.Cliente, dest => dest.Ignore());

        CreateMap<Libro, LibrosListDto>()
            .ForMember(dest => dest.Cliente, origen => origen.MapFrom(origen => origen.Cliente.nombre_Cliente))
            .ReverseMap()
            .ForMember(origen => origen.Cliente, dest => dest.Ignore());
        
        CreateMap<Libro, LibroAddUpdateDto>()
            .ReverseMap()
            .ForMember(origen => origen.Cliente, dest => dest.Ignore());
    }
}
