using Application.Validators;
using FluentValidation;

namespace Application.Commands
{
    public sealed class EditPostCommandValidator : AbstractValidator<EditPostCommand>
    {
        public EditPostCommandValidator()
        {
            RuleFor(command => command.Post).SetValidator(new PostValidator());
        }
    }
}
