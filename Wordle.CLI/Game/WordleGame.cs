namespace Wordle.CLI.Game;

public class WordleGame
{
    public string PuzzleWord { get; }
    private const int MaxGuesses = 6;
    public int CurrentGuessCount = 1;

    public WordleGame(string puzzleWord)
    {
        PuzzleWord = puzzleWord;
    }
    
    public WordleGuessResult HandleGuess(GuessWord guessWord)
    {
        var results = guessWord.GetMatchesFor(PuzzleWord);
        var isGameEnded = CurrentGuessCount >= MaxGuesses;
        CurrentGuessCount++;
        return new WordleGuessResult(results, isGameEnded);
    }
}