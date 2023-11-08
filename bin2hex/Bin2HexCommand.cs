using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

namespace bin2hex;

public sealed class Bin2HexCommand : Command<Bin2HexCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("The input binary file to read.")]
        [CommandArgument(0, "<INPUT>")]
        public string Input { get; set; } = string.Empty;

        [Description("The hexadecimal address where the HEX file will be loaded into memory. Defaults to 0x0000.")]
        [CommandOption("-a|--address [ADDRESS]")]
        [TypeConverter(typeof(HexStringToUShortTypeConverter))]
        public FlagValue<ushort> Address { get; set; } = new FlagValue<ushort>();

        [Description("The output Intel HEX file to write. If not specified, it will use the input file name with the HEX extension.")]
        [CommandOption("-o|--output [OUTPUT]")]
        public FlagValue<string> Output { get; set; } = new FlagValue<string>();
    }

    public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
    {
        string input = settings.Input;
        string output = settings.Output.IsSet ? settings.Output.Value : HexFileFromInput(settings.Input);
        ushort address = settings.Address.IsSet ? settings.Address.Value : (ushort)0x0000;
        
        AnsiConsole.MarkupLine($"Converting [cyan]{input}[/] => [cyan]{output}[/] starting at address [cyan]0x{address:X4}[/]");

        var bytes = File.ReadAllBytes(input);
        var hex = IntelHexFile.ConvertBinaryToHex(bytes, address);
        File.WriteAllText(output, hex);

        return 0;
    }

    public static string HexFileFromInput(string input) =>
        Path.Combine(Path.GetDirectoryName(input) ?? "", Path.GetFileNameWithoutExtension(input) + ".hex");
}
