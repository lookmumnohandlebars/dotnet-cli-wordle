using Spectre.Console;
using Spectre.Console.Cli;
using Wordle.CLI.Game;

namespace Wordle.CLI;

public class RootCommand : Command
{
    public override int Execute(CommandContext _, CancellationToken cancellationToken)
    {
        AnsiConsole.Write(new FigletText("Wordle").Color(Color.Aquamarine1).Centered());
        
        AnsiConsole.Write(new Text("Guess a five letter word in six guesses or less to win!").Centered());
        AnsiConsole.WriteLine();

        var gameHandler = WordleRunner.Create();
        gameHandler.RunGame(cancellationToken);
        
        Thread.Sleep(TimeSpan.FromSeconds(1));
        AnsiConsole.Write(new Text("👋 Thanks For Playing"));
        return 0;
    }
}
