using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Context;
using WebApiProject.Models.Binding;
using WebApiProject.Models.Dbo;
using WebApiProject.Models.ViewModel;
using WebApiProject.Services.Interfaces;

namespace WebApiProject.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMapper mapper;
        private ApplicationDbContext db;

        public MovieService(IMapper mapper, ApplicationDbContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        #region Movie CRUD

        /// <summary>
        /// Get All Movies
        /// </summary>
        /// <returns></returns>
        public async Task<List<MovieViewModel>> GetAllMovies()
        {
            var dbo = await db.Movies.ToListAsync();
            return dbo.Select(y => mapper.Map<MovieViewModel>(y)).ToList();
        }
        /// <summary>
        /// Get Movie By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MovieViewModel> GetMovieById(int id)
        {
            var dbo = await db.Movies
                .FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<MovieViewModel>(dbo);
        }
        /// <summary>
        /// Add Movie
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MovieViewModel> AddMovie(MovieBinding model)
        {
            var dbo = mapper.Map<Movie>(model);
            db.Movies.Add(dbo);
            await db.SaveChangesAsync();

            return mapper.Map<MovieViewModel>(dbo);
        }
        /// <summary>
        /// Update Movie
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<MovieViewModel> UpdateMovie(MovieUpdateBinding model)
        {
            var dbo = await db.Movies
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            mapper.Map(model, dbo);
            await db.SaveChangesAsync();
            return mapper.Map<MovieViewModel>(dbo);
        }
        /// <summary>
        /// Delete Movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MovieViewModel> DeleteMovie(int id)
        {
            var dbo = await db.Movies
                .FirstOrDefaultAsync(x => x.Id == id);

            db.Movies.Remove(dbo);
            await db.SaveChangesAsync();

            return mapper.Map<MovieViewModel>(dbo);
        }
        public async Task<List<MovieViewModel>> GetMoviesWithPagination(int page, int pageSize)
        {
            var movies = await db.Movies
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return mapper.Map<List<MovieViewModel>>(movies);
        }

        #endregion

        #region Actor CRUD

        /// <summary>
        /// Get Actors
        /// </summary>
        /// <returns></returns>
        public async Task<List<ActorViewModel>> GetActors()
        {
            var dbo = await db.Actors.ToListAsync();
            return dbo.Select(y => mapper.Map<ActorViewModel>(y)).ToList();
        }
        /// <summary>
        /// Get Actor By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActorViewModel> GetActorById(int id)
        {
            var dbo = await db.Actors
                .Include(x => x.Movie)
                .FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<ActorViewModel>(dbo);
        }
        /// <summary>
        /// Add Actor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ActorViewModel> AddActor(ActorBinding model)
        {
            var dbo = mapper.Map<Actor>(model);
            db.Actors.Add(dbo);
            await db.SaveChangesAsync();

            return mapper.Map<ActorViewModel>(dbo);
        }
        /// <summary>
        /// Update Actor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ActorViewModel> UpdateActor(ActorUpdateBinding model)
        {
            var dbo = await db.Actors.FirstOrDefaultAsync(y => y.Id == model.Id);
            mapper.Map(model, dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ActorViewModel>(dbo);
        }

        /// <summary>
        /// Delete Actor By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActorViewModel> DeleteActor(int id)
        {
            var dbo = await db.Actors
                .Include(x => x.Movie)
                .FirstOrDefaultAsync(x => x.Id == id);

            db.Actors.Remove(dbo);
            await db.SaveChangesAsync();

            return mapper.Map<ActorViewModel>(dbo);
        }

        public async Task<List<ActorViewModel>> GetActorsWithPagination(int page, int pageSize)
        {
            var Actors = await db.Actors
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return mapper.Map<List<ActorViewModel>>(Actors);
        }

        #endregion
    }
}
