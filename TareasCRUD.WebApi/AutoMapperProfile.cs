using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using TareasCRUD.Core.Entities;

namespace TareasCRUD.WebApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            //Entities to Models
            //CreateMap<Tipoactivo, TipoactivoModel>();

            //CreateMap<Activo, ActivoModel>();

            //CreateMap<Estado, EstadoModel>();

            //CreateMap<Cuenta, CuentaModel>();


            //Models to Entities

            //CreateMap<TipoactivoModel, Tipoactivo>();

            //CreateMap<ActivoModel, Activo>();

            //CreateMap<EstadoModel, Estado>();

            //CreateMap<CuentaModel, Cuenta>();


        }

    }
}
