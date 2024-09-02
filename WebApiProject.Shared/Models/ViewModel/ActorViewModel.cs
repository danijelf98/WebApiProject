using WebApiProject.Shared.Models.Base;

namespace WebApiProject.Models.ViewModel
{
    public class ActorViewModel : ActorBase
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }
    }
}
