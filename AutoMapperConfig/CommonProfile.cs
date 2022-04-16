using Asp.netCore_MVC_.Models;
using Asp.netCore_MVC_.ViewModel;
using AutoMapper;

namespace Asp.netCore_MVC_.AutoMapperConfig
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            //CreateMap<Book, BookViewModel>().ReverseMap();
        }
    }
}
