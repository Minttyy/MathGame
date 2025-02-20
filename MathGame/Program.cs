namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? name = GetName();

            Menu(name, DateTime.UtcNow);
        }

        // Try using enums because this is more unfamiliar for me to 
        // create one method that has all four operations
        // What about dictionary? As I can have key values pairs so I can 
        // store one as the text and another is the sign

        private static string? GetName()
        {
            Console.WriteLine("Please type your name");
            string? name = Console.ReadLine();

            return name != "" ? name : "Unknown";
        }

        static void Menu(string? name, DateTime date)
        {
            Console.WriteLine("-----------------------------------------");

            Console.WriteLine($"Hello {name}. Today's date is {date}. Let's play a math's game.");
            Console.WriteLine($@"What game would you like to play? Choose one
            A - Addition
            S - Subtraction
            M - Multiplication
            D - Division
            Q - Quit the program");

            Console.WriteLine("-----------------------------------------");

            var userOption = Console.ReadLine();
            int points = 0;

            switch (userOption?.ToUpper().Trim())
            {
                case "A":
                    points = AdditionGame(points);
                    break;

                case "S":
                    SubtractionGame(1, 2);
                    break;

                case "M":
                    MultiplicationGame(1, 2);
                    break;

                case "D":
                    DivisionGame(1, 2);
                    break;

                case "Q":
                    //Quit the program
                    Console.WriteLine("Thank you and goodbye!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("The input is incorrect. Try again!");
                    break;

            }
        }

        static int GenerateRandomNumber()
        {
            // maybe we can get the user to input the range they want to do this in 
            var random = new Random();
            return random.Next(0, 10);
        }

        static int AdditionGame(int points)
        {
            Console.WriteLine("Welcome to the Addition Game");
            int number1 = GenerateRandomNumber();
            int number2 = GenerateRandomNumber();

            bool isCorrectAnswer = false;

            int lives = 5;

            // instructions
            Console.WriteLine($@"You have five chances in this game. 
            When you answer correctly, you will win 1 point for the overall game. Goodluck!");

            // Logic
            do
            {
                Console.WriteLine($"What does {number1} + {number2} equals to? ");
                 var answer = Console.ReadLine();

                if (string.IsNullOrEmpty(answer))
                {
                    Console.WriteLine("Please enter your answer.");
                    continue;
                }
                else
                {
                    if (int.Parse(answer) == (number1 + number2))
                    {
                        isCorrectAnswer = true;
                    }
                    else
                    {
                        lives--;
                        Console.WriteLine($"This is incorrect! Please try again! You have {lives} lives left!\n");
                    }
                }
            } while (!isCorrectAnswer && lives != 0);

            // Final statement before returning points
            if (lives == 0)
            {
                Console.WriteLine("You have lost! Please start the game again!");
            }
            else
            {
                points += 1;
                Console.WriteLine($"\nYou won! You currently have {points}");
            }

            return points;
        }

        static void SubtractionGame(int number1, int number2)
        {
            Console.WriteLine("Welcome to the Subtraction Game");
            Console.WriteLine($"{number1} - {number2} = {number1 - number2}");
        }

        static void MultiplicationGame(int number1, int number2)
        {
            Console.WriteLine("Welcome to the Multiplication Game");
            Console.WriteLine($"{number1} * {number2} = {number1 * number2}");
        }

        static void DivisionGame(int number1, int number2)
        {
            Console.WriteLine("Welcome to the Division Game");
            double doubleNumber1 = Convert.ToDouble(number1);
            double doubleNumber2 = Convert.ToDouble(number2);

            Console.WriteLine($"{doubleNumber1} / {doubleNumber2} = {doubleNumber1 / doubleNumber2}");
        }
    }
}
