namespace QuizApp_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = new Question[]
            {
                new Question(
                    "What is the capital of Moldova?", // Question Text
                    new string[] {"Paris", "Berlin", "London", "Chisinau" }, // Answers array
                    3 // Index of correct answer
                ),
                new Question(
                    "What is the result of 2 + 7?", // Question Text
                    new string[] {"27", "9", "5", "8" }, // Answers array
                    1 // Index of correct answer
                ),
                new Question(
                    "Who wrote 'Hamblet'?", // Question Text
                    new string[] {"Goethe", "Austen", "Shakespeare", "Dickens" }, // Answers array
                    2 // Index of correct answer
                )
            };

            Quiz myQuiz = new Quiz(questions);
            myQuiz.StartQuiz();
        }
    }
}
