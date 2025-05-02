using AutoMapper;
using DataTransferObjectLayer.Concrete;
using EntityLayer.Concrete;

namespace Trvaversal.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AboutImageDTO, AboutImage>()
                .ForMember(imageDTO => imageDTO.Image, opt => opt.Ignore());
            CreateMap<AboutImage, AboutImageDTO>()
                .ForMember(imageDTO => imageDTO.Image, opt => opt.Ignore()); ;

            CreateMap<AboutImageListDTO, AboutImage>();
            CreateMap<AboutImage, AboutImageListDTO>();
        }
    }
}
