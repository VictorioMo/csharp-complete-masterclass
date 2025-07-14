// See https://aka.ms/new-console-template for more information

string    userInput;  /* Used to store the user input    */
double  firstNumber;  /* Used to store the first number  */
double secondNumber;  /* Used to store the second number */
double          sum;  /* Used to store the sum of the 2 numbers */


// Prints out whatever is inside ()
Console.WriteLine("Enter a number");

/* Takes user input and stores it inside a string variable
   and prints the result on the screen. */
userInput = Console.ReadLine();
Console.WriteLine("You entered " + userInput);

/* Convers the user input into a number */
firstNumber = double.Parse(userInput);

// Prints out whatever is inside ()
Console.WriteLine("Enter a second number");

/* Takes user input and stores it inside a string variable
   and prints the result on the screen. */
userInput = Console.ReadLine();
Console.WriteLine("You entered " + userInput);

/* Convers the user input into a number */
secondNumber = double.Parse(userInput);

/* Makes the sum of the 2 numbers and stores it in sum */
sum = Math.Round(firstNumber + secondNumber, 2);

// Writes the result of the addition on the screen

// String concatination
// Console.WriteLine("The result of " + firstNumber + " + " + secondNumber + " is " + sum);

// String interpolation
// Console.WriteLine($"The result of {firstNumber} + {secondNumber} is {sum}");

// String formatting
Console.WriteLine("The result of {0} + {1} is {2}", firstNumber, secondNumber, sum);

Console.ReadKey();