using Application.Dtos;
using Application.Posts;
using FluentValidation;

namespace Application.Commands
{
    public sealed class EditPostCommandValidator : AbstractValidator<Edit.Command>
    {
        public EditPostCommandValidator()
        {
            RuleFor(command => command.Post).SetValidator(new EditPostDtoValidator());
        }
    }

    public sealed class EditPostDtoValidator : AbstractValidator<PostDto>
    {
        public EditPostDtoValidator()
        {
            RuleFor(post => post.Scores).Empty();
            RuleFor(post => post.Title).NotEmpty();
            RuleFor(post => post.Description).NotEmpty();
        }
    }
}
