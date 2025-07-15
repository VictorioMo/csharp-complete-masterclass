// See https://aka.ms/new-console-template for more information

string question1 = "What is the capital of Germany";
string answer1 = "Berlin";

string question2 = "What is 0 + 1";
string answer2 = "1";

string question3 = "What color do you get by mixing blue and yellow";
string answer3 = "Green";

int score = 0;

Console.WriteLine(question1);
if (Console.ReadLine().Trim().ToLower() == answer1.ToLower())
{
    Console.WriteLine("Correct!");
    score++;
}
else
{
    Console.WriteLine("Wrong, the correct answer is: " + answer1);
}

Console.WriteLine(question2);
if (Console.ReadLine().Trim().ToLower() == answer2.ToLower())
{
    Console.WriteLine("Correct!");
    score++;
}
else
{
    Console.WriteLine("Wrong, the correct answer is: " + answer2);
}

Console.WriteLine(question3);
if (Console.ReadLine().Trim().ToLower() == answer3.ToLower())
{
    Console.WriteLine("Correct!");
    score++;
}
else
{
    Console.WriteLine("Wrong, the correct answer is: " + answer3);
}

Console.WriteLine($"Quiz completed! Your final score is: {score}/3");
if (score == 3)
{
    Console.WriteLine("Excellent! You got all the answers right!");
}
else if (score > 0)
{
    Console.WriteLine("Good Job, but keep learning!");
}
else
{
    Console.WriteLine("Try again and see if you can get some answers right next time!");
}

Console.ReadKey();