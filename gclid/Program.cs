using System.CommandLine;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var valueOption = new Option<string>(
            aliases: ["--value", "-v"],
            description: "The value to generate GUIDs for")
        { IsRequired = false };

        var countOption = new Option<int>(
            aliases: ["--create", "-c"],
            description: "Number of GUIDs to generate",
            getDefaultValue: () => 1)
        { IsRequired = false };

        var outputFileOption = new Option<string>(
            aliases: ["--output", "-o"],
            description: "Output file path for saving GUIDs (supports .json or .txt)")
        { IsRequired = false };

        var formatOption = new Option<string>(
            aliases: ["--format", "-f"],
            description: "Output format (json or txt). If not specified, format is determined by file extension")
        { IsRequired = false };

        var rootCommand = new RootCommand("GUID CLI - Generate various GUID formats")
        {
            valueOption,
            countOption,
            outputFileOption,
            formatOption
        };

        rootCommand.SetHandler(CommandHandlers.HandleGuidCommand, 
            valueOption, 
            countOption, 
            outputFileOption, 
            formatOption);

        return await rootCommand.InvokeAsync(args);
    }
}