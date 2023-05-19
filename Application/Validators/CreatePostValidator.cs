using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public sealed class CreatePostValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostValidator()
        {
            RuleFor(post => post.Title).NotEmpty();
            RuleFor(post => post.Description).NotEmpty();
        }
    }
}
