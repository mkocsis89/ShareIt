using Application.Posts;
using Application.Validators;
using FluentValidation;

namespace Application.Commands
{
    public sealed class EditPostCommandValidator : AbstractValidator<Edit.Command>
    {
        public EditPostCommandValidator()
        {
            RuleFor(command => command.Post).SetValidator(new EditPostValidator());
        }
    }
}
