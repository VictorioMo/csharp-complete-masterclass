// See https://aka.ms/new-console-template for more information

// AND, OR, and NOT operators
bool isRainy = true;
bool hasUmbrella = true;

if (!isRainy || hasUmbrella)
{
    Console.WriteLine("I'm not getting wet!");
}

if (isRainy && !hasUmbrella)
{
    Console.WriteLine("Ayyy");
}

// relational operators < <= => >
int num1 = 5;
int num2 = 6;

bool leftIsGreater = num1 < num2;
bool isEqual = num1 == num2;
bool isNotEqual = num1 != num2;

Console.WriteLine("Enter 2 whole numbers 1 by 1");
if (int.Parse(Console.ReadLine()) == int.Parse(Console.ReadLine()))
{
    Console.WriteLine("Provided numbers are equal!");
}
else
{
    Console.WriteLine("Provided numbers are not equal!");
}

Console.WriteLine("Enter your age");
int age = int.Parse(Console.ReadLine());

if (age >= 18)
{
    Console.WriteLine("Party time");
}
else if (age >= 14)
{
    Console.WriteLine("Restricted party time");
}
else
{
    Console.WriteLine("Not ready yet for the good stuff");
}

Console.WriteLine("Enter the number of the current month");
string monthName;

switch(short.Parse(Console.ReadLine()))
{
    case 1:
        {
            monthName = "January";
            break;
        }
    case 2:
        {
            monthName = "February";
            break;
        }
    case 3:
        {
            monthName = "March";
            break;
        }
    default:
        {
            monthName = "unknown";
            break;
        }
}

Console.WriteLine($"The month name is {monthName}");

