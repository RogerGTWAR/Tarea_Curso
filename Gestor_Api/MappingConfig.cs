using AutoMapper;
using SharedModels;
using SharedModels.Dto.EmpleadosDatos;
using SharedModels.Dto.Ingresos;
using SharedModels.Dto.Login;

namespace Gestor_Api
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<EmpleadoDatos, EmpleadosDto>().ReverseMap();
            CreateMap<EmpleadoDatos, EmpleadosCreateDto>().ReverseMap();
            CreateMap<EmpleadoDatos, EmpleadosUpdateDto>().ReverseMap();
            CreateMap<User, RegisterUserDto>().ReverseMap();
            CreateMap<Ingresos, IngresosDto>().ReverseMap();
            CreateMap<Ingresos, IngresosCreateDto>().ReverseMap();
            CreateMap<Ingresos, IngresosUpdateDto>().ReverseMap();
        }
    }
}
