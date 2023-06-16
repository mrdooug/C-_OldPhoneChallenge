using System;
using System.Collections.Generic;
using System.Threading;

public class OldPhonePadConverter
{
    private static readonly Dictionary<char, string> keypadMapping = new Dictionary<char, string>
    {
        { '1', " " },
        { '2', "ABC" },
        { '3', "DEF" },
        { '4', "GHI" },
        { '5', "JKL" },
        { '6', "MNO" },
        { '7', "PQRS" },
        { '8', "TUV" },
        { '9', "WXYZ" },
        { '0', "0" }
    };

    public static string ConvertInput(string input)
    {
        string output = string.Empty;
        List<char> previousChars = new List<char>();
        int pauseDuration = 2000; // Pause duration in milliseconds

        foreach (char currentChar in input)
        {
            if (currentChar == '#' || currentChar == '*')
            {
                // Exit key encountered, end of input
                break;
            }
            else if (currentChar == ' ')
            {
                // Pause between characters on the same button
                if (previousChars.Count > 0)
                {
                    Thread.Sleep(pauseDuration);
                }
            }
            else if (keypadMapping.ContainsKey(currentChar))
            {
                // Valid keypad character found
                string keypadLetters = keypadMapping[currentChar];
                int letterIndex = previousChars.Count % keypadLetters.Length;
                char convertedChar = keypadLetters[letterIndex];
                output += convertedChar;
                previousChars.Add(currentChar);
            }
            else
            {
                // Invalid character, ignore
            }
        }

        return output;
    }

    public static void Main()
    {
        string input;
        string output;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Enter the input numbers:");
            input = Console.ReadLine();
            output = OldPhonePadConverter.ConvertInput(input + "#");
            Console.WriteLine("Output: " + output);

            Console.WriteLine("Press 1 to try again, press 2 to exit.");
            char option = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (option)
            {
                case '1':
                    Console.WriteLine();
                    break;
                case '2':
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Exiting...");
                    exit = true;
                    break;
            }
        }
    }
}