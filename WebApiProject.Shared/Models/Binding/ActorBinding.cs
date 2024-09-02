using WebApiProject.Shared.Models.Base;

namespace WebApiProject.Models.Binding
{
    public class ActorBinding : ActorBase
    {
        public int MovieId { get; set; }
    }
    public class ActorUpdateBinding : ActorBase
    {
        public int Id { get; set; }
    }
}
