using System;

public class OldPhone
{
    public static string OldPhonePad(string input)
    {
        string[] buttonMapping = new string[]
        {
            " ",    // Button 0
            "",     // Button 1
            "ABC",  // Button 2
            "DEF",  // Button 3
            "GHI",  // Button 4
            "JKL",  // Button 5
            "MNO",  // Button 6
            "PQRS", // Button 7
            "TUV",  // Button 8
            "WXYZ"  // Button 9
        };

        string output = "";
        string[] inputs = input.Split(' ');

        foreach (string inputPart in inputs)
        {
            if (string.IsNullOrEmpty(inputPart))
            {
                output += " ";
            }
            else
            {
                int buttonNumber = int.Parse(inputPart[0].ToString());
                if (buttonNumber >= 0 && buttonNumber < buttonMapping.Length)
                {
                    int pressCount = inputPart.Length;
                    int index = (pressCount - 1) % buttonMapping[buttonNumber].Length;
                    output += buttonMapping[buttonNumber][index];
                }
            }
        }

        return output;
    }

    public static void Main()
    {
        bool tryAgain = true;
        while (tryAgain)
        {
            Console.Write("Enter input: ");
            string input = Console.ReadLine();

            string output = OldPhonePad(input);
            Console.WriteLine("Output: " + output);

            Console.Write("Do you want to try again? (Y/N): ");
            string choice = Console.ReadLine();
            tryAgain = (choice.ToUpper() == "Y");
        }
    }
}