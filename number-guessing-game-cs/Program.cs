using System;

namespace number_guessing_game_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start the number guessing game
            StartNumberGuessingGame();
        }

        /// <summary>
        /// Runs the main logic for the Number Guessing Game.
        /// </summary>
        static void StartNumberGuessingGame()
        {
            try
            {
                // Create a random number generator instance
                Random random = new Random();

                // Constants for the range of the random number
                const int Minimum = 1;
                const int Maximum = 100;

                // Flag to determine if the game should repeat
                bool playAgain = true;

                while (playAgain)
                {
                    // Generate a random number between Minimum and Maximum (inclusive)
                    int targetNumber = random.Next(Minimum, Maximum + 1);
                    int guess = 0;
                    int attempts = 0;
                    bool guessedCorrectly = false;

                    Console.WriteLine($"\nI have selected a number between {Minimum} and {Maximum}.");
                    Console.WriteLine("Try to guess it!");

                    // Game loop - continues until the correct number is guessed
                    while (!guessedCorrectly)
                    {
                        Console.Write("Enter your guess: ");
                        string input = Console.ReadLine();

                        // Validate user input
                        if (!int.TryParse(input, out guess))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid whole number.");
                            continue;
                        }

                        attempts++; // Increment guess counter

                        // Provide feedback based on the guess
                        if (guess > targetNumber)
                        {
                            Console.WriteLine("Too high. Try again.");
                        }
                        else if (guess < targetNumber)
                        {
                            Console.WriteLine("Too low. Try again.");
                        }
                        else
                        {
                            // Correct guess
                            Console.WriteLine($"\nCorrect! You guessed the number {targetNumber} in {attempts} attempts.");
                            guessedCorrectly = true;
                        }
                    }

                    // Ask user if they want to play another round
                    Console.Write("\nDo you want to play again? (Y/N): ");
                    string response = Console.ReadLine().Trim().ToUpper();

                    // Set flag based on user response
                    playAgain = response == "Y";
                }
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions
                Console.WriteLine($"\nAn error occurred: {ex.Message}");
            }
            finally
            {
                // Ensure the application waits for user input before closing
                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
