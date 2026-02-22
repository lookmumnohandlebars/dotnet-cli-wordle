using Spectre.Console.Cli;
using Wordle.CLI;

var builder = new CommandApp<RootCommand>();
await builder.RunAsync(args);