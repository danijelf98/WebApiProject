using WebApiProject.Shared.Models.Base;

namespace WebApiProject.Models.ViewModel
{
    public class MovieViewModel : MovieBase
    {
        public int Id { get; set; }
        public List<ActorViewModel>? Actors { get; set; }
    }
}
