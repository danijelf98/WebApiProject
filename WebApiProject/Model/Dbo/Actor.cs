using WebApiProject.Shared.Models.Base;

namespace WebApiProject.Models.Dbo
{
    public class Actor : ActorBase
    {
        public int Id { get; set; }
        public Movie? Movie { get; set; }
        public int? MovieId { get; set; }
    }
}
