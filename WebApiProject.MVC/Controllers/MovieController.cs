using Microsoft.AspNetCore.Mvc;
using WebApiProject.Models.Binding;
using WebApiProject.Shared.Services.Interfaces;

namespace WebApiProject.MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IWebApiMovieServiceClient webApiMovieServiceClient;

        public MovieController(IWebApiMovieServiceClient webApiMovieServiceClient)
        {
            this.webApiMovieServiceClient = webApiMovieServiceClient;
        }

        #region Movie CRUD

        public IActionResult Movies()
        {
            var movies = webApiMovieServiceClient.GetMovies();
            return View(movies);
        }
        public IActionResult MovieDetails(int id)
        {
            var response = webApiMovieServiceClient.GetMovie(id);
            return View(response);
        }
        public  IActionResult AddMovie()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMovie(MovieBinding model)
        {
            webApiMovieServiceClient.AddMovie(model);
            return RedirectToAction("Movies");
        }

        public IActionResult UpdateMovie(int id)
        {
            var response = webApiMovieServiceClient.GetMovie<MovieUpdateBinding>(id);
            return View(response);
        }
        [HttpPost]
        public IActionResult UpdateMovie(MovieUpdateBinding model)
        {
            webApiMovieServiceClient.Update(model);
            return RedirectToAction("Movies");
        }
        public IActionResult DeleteMovie(int id)
        {
            webApiMovieServiceClient.DeleteMovie(id);
            return RedirectToAction("Movies");
        }

        #endregion

        #region Actor CRUD

        public IActionResult Actors()
        {
            var actors = webApiMovieServiceClient.GetActors();
            return View(actors);
        }
        public IActionResult ActorDetails(int id)
        {
            var response = webApiMovieServiceClient.GetActor(id);
            return View(response);
        }
        public IActionResult AddActor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddActor(ActorBinding model)
        {
            webApiMovieServiceClient.AddActor(model);
            return RedirectToAction("Actors");
        }

        public IActionResult UpdateActor(int id)
        {
            var response = webApiMovieServiceClient.GetActor<ActorUpdateBinding>(id);
            return View(response);
        }
        [HttpPost]
        public IActionResult UpdateActor(ActorUpdateBinding model)
        {
            webApiMovieServiceClient.Update(model);
            return RedirectToAction("Actors");
        }
        public IActionResult DeleteActor(int id)
        {
            webApiMovieServiceClient.DeleteActor(id);
            return RedirectToAction("Actors");
        }

        #endregion
    }
}
