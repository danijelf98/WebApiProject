using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Models.Binding;
using WebApiProject.Models.ViewModel;
using WebApiProject.Shared.Services.Interfaces;

namespace WebApiProject.Shared.Services.Implementations
{
    public class WebApiMovieServiceClient : WebApiServiceClientBase, IWebApiMovieServiceClient
    {
        public WebApiMovieServiceClient(HttpClient httpClient, Action<HttpResponseMessage> unsuccessfulResponseAction) : base(httpClient, unsuccessfulResponseAction)
        {
        }

        #region Movies CRUD

        public MovieViewModel GetMovie(int id, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<MovieViewModel>($"api/movie/{id}", HttpMethod.Get, true, unsuccessfulResponseAction);
        }
        public T GetMovie<T>(int id, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<T>($"api/movie/{id}", HttpMethod.Get, true, unsuccessfulResponseAction);
        }
        public void DeleteMovie(int id, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            DoRequestAndTryGetResponseContent<MovieViewModel>($"api/movie/{id}", HttpMethod.Delete, false, unsuccessfulResponseAction);
        }
        public MovieViewModel AddMovie(MovieBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<MovieViewModel>("api/movie", HttpMethod.Post, true, unsuccessfulResponseAction, model);
        }
        public MovieViewModel Update(MovieUpdateBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<MovieViewModel>("api/movie", HttpMethod.Put, true, unsuccessfulResponseAction, model);
        }
        public List<MovieViewModel> GetMovies(Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<List<MovieViewModel>>($"api/movie/movies", HttpMethod.Get, true, unsuccessfulResponseAction);
        }

        #endregion

        #region Actor CRUD

        public ActorViewModel GetActor(int id, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<ActorViewModel>($"api/actor/{id}", HttpMethod.Get, true, unsuccessfulResponseAction);
        }
        public T GetActor<T>(int id, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<T>($"api/actor/{id}", HttpMethod.Get, true, unsuccessfulResponseAction);
        }
        public void DeleteActor(int id, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            DoRequestAndTryGetResponseContent<ActorViewModel>($"api/actor/{id}", HttpMethod.Delete, false, unsuccessfulResponseAction);
        }
        public ActorViewModel AddActor(ActorBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<ActorViewModel>("api/actor", HttpMethod.Post, true, unsuccessfulResponseAction, model);
        }
        public ActorViewModel Update(ActorUpdateBinding model, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<ActorViewModel>("api/actor", HttpMethod.Put, true, unsuccessfulResponseAction, model);
        }
        public List<ActorViewModel> GetActors(Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            return DoRequestAndTryGetResponseContent<List<ActorViewModel>>($"api/actor/actors", HttpMethod.Get, true, unsuccessfulResponseAction);
        }

        #endregion
    }
}
