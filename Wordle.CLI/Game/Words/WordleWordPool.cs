namespace Wordle.CLI.Game;

public class WordleWordPool
{
    public WordleWordPool(string[] words)
    {
        Words = words;
    }

    public string[] Words { get; }

    public static WordleWordPool Load()
    {
        var fileName = Path.Combine(".", "Assets", "wordle-words.txt");
        var wordsInFile = File.ReadAllText(fileName)
            .Split('\n')
            .Select(word => word.Trim().ToUpper())
            .ToArray();
        return new WordleWordPool(wordsInFile);
    }
    
    public bool Contains(string word) => Words.Contains(word);

    public string GetRandomWord()
    {
        var word = Words[new Random().Next(0, Words.Length)];
        return word;
    }
}