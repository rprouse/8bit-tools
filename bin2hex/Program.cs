using Spectre.Console;
using Spectre.Console.Cli;

var app = new CommandApp<Bin2HexCommand>();

app.Configure(config =>
{
    config.SetExceptionHandler(ex =>
    {
        AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
        return -99;
    });
}); 

return app.Run(args);
