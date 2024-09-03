using WebApiProject.Models.Binding;
using WebApiProject.Models.ViewModel;

namespace WebApiProject.Shared.Services.Interfaces
{
    public interface IWebApiMovieServiceClient
    {
        ActorViewModel AddActor(ActorBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        MovieViewModel AddMovie(MovieBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        void DeleteActor(int id, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        void DeleteMovie(int id, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        ActorViewModel GetActor(int id, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        T GetActor<T>(int id, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        List<ActorViewModel> GetActors(Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        MovieViewModel GetMovie(int id, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        T GetMovie<T>(int id, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        List<MovieViewModel> GetMovies(Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        MovieViewModel Update(MovieUpdateBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
        ActorViewModel Update(ActorUpdateBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null);
    }
}