using System.Text.Json;

public class GuidOperations
{
    public static void ConvertGuid(string value)
    {
        var guid = new Guid(value);
        Console.WriteLine($"Standard Format: {guid}");
        Console.WriteLine($"N Format: {guid.ToString("N").ToUpper()}");
    }

    public static List<GuidInfo> GenerateGuids(int count)
    {
        var guids = new List<GuidInfo>();
        for (int i = 0; i < count; i++)
        {
            var guid = Guid.NewGuid();
            var guidInfo = new GuidInfo
            {
                Number = i + 1,
                StandardFormat = guid.ToString(),
                NFormat = guid.ToString("N").ToUpper()
            };
            guids.Add(guidInfo);
            
            Console.WriteLine($"GUID {i + 1}:");
            Console.WriteLine($"  Standard Format: {guid}");
            Console.WriteLine($"  N Format: {guidInfo.NFormat}");
            if (i < count - 1) Console.WriteLine();
        }
        return guids;
    }

    public static bool IsValidGuid(string value)
    {
        return Guid.TryParse(value, out _);
    }

    public static void SaveToFile(List<GuidInfo> guids, string filePath, string format)
    {
        var directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }

        if (format.ToLower() == "json")
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(guids, options);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"GUIDs saved to JSON file: {filePath}");
        }
        else if (format.ToLower() == "txt")
        {
            var lines = guids.Select(g => 
                $"GUID {g.Number}:\n" +
                $"  Standard Format: {g.StandardFormat}\n" +
                $"  N Format: {g.NFormat}"
            );
            File.WriteAllLines(filePath, lines);
            Console.WriteLine($"GUIDs saved to TXT file: {filePath}");
        }
        else
        {
            throw new ArgumentException("Unsupported format. Use 'json' or 'txt'.");
        }
    }
}

public class GuidInfo
{
    public int Number { get; set; }
    public string StandardFormat { get; set; } = string.Empty;
    public string NFormat { get; set; } = string.Empty;
} 