# dotnet-cli-wordle

👋 This is a beginner project for creating a meaningful first CLI. The CLI is 

## Specs

### Requirements

#### CLI
1. Executing `wordle` in the terminal, or command line, should start a game of wordle
2. The program should exit successfully once the game is complete.

#### Game
1. The player should be able to guess the letters a five-letter word over 6 rounds
2. If all letters of the word are guessed correctly, The player wins and the game ends
3. If 6 rounds pass and the player has not guessed the word correctly, the player loses and the game ends.
4. If a player guesses any of the letters correctly in the same place as the word, they should receieve positive feedback for that letter
5. If a player guesses any of the letters correctly in a different place as the word, they should receieve an indication that the letter is in the word in a different place, up to the number of times that letter appears in the word
6. For all letters that do not match the player should see that the letter is not in the word.

## Approach
- **Spectre.Console**: For this we are using the .NET Foundation package Spectre.Console - commonly used for making nice CLI's
- **Single Program**: This is a simple one-command program which should run consistently each time

### What will you learn?
- Basic Libraries
- Logic
- Making something fun!

### Where next? 
- Expansions: Output the used letters of the alphabet
- Hangman: Try adapting this to make your own version of hangman!
