using FluentValidation;
using WebApiProject.Models.Binding;
using WebApiProject.Services.Interfaces;
using WebApiProject.Shared.Models;

namespace WebApiProject.FluentValidation
{
    public class MovieUpdateBindingValidation : AbstractValidator<MovieUpdateBinding>
    {
        public MovieUpdateBindingValidation(IMovieService movieService)
        {

            RuleFor(y => y.Id).MustAsync(async (id, cancellation) => await movieService.MoiveExist(id)).WithMessage(ErrorCodes.NotFound);
            RuleFor(y => y.Title).NotEmpty().WithMessage(ErrorCodes.MissingVlue);
            RuleFor(y => y.Genre).NotEmpty().WithMessage(ErrorCodes.MissingVlue);
            RuleFor(y => y.ReleaseYear).GreaterThan(1900).WithMessage(ErrorCodes.OutOfRange);
        }
    }
}
