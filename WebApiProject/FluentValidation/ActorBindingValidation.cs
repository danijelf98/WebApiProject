using FluentValidation;
using WebApiProject.Models.Binding;
using WebApiProject.Services.Interfaces;
using WebApiProject.Shared.Models;

namespace WebApiProject.FluentValidation
{
    public class ActorBindingValidation : AbstractValidator<ActorBinding>
    {
        public ActorBindingValidation(IMovieService movieService)
        {
            RuleFor(y => y.MovieId).MustAsync(async (id, cancellation) => await movieService.MoiveExist(id)).WithMessage(ErrorCodes.NotFound);
            RuleFor(y => y.FirstName).NotEmpty().WithMessage(ErrorCodes.MissingVlue);
            RuleFor(y => y.LastName).NotEmpty().WithMessage(ErrorCodes.MissingVlue);
        }
    }
}
