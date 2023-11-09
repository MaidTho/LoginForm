using AutoMapper;
using LoginForm.Models;

namespace LoginForm.Configurations
{
    public class MapperConfig : Profile
    {

        public MapperConfig()
        {
            CreateMap<PlayDate, PlayDateVM>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserVM>().ReverseMap();
        }

    }
}
