using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace ConsoleApp1;

public class JsonFileReader : BaseFileReader
{
    /// <summary>
    /// Gets the supported format identifier for this reader.
    /// </summary>
    public override string SupportedFormat => "JSON";

    /// <summary>
    /// Reads the entire text file, counts the lines, and displays the first 100 characters.
    /// </summary>
    /// <param name="filePath">The full path to the .txt file.</param>


    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening JSON document...");

        // 1. Read the JSON file
        string jsonText = File.ReadAllText(filePath);

        // 2. Parse the JSON
        JsonDocument doc = JsonDocument.Parse(jsonText);

        // 3. Get the root element
        var root = doc.RootElement;

        // 4. Count the properties in the root object
        int propertyCount = root.EnumerateObject().Count();

        Console.WriteLine($" -> Successfully parsed {propertyCount} JSON properties.");

        // 5. Display the first 100 characters
        string displayContent = jsonText.Length > 100
            ? jsonText.Substring(0, 100) + "..."
            : jsonText;

        Console.WriteLine("\n--- JSON Content ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("--------------------\n");
    }

}

