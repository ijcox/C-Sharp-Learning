using System;

class Frequency
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a valid sentence:");
        string input = Console.ReadLine(); //takes user input

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("No input provided.");
            return;
        }

        string[] words = input.Split(' '); //splits string into words at spaces

        char[] charsToTrim = { '*', '\'', '\t', '\n', ',', '.', '!', '?' };

        Dictionary<string, int> dict = new Dictionary<string, int>(); //define dictionary with a string as the key to ensure each word is only added once, int as frequency

        foreach (string word in words)
        {
            string cleanedWord = (word.ToLower()).Trim(charsToTrim); //normalize words to all be lowercase and without punctuation.

            if (dict.ContainsKey(cleanedWord))
            {
                dict[cleanedWord]++; //if word already exists, increment the value by 1.
            }
            else
            {
                dict.Add(cleanedWord, 1); //if word doesn't already exist, add word to dictionary and set its frequency to 1
            }
        }

        // Get top 3 most frequent words
        var topWords = dict
            .OrderByDescending(pair => pair.Value)
            .Take(3)
            .ToList();

        // Print results
        Console.WriteLine("\nTop 3 Most Frequent Words:");
        foreach (var pair in topWords)
        {
            Console.WriteLine($"Word: {pair.Key}, Frequency: {pair.Value}");
        }
  
    }
}