namespace Wordle.CLI.Game;

public class GuessWord
{
    private const char EmptyChar = '\0';
    public GuessWord(string word)
    {
        Word = word.ToUpper();
    }

    public string Word { get; }
    public bool IsValidLength => Word.Length == 5;

    public (char, CharacterGuessResult)[] GetMatchesFor(string puzzleWord)
    {
        var charactersToMatch = puzzleWord.ToCharArray(); // Dynamically copy to keep track of matched values
        var results = new (char, CharacterGuessResult)[5]; // keep track of results and yes/almost/no
        ExtractSuccessfulMatches(charactersToMatch, results); // Successful matches first so no false maybe's
        ExtractPotentialMatches(charactersToMatch, results); // Then maybe matches 
        FillNonMatches(charactersToMatch, results);
        return results;
    }

    private void ExtractPotentialMatches(char[] charactersToMatch,
        (char, CharacterGuessResult)[] results)
    {
        for (var i = 0; i < charactersToMatch.Length; i++)
        {
            if (charactersToMatch[i] == EmptyChar) continue;
            
            var guessCharacter = char.ToUpper(Word[i]);
            if (charactersToMatch.Contains(char.ToUpper(guessCharacter)))
            {
                var indexInPuzzleWord = charactersToMatch.IndexOf(char.ToUpper(Word[i]));
                results[i] = (guessCharacter, CharacterGuessResult.MatchingElsewhere);
                charactersToMatch[indexInPuzzleWord] = EmptyChar; // Wipe after the match so it doesn't keep showing
            }
        }
    }
    
    private void FillNonMatches(char[] charactersToMatch,
        (char, CharacterGuessResult)[] results)
    {
        for (var i = 0; i < charactersToMatch.Length; i++)
        {
            if (results[i].Item1 == EmptyChar)
            {
                results[i] = (char.ToUpper(Word[i]), CharacterGuessResult.NoMatch);
            }
        }
    }

    // Get successful matches for first
    private void ExtractSuccessfulMatches(
        char[] charactersToMatch,
        (char, CharacterGuessResult)[] results
    )
    {
        for (var i = 0; i < charactersToMatch.Length; i++)
        {
            var targetCharacter = char.ToUpper(charactersToMatch[i]);
            var guessCharacter = char.ToUpper(Word[i]);
            if (guessCharacter != targetCharacter) continue;
            results[i] = (guessCharacter, CharacterGuessResult.Match);
            charactersToMatch[i] = EmptyChar; //This has been matched, exclude it
        }
    }
}