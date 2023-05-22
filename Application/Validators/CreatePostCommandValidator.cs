using Application.Dtos;
using Application.Posts;
using FluentValidation;

namespace Application.Commands
{
    public sealed class CreatePostCommandValidator : AbstractValidator<Create.Command>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(command => command.Post).SetValidator(new CreatePostDtoValidator());
        }
    }

    public sealed class CreatePostDtoValidator : AbstractValidator<PostDto>
    {
        public CreatePostDtoValidator()
        {
            RuleFor(post => post.Id).Empty();
            RuleFor(post => post.Scores).Empty();
            RuleFor(post => post.Title).NotEmpty();
            RuleFor(post => post.Description).NotEmpty();
        }
    }
}
