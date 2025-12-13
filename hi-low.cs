using System;

class GetUserInput
{
    public static int GetInt()
    {
        while (true)
        {
            Console.Write("Input an integer: ");
            string? userInput = Console.ReadLine();
            // int.TryParse returns a bool if successful
            if (int.TryParse(userInput, out int inputInt))
            {
                return inputInt;
            }
            else
            {
                Console.WriteLine($"{userInput} is not an integer.");
            }
        }
    }
}

class HiLow
{
    static void PlayGame(int chances, int ranNum)
    {
        for (int i = 0; i < chances; i++)
        {
            Console.Write($"Guess {i+1}. ");
            int userGuess = GetUserInput.GetInt();
            if (userGuess > ranNum)
            {
                Console.WriteLine("Too high.");
            }
            else if (userGuess < ranNum)
            {
                Console.WriteLine("Too low.");
            }
            else
            {
                Console.WriteLine("You win!");
                return;
            }
        }
        Console.WriteLine($"Sorry, the correct answer was {ranNum}");
    }

    static bool RepeatPlay()
    {
        while (true)
        {
            Console.Write("Would you like to play again (y/n)? ");
            string userInput = Console.ReadLine() ?? string.Empty;
            if (userInput.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else if (userInput.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            else
            {
                Console.WriteLine("Please input y for yes or n for no.");
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to our Hi-Low game!");
        const int chances = 7;
        const int min = 1;
        const int max = 100;
        // Random objects should only be seeded once
        Random rand = new Random();
        
        while (true)
        {
            Console.WriteLine($"You have {chances} tries to guess " + 
                              $"the correct number between {min} and {max}.");

            int ranNum = rand.Next(min, max+1);
            PlayGame(chances, ranNum);

            if (!RepeatPlay())
            {
                Console.WriteLine("Goodbye!");
                break;
            }
        }
    }
}