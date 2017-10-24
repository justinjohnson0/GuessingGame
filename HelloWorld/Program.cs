using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Random numberGenerator = new Random();
            var guessAgain = true;
            int computersNumber = 0;
            int userGuess = 0;
            int isCorrect = 0;
            int guessCounter = 0;
            computersNumber = NewGame(computersNumber, numberGenerator);
            userGuess = GetUserInput();
            guessCounter++;

            while (guessAgain)
            {
                isCorrect = CheckAnswer(userGuess, computersNumber);
                Console.WriteLine(Feedback(isCorrect, guessCounter));
                guessAgain = GuessAgain(isCorrect);
                if (isCorrect == 1 && guessAgain)
                {
                    guessCounter = 0;
                    computersNumber = NewGame(computersNumber, numberGenerator);
                    userGuess = GetUserInput();
                    guessCounter++;
                }
                else if (guessAgain)
                {
                    userGuess = GetUserInput();
                    guessCounter++;
                }
             
            };
        }


       

        static int GetUserInput()
        {
            
            int userInput = Convert.ToInt32(Console.ReadLine());
            return userInput;
        }



        static int NewGame(int computersNumber, Random numberGenerator)
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("** Guess What I'm Thinking **");
            Console.WriteLine("**  pick a number between  **");
            Console.WriteLine("**        1  - 10          **");
            Console.WriteLine("*****************************");
            computersNumber = numberGenerator.Next(1, 11);            
            return (computersNumber);
            
        }



        static bool GuessAgain(int isCorrect)
        {
            if (isCorrect == 1)
            {
                Console.WriteLine("Want to play again?");
                string userChoice = Console.ReadLine();
                if (userChoice == "y")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("well fuck off then, i didn't like you anyway");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Care to guess again?");
                string userChoice = Console.ReadLine();
                if (userChoice == "y")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("well fuck off then, i didn't like you anyway");
                    return false;
                }
            }
            
        }



        static int CheckAnswer(int userGuess, int computersNumber)
        {
            var highLow = 0;

            if (userGuess == computersNumber)
            {
                highLow = 1;
            }
            else if (userGuess < computersNumber)
            {
                highLow = 0;
            }
            else
            {
                highLow = 2;
            }
            return highLow;
        }



        static string Feedback(int isCorrect, int guessCount)
        {
            var message = "";

            switch (isCorrect)
            {
                case 1:
                    {
                        if (guessCount == 1)
                        {
                            message = "First try!?!? Holy shit, you're amazing!!";
                            break;
                        }
                        else if (guessCount >= 5)
                        {
                            message = ("fuck yeah, you finally nailed it! Only took you " + guessCount + " tries."); 
                            break;
                        }

                        else
                        {
                            message = "Congrats you guessed it after just " + guessCount + " attempts!";
                            break;
                        }
                        
                    }
                case 2:
                    {
                        if (guessCount == 1)
                        {
                            message = "whoa, bring it back down";
                            break;
                        }
                        else
                        {
                            message = "nope, " + guessCount + " tries and still too high";
                            break;
                        }
                    }

                default:
                    {
                        if (guessCount == 1)
                        {
                            message = "sorry, too low";
                            break;
                        }
                        else
                        {
                            message = "nope, " + guessCount + " tries and still too low";
                            break;
                        }
                    }
            }
            return message;    

            
        } 
            
        

    }
}
