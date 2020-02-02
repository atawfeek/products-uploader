using AutoMapper;
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
        }

    }
}
