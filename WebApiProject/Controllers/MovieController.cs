using Microsoft.AspNetCore.Mvc;
using WebApiProject.Context;
using WebApiProject.Models.Binding;
using WebApiProject.Models.ViewModel;
using WebApiProject.Services.Interfaces;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        /// <summary>
        /// Get Movie By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MovieViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<MovieViewModel>> GetMovieById(int id)
        {
            var movies = await movieService.GetMovieById(id);
            return Ok(movies);
        }
        /// <summary>
        /// Get All Movies
        /// </summary>
        /// <returns></returns>
        [HttpGet("movies")]
        [ProducesResponseType(typeof(List<MovieViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MovieViewModel>>> GetAllMovies()
        {
            var movie = await movieService.GetAllMovies();
            return Ok(movie);
        }
        /// <summary>
        /// Add Movie
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(MovieViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<MovieViewModel>> AddMovie([FromBody]MovieBinding model)
        {
            var movie = await movieService.AddMovie(model);
            return Ok(movie);
        }
        /// <summary>
        /// Update Movie
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MovieViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<MovieViewModel>> UpdateMovie([FromBody]MovieUpdateBinding model)
        {
            var movie = await movieService.UpdateMovie(model);
            return Ok(movie);
        }
        /// <summary>
        /// Delete Movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MovieViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<MovieViewModel>> DeleteMovie(int id)
        {
            var movie = await movieService.DeleteMovie(id);
            return Ok(new { Message = $"Movie with Id {id} is successfully deleted!" });
        }


        /// <summary>
        /// Get Actor By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("actor/{id}")]
        [ProducesResponseType(typeof(ActorViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<ActorViewModel>> GetActorById(int id)
        {
            var Actors = await movieService.GetActorById(id);
            return Ok(Actors);
        }
        /// <summary>
        /// Get Actors
        /// </summary>
        /// <returns></returns>
        [HttpGet("actors")]
        [ProducesResponseType(typeof(List<ActorViewModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ActorViewModel>>> GetActors()
        {
            var Actor = await movieService.GetActors();
            return Ok(Actor);
        }
        /// <summary>
        /// Add Actor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("actor")]
        [ProducesResponseType(typeof(ActorViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<ActorViewModel>> AddActor([FromBody] ActorBinding model)
        {
            var Actor = await movieService.AddActor(model);
            return Ok(Actor);
        }
        /// <summary>
        /// Update Actor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("actor")]
        [ProducesResponseType(typeof(ActorViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<ActorViewModel>> UpdateActor([FromBody] ActorUpdateBinding model)
        {
            var Actor = await movieService.UpdateActor(model);
            return Ok(Actor);
        }
        /// <summary>
        /// Delete Actor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("actor/{id}")]
        [ProducesResponseType(typeof(ActorViewModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<ActorViewModel>> DeleteActor(int id)
        {
            var Actor = await movieService.DeleteActor(id);
            return Ok(new { Message = $"Actor with Id {id} is successfully deleted!" });
        }
    }
}
