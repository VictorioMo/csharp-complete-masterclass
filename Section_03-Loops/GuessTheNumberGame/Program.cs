int secretNumber = 0;  // The secret number which the user has to guess
int userGuess    = 0;  // Number provided by user
int tries        = 0;  // The number of tries the user made to guess the secret number

Random random = new Random();

secretNumber = random.Next(1, 101);

Console.WriteLine("Guess the number between 1 and 100!");

// The game should run until the user guesses the secret number
while (userGuess != secretNumber)
{
    // Check if input is a number and ask the user to write a number in case of error
    if (!(int.TryParse(Console.ReadLine(), out userGuess)))
    {
        Console.WriteLine("Please type a whole number.");
    }
    else
    {
        /* If the user input is greater or lower than the secret number
        inform him so and increment the number of tries */
        tries++;
        if (userGuess > secretNumber)
        {
            Console.WriteLine("Too high!");
        }
        else if (userGuess < secretNumber)
        {
            Console.WriteLine("Too low!");
        }
        else
        {
            Console.WriteLine("You guessed! Congratulations!");
            Console.WriteLine($"Number of tries: {tries}");
        }
    }
}