using WebApiProject.Models.Binding;
using WebApiProject.Models.ViewModel;

namespace WebApiProject.Services.Interfaces
{
    public interface IMovieService
    {

        /// <summary>
        /// Add Actor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ActorViewModel> AddActor(ActorBinding model);
        Task<MovieViewModel> AddMovie(MovieBinding model);

        /// <summary>
        /// Delete Actor By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActorViewModel> DeleteActor(int id);
        Task<MovieViewModel> DeleteMovie(int id);

        /// <summary>
        /// Get Actor By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActorViewModel> GetActorById(int id);

        /// <summary>
        /// Get Actors
        /// </summary>
        /// <returns></returns>
        Task<List<ActorViewModel>> GetActors();

        /// <summary>
        /// Get All Movies
        /// </summary>
        /// <returns></returns>
        Task<List<MovieViewModel>> GetMovies();
        /// <summary>
        /// Get Movie By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MovieViewModel> GetMovieById(int id);
        Task<List<MovieViewModel>> GetMoviesWithPagination(int page, int pageSize);

        /// <summary>
        /// Update Actor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ActorViewModel> UpdateActor(ActorUpdateBinding model);
        Task<MovieViewModel> UpdateMovie(MovieUpdateBinding model);
        Task<bool> MoiveExist(int id);
    }
}