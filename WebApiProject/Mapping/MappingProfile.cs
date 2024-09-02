using AutoMapper;
using WebApiProject.Models.Binding;
using WebApiProject.Models.Dbo;
using WebApiProject.Models.ViewModel;

namespace WebApiProject.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MovieBinding, Movie>();
            CreateMap<MovieUpdateBinding, Movie>();
            CreateMap<Movie, MovieViewModel>();

            CreateMap<ActorBinding, Actor>();
            CreateMap<ActorUpdateBinding, Actor>();
            CreateMap<Actor, ActorViewModel>();

        }
    }
}
