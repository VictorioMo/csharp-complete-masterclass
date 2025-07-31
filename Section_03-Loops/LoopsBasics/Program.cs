// See https://aka.ms/new-console-template for more information

Console.WriteLine("Up counter");
for (int counter = 5; counter <= 10; counter++)
{
    Console.WriteLine($"Counter is {counter}");
}

//Console.WriteLine("Down counter");
//for (int counter = 10; counter > 3; counter--)
//{
//    Console.WriteLine($"Counter is {counter}");
//}

//Console.WriteLine("A timer?");
//for (int counter = 10; counter >= 0; counter--)
//{
//    Console.WriteLine($"{counter}");
//    Thread.Sleep(1000);
//}

int counter2 = 0;
while (counter2 < 10)
{
    // stuff
    counter2++;
}

string decisionGo;

Console.WriteLine("Wanna keep going? Type \"go\" to do so.");
decisionGo = Console.ReadLine();

while (decisionGo == "go")
{
    Console.WriteLine(".....");
    Thread.Sleep(1000);
    Console.WriteLine("Wanna keep going? Type \"go\" to do so.");
    decisionGo = Console.ReadLine();
}

Console.WriteLine("You stopped. Nice go.");

int number = 15;

do
{
    Console.WriteLine(number);
} while (number > 20);

string[] weekDays = {"Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun"};

//for (int i = 0; i < weekDays.Length; i++)
//{
//    Console.WriteLine(weekDays[i]);
//}

foreach (var weekDay in weekDays)
{
    Console.WriteLine(weekDay);
}
