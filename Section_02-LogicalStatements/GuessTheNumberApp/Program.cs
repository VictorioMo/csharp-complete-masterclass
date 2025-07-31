// See https://aka.ms/new-console-template for more information

// Creating an instance of Random Class
Random random = new Random();

// Generating a random number between 1 and 10 both limits included
int rnd = random.Next(1, 11);

Console.WriteLine("Guess the number! [1 - 10]");

string input = Console.ReadLine();

int guessNumber = 0;

bool isNumber = int.TryParse(input, out guessNumber);

if (isNumber)
{
    if (guessNumber == rnd)
    {
        Console.WriteLine($"You guessed! It is {guessNumber}!");
    }
    else
    {
        Console.WriteLine($"You guessed wrong! The number was {rnd}!");
    }
}
else
{
    Console.WriteLine("You should type numbers, whole numbers :)");
}

Console.ReadKey();

