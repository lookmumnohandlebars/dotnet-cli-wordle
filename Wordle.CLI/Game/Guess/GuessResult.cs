using System.Text;

namespace Wordle.CLI.Game;

public class WordleGuessResult
{
    public readonly (char, CharacterGuessResult)[] CharacterResults;
    public readonly bool IsGameEnded;

    public WordleGuessResult((char, CharacterGuessResult)[] characterResults, bool isGameEnded)
    {
        CharacterResults = characterResults;
        IsGameEnded = isGameEnded;
    }
    
    public bool IsSuccess => 
        CharacterResults.All(charResult => charResult.Item2 == CharacterGuessResult.Match);

    public string FormatToConsoleString()
    {
        var outputString = new StringBuilder();
        foreach (var characterResult in CharacterResults)
        {
            if (characterResult.Item2 == CharacterGuessResult.Match) outputString.Append("[springgreen1 underline]");
            if (characterResult.Item2 == CharacterGuessResult.MatchingElsewhere) outputString.Append("[orange1 underline]");
            if (characterResult.Item2 == CharacterGuessResult.NoMatch) outputString.Append("[grey underline]");
            outputString.Append($"{characterResult.Item1}[/] ");
        }
        return outputString.ToString();
    }
}

public enum CharacterGuessResult
{
    Match,
    MatchingElsewhere,
    NoMatch,
}