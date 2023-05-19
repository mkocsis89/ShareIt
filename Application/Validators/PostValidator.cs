using Application.Posts.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public sealed class PostValidator : AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(post => post.Title).NotEmpty();
            RuleFor(post => post.Description).NotEmpty();
        }
    }
}
