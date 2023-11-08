using bin2hex;
using Spectre.Console;
using Spectre.Console.Cli;

var app = new CommandApp<Bin2HexCommand>();

app.Configure(config =>
{
    config
    .SetApplicationName("bin2hex")
    .SetExceptionHandler(ex =>
    {
        AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
        return -99;
    });
}); 

return app.Run(args);
