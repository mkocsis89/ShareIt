using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public sealed class EditPostValidator : AbstractValidator<EditPostDto>
    {
        public EditPostValidator()
        {
            RuleFor(post => post.Title).NotEmpty();
            RuleFor(post => post.Description).NotEmpty();
        }
    }
}
