public static class CommandHandlers
{
    public static void HandleGuidCommand(string? value, int count, string? outputFile, string? format)
    {
        try
        {
            if (count < 1)
            {
                Console.Error.WriteLine("Error: Count must be greater than 0.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(value))
            {
                if (!GuidOperations.IsValidGuid(value))
                {
                    Console.Error.WriteLine($"Error: '{value}' is not a valid GUID format.");
                    Console.Error.WriteLine("Please provide a valid GUID in one of these formats:");
                    Console.Error.WriteLine("- 00000000-0000-0000-0000-000000000000");
                    Console.Error.WriteLine("- 00000000000000000000000000000000");
                    return;
                }

                GuidOperations.ConvertGuid(value);
            }
            else
            {
                var guids = GuidOperations.GenerateGuids(count);

                if (!string.IsNullOrWhiteSpace(outputFile))
                {
                    if (string.IsNullOrWhiteSpace(format))
                    {
                        format = Path.GetExtension(outputFile).TrimStart('.').ToLower();
                        if (format != "json" && format != "txt")
                        {
                            format = "txt"; // Default to txt if extension is not recognized
                        }
                    }

                    GuidOperations.SaveToFile(guids, outputFile, format);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
} 