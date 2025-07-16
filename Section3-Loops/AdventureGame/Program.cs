
Console.WriteLine("Welcome to the Adventure Game!");

Console.WriteLine("Enter a name for your character: ");
string characterName = Console.ReadLine();

Console.WriteLine("Choose your character class (Warrior, Mage, Archer");
string characterClass = Console.ReadLine();

Console.WriteLine($"You, {characterName} the {characterClass}, find yourself at the edge of a dark forest.");
Console.WriteLine("Do you enter the forest or camp outside? (Enter/Camp)");

string choice1 = Console.ReadLine();

bool gameContinues = true;

if (choice1.ToLower() == "enter")
{
    Console.WriteLine("You bravely enter the forest");
}
else
{
    Console.WriteLine("You decide to camp out and wait for daylight.");
    gameContinues = false;
}

Random random = new Random();

while (gameContinues)
{
    Thread.Sleep(1000);

    Console.WriteLine("You come to a fork in the road. Go left or right?");
    string direction = Console.ReadLine();

    int rightPath = random.Next(0, 2);
    int choosenPath;

    if (direction.ToLower() == "left")
        choosenPath = 0;
    else if (direction.ToLower() == "right")
        choosenPath = 1;
    else
        choosenPath = 0;

    if (choosenPath == rightPath)
    {
        Console.WriteLine("You find a treasure chest!");
        gameContinues = false;
    }
    else
    {
        Console.WriteLine("You encounter a wild beast!");
        Console.WriteLine("Fight or flee? (fight/flee)");
        string fightChoice = Console.ReadLine();
        if (fightChoice.ToLower() == "fight")
        {
            int luck = random.Next(1, 11);
            if (luck > 5)
            {
                Console.WriteLine("You beat the wild beast!");
                if (luck > 8)
                {
                    Console.WriteLine("The wild beast dropped a treasure!");
                }
            }
            else
            {
                Console.WriteLine("The beast attacked you where you didn't expect it!");
                Console.WriteLine("It rammed it's tusks into your chest and you bleed out!");
                gameContinues = false;
            }
        }
    }
}

Console.WriteLine("Game Over!");
Console.WriteLine("Thank you for playing the game!");

Console.ReadKey();
