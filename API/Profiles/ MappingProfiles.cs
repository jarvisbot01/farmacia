using API.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;

public class MappingProfles : Profile
{
    public MappingProfles()
    {
        CreateMap<Cliente, ClienteDto>().ReverseMap();

        CreateMap<Compra, CompraDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<DetalleVenta, DetalleVentaDto>()
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Empleado, EmpleadoDto>()
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Lote, LoteDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Medicamento, MedicamentoDto>()
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Proveedor, ProveedorDto>().ReverseMap();

        CreateMap<RecetaMedica, RecetaMedicaDto>()
            .ReverseMap()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Rol, RolDto>().ReverseMap();

        CreateMap<Venta, VentaDto>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
