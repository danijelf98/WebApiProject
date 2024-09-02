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
    }
}
