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
    }
}
