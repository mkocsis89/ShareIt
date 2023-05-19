using Application.Posts;
using Application.Validators;
using FluentValidation;

namespace Application.Commands
{
    public sealed class CreatePostCommandValidator : AbstractValidator<Create.Command>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(command => command.Post).SetValidator(new CreatePostValidator());
        }
    }
}
