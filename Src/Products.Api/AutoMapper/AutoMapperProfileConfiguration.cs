using AutoMapper;
using Products.Domain;
using Products.Domain.ProcessedFile.Abstraction;
using Products.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Api.AutoMapper
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration() : this("Profile")
        {

        }

        public AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<FileModelBase, AppFile>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size))
                .ForMember(dest => dest.UploadDT, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<ProductDomain, Service.Models.Product>()
                .ForMember(dest => dest.ArtikelCode, opt => opt.MapFrom(src => src.ArtikelCode))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.ColorCode, opt => opt.MapFrom(src => src.ColorCode))
                .ForMember(dest => dest.DeliveredIn, opt => opt.MapFrom(src => src.DeliveredIn))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DiscountPrice, opt => opt.MapFrom(src => src.DiscountPrice))
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Size))
                .ForMember(dest => dest.TargetAge, opt => opt.MapFrom(src => src.TargetAge));
        }

    }
}
