using Application.Validators;
using FluentValidation;

namespace Application.Commands
{
    public sealed class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(command => command.Post).SetValidator(new PostValidator());
        }
    }
}
