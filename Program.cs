using System;
using System.Collections.Generic;
using System.IO;

public class WordsDTO
{
    public string[] Words { get; set; }
    public bool IsSuccess { get; set; }
    public string StatusMessage { get; set; }
}

public class Program
{
    public static List<int> ParseNumbers(string input)
    {
        List<int> numbers = new List<int>();

        string[] numberStrings = input.Split(' ');

        foreach (string numberString in numberStrings)
        {
            try
            {
                int number = int.Parse(numberString);
                numbers.Add(number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Entry discarded");
            }
        }

        numbers.Sort((a, b) => b.CompareTo(a));
        return numbers;
    }

    public static WordsDTO ReadFile(string filePath)
    {
        WordsDTO dto = new WordsDTO();

        try
        {
            string fileContent = File.ReadAllText(filePath);
            string[] words = fileContent.Split(',');

            dto.Words = words;
            dto.IsSuccess = true;
            dto.StatusMessage = "Success";
        }
        catch (FileNotFoundException)
        {
            dto.IsSuccess = false;
            dto.StatusMessage = "File not found";
        }
        return dto;
    }

    public static void Main()
    {
        // First Step: ParseNumbers
        string inputString = "10 20 30 abc 40";
        List<int> parsedNumbers = ParseNumbers(inputString);

        Console.WriteLine("Parsed Numbers (Descending Order):");
        foreach (int number in parsedNumbers)
        {
            Console.WriteLine(number);
        }

        // Second Step: Create WordsDTO
        WordsDTO dto = new WordsDTO();

        // Third Step: ReadFile
        string filePath = "example.txt";
        dto = ReadFile(filePath);

        if (dto.IsSuccess)
        {
            Console.WriteLine("\nWords from File:");
            foreach (string word in dto.Words)
            {
                Console.WriteLine(word);
            }
        }
        else
        {
            Console.WriteLine($"\nError: {dto.StatusMessage}");
        }
    }
}
