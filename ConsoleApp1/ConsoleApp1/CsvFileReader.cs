using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace ConsoleApp1;

public class CsvFileReader : BaseFileReader
{
    /// <summary>
    /// Gets the supported format identifier for this reader.
    /// </summary>
    public override string SupportedFormat => "CSV";

    /// <summary>
    /// Reads the entire text file, counts the lines, and displays the first 100 characters.
    /// </summary>
    /// <param name="filePath">The full path to the .txt file.</param>
    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening CSV file...");

        // Read all lines from the CSV file
        string[] lines = File.ReadAllLines(filePath);

        // Count the number of rows
        int rowCount = lines.Length;
        Console.WriteLine($" -> Successfully parsed {rowCount} rows.");

        // Check if the file is empty
        if (lines.Length == 0)
        {
            Console.WriteLine(" -> CSV file is empty.");
            return;
        }

        // Split the first row into columns
        string[] columns = lines[0].Split(',');

        // Count the columns
        int columnCount = columns.Length;
        Console.WriteLine($" -> Found {columnCount} columns.");

        // Convert all lines into one string
        string csvText = string.Join(Environment.NewLine, lines);

        // Display only the first 100 characters
        string displayContent = csvText.Length > 100
            ? csvText.Substring(0, 100) + "..."
            : csvText;

        Console.WriteLine("\n--- CSV Content ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("-------------------\n");
    }
}
