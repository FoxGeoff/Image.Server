using AutoMapper;

namespace Image.Server.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Entities.ProductImage, Models.ProductImage>();

            CreateMap<Entities.Product, Models.Product>();

            CreateMap<Models.ProductImageForCreation, Entities.ProductImage>();

           /*
           CreateMap<Api.Entities.Book, Api.Models.BookWithCovers>()
               .ForMember(dest => dest.Author, opt => opt.MapFrom(src =>
                   $"{src.Author.FirstName} {src.Author.LastName}"));
           CreateMap<IEnumerable<Api.ExternalModels.BookCover>, Api.Models.BookWithCovers>()
               .ForMember(dest => dest.bookCovers, opt => opt.MapFrom(src => src));
           */
        }
    }
}
