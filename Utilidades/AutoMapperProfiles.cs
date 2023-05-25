using AutoMapper;
using WebApiTienda.DTOs;
using WebApiTienda.Entidades;

namespace WebApiTienda.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
                     //DESTINO     ORIGEN
            CreateMap<Usuario, ListaUsuariosDTO>();
            CreateMap<ModificarUsuarioDTO, Usuario>(); //PUT


        }
    }
}
