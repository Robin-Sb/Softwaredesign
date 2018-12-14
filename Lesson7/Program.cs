using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading;


namespace Lesson7
{
    class Program
    {
        static public int highscore;
        static public int answeredQuestions;
        public static int index = 0;
        static public List<QuizElement> quizElementList;
        public string userQuestion;
        public List<AnswerClass> userAnswer;
        public static JsonPersistence jsonPersistence = new JsonPersistence();

        static void Main(string[] args)
        {
            quizElementList = jsonPersistence.deserializeQuizElements();
            if (quizElementList == null)
            {
                quizElementList = new List<QuizElement>();
            }

            quizElementList.Shuffle();

            while(true) {
                Console.WriteLine("Please select what you want to do:");
                Console.WriteLine("1: add a new question");
                Console.WriteLine("2: answer a question");
                Console.WriteLine("3: exit the programm"); 

                string inputString = Console.ReadLine();  

                if (inputString == "1") 
                {
                    NewQuestion();
                    quizElementList = jsonPersistence.deserializeQuizElements();
                } else if (inputString == "2")
                {
                    if(quizElementList.Count > index) 
                    {
                        AnswerQuestion();
                    } else {
                        Console.WriteLine("You answered every question. You may still add new questions.");
                    }
                } else if (inputString == "3")
                {
                    break;
                } else 
                {
                    Console.WriteLine("Your input was not valid");
                }
            }
        }

        public static void AnswerQuestion()
        {
            QuizElement quizElement = quizElementList[index];
            index++;
            quizElement.Show();
            Console.WriteLine(quizElement.callToAction);
            string input = Console.ReadLine();
            if(quizElement.IsRightOrWrong(input))
            {
                highscore++;
                Console.WriteLine("Your answer was correct. You got one point.");
            } else {
                Console.WriteLine("Your answer was sadly incorrect.");
            }
            answeredQuestions++;
            Console.WriteLine("You answered " + highscore + " out of " + answeredQuestions + " correctly.");
        }
        public static void NewQuestion()
        {
            Console.WriteLine("Please insert your question");
            string userQuestion = Console.ReadLine();

            Console.Write("Type the number corresponding to the question type you want to add. \n" +
            "1: freetext question \n" +
            "2: yes/no question \n" + 
            "3: guess question \n" +
            "4: multiple answer question \n" +
            "5: single answer question \n");
            string questionType = Console.ReadLine();

            switch (questionType) 
            {
                case "1": quizElementList.Add(AddFreeTextQuestion(userQuestion));
                    break; 
                case "2": quizElementList.Add(AddBinaryQuestion(userQuestion));
                    break;
                case "3": quizElementList.Add(AddGuessQuestion(userQuestion));
                    break;
                case "4": quizElementList.Add(AddMultiQuestion(userQuestion));
                    break;
                case "5": quizElementList.Add(AddSingleQuestion(userQuestion));
                    break;
                default: Console.WriteLine("Your input was not valid.");
                    break;
            }
            jsonPersistence.serializeQuizElementToJson(quizElementList);
            Console.WriteLine("Your question was successfully added.");
        }

        public static QuizElement AddFreeTextQuestion(string question) 
        {
            Console.WriteLine("Please insert the correct answer");
            return new Free(question, Console.ReadLine());
        }

        public static QuizElement AddBinaryQuestion(string question) 
        {
            Console.WriteLine("Type y if your question is correct and n if it is not");
            string input = Console.ReadLine();
            bool isCorrect = false;
            if(input == "y")
            {
                isCorrect = true;
            }
            return new Binary(question, isCorrect);
        }

        public static QuizElement AddGuessQuestion(string question) 
        {
            Console.WriteLine("Please insert the correct number");
            int number = Int32.Parse(Console.ReadLine());
            return new Guess(question, number);
        }

        public static QuizElement AddMultiQuestion(string question) 
        {
            Console.WriteLine("How many possible answers do you want?");
            int howManyAnswers = Int32.Parse(Console.ReadLine());
            List <AnswerClass> userAnswers = new List<AnswerClass>();
            bool isCorrect;
            string text;
            for (int i = 0; i < howManyAnswers; i++)
            {
                Console.WriteLine("Please insert an answer");
                text = Console.ReadLine();
                Console.WriteLine("Type y if that answer is correct and n if it is not");
                if (Console.ReadLine() == "y") {
                    isCorrect = true;
                } else {
                    isCorrect = false;
                }
                userAnswers.Add(new AnswerClass(text, isCorrect));
            }
            return new Multi(question, userAnswers);
        }

        public static QuizElement AddSingleQuestion(string question) 
        {
            Console.WriteLine("How many possible answers do you want?");
            int howManyAnswers = Int32.Parse(Console.ReadLine());
            List <AnswerClass> userAnswers = new List<AnswerClass>();

            Console.WriteLine("Please insert the correct answer");
            userAnswers.Add(new AnswerClass(Console.ReadLine(), true));
            for(int i = 0; i < howManyAnswers - 1; i++) 
            {
                Console.WriteLine("Please insert an answer");
                userAnswers.Add(new AnswerClass(Console.ReadLine(), false));
            }
            userAnswers.Shuffle();
            QuizElement singleElement = new Single(question, userAnswers);
            return singleElement;
        } 

    }
    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }

    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        }
    }
}
