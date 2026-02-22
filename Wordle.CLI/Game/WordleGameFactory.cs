namespace Wordle.CLI.Game;

public class WordleGameFactory
{
    private readonly WordleWordPool _wordleWordPool;

    public WordleGameFactory(WordleWordPool wordleWordPool)
    {
        _wordleWordPool = wordleWordPool;
    }

    public WordleGame Create()
    {
        return new WordleGame(_wordleWordPool.GetRandomWord().ToUpper());
    }
}