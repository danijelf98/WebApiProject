using WebApiProject.Shared.Models.Base;

namespace WebApiProject.Models.Binding
{
    public class MovieBinding : MovieBase
    {
    }
    public class MovieUpdateBinding : MovieBase
    {
        public int Id { get; set; }
    }
}
