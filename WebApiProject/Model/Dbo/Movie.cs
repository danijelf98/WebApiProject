using WebApiProject.Shared.Models.Base;

namespace WebApiProject.Models.Dbo
{
    public class Movie : MovieBase
    {
        public int Id { get; set; }
        public ICollection<Actor>? Actors { get; set; }
    }
}
