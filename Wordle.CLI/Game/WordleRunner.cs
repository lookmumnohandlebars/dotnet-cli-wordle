using Spectre.Console;

namespace Wordle.CLI.Game;

public class WordleRunner
{
    private WordleGame game;
    private WordleGuessValidator validator;
    public WordleRunner(WordleGame game, WordleGuessValidator validator)
    {
        this.game = game;
        this.validator = validator;
    }
    
    public void RunGame(CancellationToken cancellationToken)
    {
        var inProgress = true;
        while (inProgress)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var guess = new GuessWord(AnsiConsole.Ask<string>($"❓ What's your Guess? ({game.CurrentGuessCount})"));
            AnsiConsole.WriteLine();
            var validationResult = validator.Validate(guess);
            if (!validationResult.IsValid)
            {
                AnsiConsole.Write(new Text("⛔️  " + validationResult.Errors.First().ErrorMessage));
                AnsiConsole.WriteLine();
                continue;
            }
            var guessResult = game.HandleGuess(guess);
            
            AnsiConsole.MarkupLine(guessResult.FormatToConsoleString());
            
            if (guessResult.IsSuccess)
            {
                AnsiConsole.Write(new Text("🎉 You won!"));
                inProgress = false;
            }
            
            if (guessResult.IsGameEnded)
            {
                AnsiConsole.Write(new Text($"😭 You lost! The word was '{game.PuzzleWord}'"));
                inProgress = false;
            }
        }
    }

    public static WordleRunner Create()
    {
        var wordPool = WordleWordPool.Load();
        var game = new WordleGameFactory(wordPool).Create();
        var validator = new WordleGuessValidator(wordPool);
        return new WordleRunner(game, validator);
    }
}