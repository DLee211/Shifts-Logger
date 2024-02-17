using System.Text.RegularExpressions;

namespace Shifts_Logger;

public class Validation
{
    public static string? ValidateInteger(string? userInput)
    {
        bool validationLoop = true;
        while (validationLoop)
        {
            if (IsNumeric(userInput))
            {
                validationLoop = false;
                return userInput;
            }
            else
            {
                Console.WriteLine("The input is not a valid. Please input a integer.");
                userInput = Console.ReadLine();
            }
        }

        return null;
    }
    
    static bool IsNumeric(string input)
    {
        return int.TryParse(input, out _);
    }

    public static string? ValidateString(string? userInput)
    {
        bool validationLoop = true;

        while (validationLoop)
        {
            if (ContainsOnlyLetters(userInput))
            {
                validationLoop = false;
                return userInput;
            }
            else
            {
                Console.WriteLine("The input contains non-letter characters. Please input a valid string.");
                userInput = Console.ReadLine();
            }
        }

        return null;
    }
    
    static bool ContainsOnlyLetters(string input)
    {
        string pattern = "^[a-zA-Z]+$";
        
        return Regex.IsMatch(input, pattern);
    }
}