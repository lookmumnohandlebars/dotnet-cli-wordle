using FluentValidation;

namespace Wordle.CLI.Game;

public class WordleGuessValidator : AbstractValidator<GuessWord>
{
    public WordleGuessValidator(WordleWordPool wordleWordPool)
    {
        RuleFor(word => word.IsValidLength).Equal(true).WithMessage("Guess must be a five letter word!");
        RuleFor(word => word.Word).Must(wordleWordPool.Contains).WithMessage("Guess must be a word in the Dictionary!");
    }
}