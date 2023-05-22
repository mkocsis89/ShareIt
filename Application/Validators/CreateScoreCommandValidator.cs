using Application.Dtos;
using Application.Scores;
using FluentValidation;

namespace Application.Commands
{
    public sealed class CreateScoreCommandValidator : AbstractValidator<Create.Command>
    {
        public CreateScoreCommandValidator()
        {
            RuleFor(command => command.Score).SetValidator(new CreateScoreDtoValidator());
        }
    }

    public sealed class CreateScoreDtoValidator : AbstractValidator<ScoreDto>
    {
        public CreateScoreDtoValidator()
        {
            RuleFor(score => score.Id).Empty();
            RuleFor(score => score.Type).NotEmpty();
        }
    }
}
