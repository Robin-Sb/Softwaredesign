using System;
using System.Collections.Generic; 


namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            Quiz quiz = new Quiz();

            QuizElement smartestProgrammer = new QuizElement("Who is the worlds smartest programmer?", new List<PossibleAnswer> 
            {
                new PossibleAnswer("Terry Davis", true), 
                new PossibleAnswer("Linus Torwalds", false), 
                new PossibleAnswer("James Gosling", false), 
                new PossibleAnswer("Bjarne Stroustrup", false), 
            });


            QuizElement whoWouldWin = new QuizElement("1 trillion lions against the sun, who would win?", new List<PossibleAnswer> 
            {
                new PossibleAnswer("The lions would just incinerate and die if they get close to the sun resulting in a win for the sun", false), 
                new PossibleAnswer("The lions would win if they attacked at night", true), 
            });

            QuizElement earthMoonDistanceQuestion = new QuizElement("What is the shortest distance from the earth to the moon?", new List<PossibleAnswer> 
            {
                new PossibleAnswer("225.623 km", false), 
                new PossibleAnswer("326.457 km", false), 
                new PossibleAnswer("363.104 km", true), 
                new PossibleAnswer("276.648 km", false), 
                new PossibleAnswer("178.128 km", false)
            });

            QuizElement evaluationQuestion = new QuizElement("Was this quiz fun?", new List<PossibleAnswer> 
            {
                new PossibleAnswer("Yes", false), 
                new PossibleAnswer("Definitely so", false), 
                new PossibleAnswer("Sure", false), 
                new PossibleAnswer("Certainly", false), 
                new PossibleAnswer("Indeed, it was amazing", false),
                new PossibleAnswer("No", true)
            });

            quiz.AddQuizElement(smartestProgrammer);
            quiz.AddQuizElement(earthMoonDistanceQuestion);
            quiz.AddQuizElement(whoWouldWin);
            quiz.AddQuizElement(evaluationQuestion);

            int index = 0;
            while(true) 
            {
                Console.WriteLine("Type 'q' to answer a question and 'a' to add a new question. You may also type exit to leave the quiz.");
                string selectedAction = Console.ReadLine();

                if (selectedAction == "exit") 
                {
                    break;
                } else if (selectedAction == "q") 
                {
                    if (quiz.GetQuizElements().Count > index) 
                    {
                        AnswerQuestion(index, quiz);
                        index++;

                    } else 
                    {
                        Console.WriteLine("You answered all questions! You may still add new questions.");
                    }
                } else if (selectedAction == "a") 
                {
                    AddQuestion(quiz);
                } 
            }
        }
        private static void AnswerQuestion(int index, Quiz quiz) {
            QuizElement quizElement = quiz.GetQuizElement(index);

            Console.WriteLine(quizElement.GetQuestion());
            List<PossibleAnswer> possibleAnswers = quizElement.GetPossibleAnswers();

            for (int indexOfPossibleAnswer = 0; indexOfPossibleAnswer < possibleAnswers.Count; indexOfPossibleAnswer++) 
            {
                Console.WriteLine(indexOfPossibleAnswer.ToString() + ": " + possibleAnswers[indexOfPossibleAnswer].GetPossibleAnswer());
            }

            Console.WriteLine("Type the number corresponding to the correct answer.");
            try {
                int indexOfAnswer = Int32.Parse(Console.ReadLine());

                if (indexOfAnswer > possibleAnswers.Count - 1 || indexOfAnswer < 0) 
                {
                    Console.WriteLine("This number does not correspond with any of the given answers.");
                }
                else if (quiz.EvaluateAnswer(quizElement, indexOfAnswer)) 
                {
                    Console.WriteLine("Your answer was correct, you were awarded one point!");
                } else 
                {
                    Console.WriteLine("Your answer was sadly incorrect.");
                }
            } catch {
                Console.WriteLine("This is not a valid number.");
            }
            Console.WriteLine("You answered " + quiz.GetScore() + " out of " + quiz.GetAmountQuestions() + " questions correctly.");
        }

        private static void AddQuestion(Quiz quiz) 
        {
            Console.WriteLine("Type your question now!");
            string customQuestion = Console.ReadLine();
            bool oneCorrectAnswer = false;

            List<PossibleAnswer> customAnswers = new List<PossibleAnswer>();
            while(true) 
            {
                Console.WriteLine("Type one possible answer");
                string answer = Console.ReadLine();

                Console.WriteLine("Type true if this answer is the correct answer and false if it is not");
                try {
                    bool isCorrect = Boolean.Parse(Console.ReadLine());
                    if (oneCorrectAnswer && isCorrect) 
                    {
                        Console.WriteLine("Your question was not accepted; there may only be one correct answer.");
                    } else 
                    {
                        PossibleAnswer customAnswer = new PossibleAnswer(answer, isCorrect);
                        customAnswers.Add(customAnswer);
                    }
                    if (isCorrect) {
                        oneCorrectAnswer = true;
                    }

                } catch {
                    Console.WriteLine("Your question was not accepted; you need to type either true or false.");
                }
                if (oneCorrectAnswer) 
                {
                    Console.WriteLine("Type yes if you want to insert more possible answers.");
                    string continueInsertingAnswers = Console.ReadLine();
                    if (continueInsertingAnswers != "yes") 
                    {
                        break;
                    } 
                }
            }
            QuizElement customQuizElement = new QuizElement(customQuestion, customAnswers);
            quiz.AddQuizElement(customQuizElement);

        }

    }
}
