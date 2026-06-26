using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace ConsoleApp1;

public class XmlFileReader : BaseFileReader
{
    /// <summary>
    /// Gets the supported format identifier for this reader.
    /// </summary>
    public override string SupportedFormat => "XML";


    /// <summary>
    /// Reads the entire text file, counts the lines, and displays the first 100 characters.
    /// </summary>
    /// <param name="filePath">The full path to the .txt file.</param>
    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening plain text stream...");

        XDocument doc = XDocument.Load(filePath);
        int elementCount = doc.Descendants().Count();

        Console.WriteLine($" -> Successfully parsed {elementCount} XML elements.");

        string xmlText = doc.ToString();

        string displayContent = xmlText.Length > 100
            ? xmlText.Substring(0, 100) + "..."
            : xmlText;

        Console.WriteLine("\n--- XML Content ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}
