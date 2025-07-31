using System;

double num1; // Number1 used for calculator
double num2; // Number2 used for calculator  
bool        errorNotFound1 = true; // Store the result if conversion was successful for first number from user input
bool        errorNotFound2 = true; // Store the result if conversion was successful for second number from user input
bool errorNotFoundOperator = true; // Store the result if conversion was successful for operator character from user input

char @operator = '+'; // Used to store the requested operation

double result; // The result of the operation

// Read the first number from user input
Console.WriteLine("Enter the first number:");
errorNotFound1 = double.TryParse(Console.ReadLine().Trim(), out num1);

// Read the second number from user input
Console.WriteLine("Enter the second number:");
errorNotFound2 = double.TryParse(Console.ReadLine().Trim(), out num2);

// Check the converion results
if (!(errorNotFound1 && errorNotFound2))
{
    // If errors were found, halt the execution
    Console.WriteLine("One or both of the provided inputs is invalid.");
    return;
}
else
{
    // If errors were found not found, read the operator from user input
    Console.WriteLine("Choose an operation: +, -, *, /");
    string operationInput = Console.ReadLine().Trim();
    errorNotFoundOperator = char.TryParse(operationInput, out @operator);
}

// If an invalid operator was provided, halt the execution
if (!errorNotFoundOperator)
{
    Console.WriteLine("Invalid operation. Please choose +, -, *, or /.");
    return;
}
else
{
    // Choose the operation
    switch (@operator)
    {
        case '+':
            {
                result = num1 + num2;
                break;
            }
        case '-':
            {
                result = num1 - num2;
                break;
            }
        case '*':
            {
                result = num1 * num2;
                break;
            }
        case '/':
            {
                // Check if division by 0
                if (num2 == 0)
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                    return;
                }
                else
                {
                    result = num1 / num2;
                }
                break;
            }
        default:
            {
                Console.WriteLine("Invalid operation. Please choose +, -, *, or /.");
                return;
            }
    }
}
//Console.WriteLine($"Result: {result}");
Console.WriteLine($"The result of {num1} {@operator} {num2} is {result}");

