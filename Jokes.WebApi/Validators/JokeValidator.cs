using FluentValidation;
using Jokes.WebApi.Helpers;
using Jokes.WebApi.Models;

namespace Jokes.WebApi.Validators
{
    /// <summary>
    /// Joke valdator
    /// </summary>
    public class JokeValidator : AbstractValidator<Joke>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public JokeValidator()
        {
            RuleFor(x => x.Question)
                .NotEmpty()
                .WithMessage(ErrorMessagesHelper.Question)
                .MaximumLength(500);
        }
    }
}
