using Domain;
using FluentValidation;

namespace Application.Validators
{
    public sealed class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(post => post.Title).NotEmpty();
            RuleFor(post => post.Description).NotEmpty();
            RuleFor(post => post.SpecialParts).NotEmpty();
        }
    }
}
