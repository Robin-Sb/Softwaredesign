/* Mögliche Änderungsvorschläge: 
- Die Subklassen genauer bennennen. Z.b. Nicht nur "Binary" sondern vielleicht "QuizBinary", dann wird direkt klar, dass es zu "Quizelement" gehört.
- Die Methode "NewQuestion" vielleicht in "AddNewQuestion" umbenennen --> Funktion der Klasse wird dann eher deutlich.
*/
using System;
using System.Collections.Generic;

namespace Lesson7
{
    class Program
    {
        static public int highscore;
        static public int answeredQuestions;
        public static int index = 0;
        static public List<QuizElement> quizElementList = new List<QuizElement>();
        public string userQuestion;
        public List<AnswerClass> userAnswer;
        static void Main(string[] args)
        {
            CreateQuizElements();

            while(true) {
                Console.WriteLine("Please select what you want to do:");
                Console.WriteLine("1: add a new question");
                Console.WriteLine("2: answer a question");
                Console.WriteLine("3: exit the programm"); 

                string inputString = Console.ReadLine();  

                if (inputString == "1") 
                {
                    NewQuestion();
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

        public static void CreateQuizElements() 
        {
            quizElementList.Add(new Multi("If you pick an answer to this question at random, what is the chance that you will be correct?", new List<AnswerClass>{
                new AnswerClass("Can't be answered because we don't know how many questions are correct", false),
                new AnswerClass("It's 50%, either it is correct or it is not", true),
                new AnswerClass("It's obviously 25%", false),
                new AnswerClass("It's 100% if I believe in myself", true),
            }));
            quizElementList.Add(new Single("Who is the worlds smartest programmer?", new List<AnswerClass>{
                new AnswerClass("Terry Davis", true), 
                new AnswerClass("Linus Torwalds", false), 
                new AnswerClass("James Gosling", false), 
                new AnswerClass("Bjarne Stroustrup", false) 
            }));
            quizElementList.Add(new Guess("What is the square root of 676", 26));
            quizElementList.Add(new Binary("Can 1 trillion lions win against the sun if they attack at night?", true));
            quizElementList.Add(new Free("Who is currently the best president of the united states?", "Donald Trump"));
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
            Console.WriteLine("Your question was successfully added.");
        }

        public static QuizElement AddFreeTextQuestion(string question) {
            Console.WriteLine("Please insert the correct answer");
            return new Free(question, Console.ReadLine());
        }
        public static QuizElement AddBinaryQuestion(string question) {
            Console.WriteLine("Type y if your question is correct and n if it is not");
            string input = Console.ReadLine();
            bool isCorrect = false;
            if(input == "y")
            {
                isCorrect = true;
            }
            return new Binary(question, isCorrect);
        }
        public static QuizElement AddGuessQuestion(string question) {
            Console.WriteLine("Please insert the correct number");
            int number = Int32.Parse(Console.ReadLine());
            return new Guess(question, number);
        }
        public static QuizElement AddMultiQuestion(string question) {
            Console.WriteLine("How many possible answers do you want?");
            int howManyAnswers = Int32.Parse(Console.ReadLine());
            List <AnswerClass> userAnswers = new List<AnswerClass>();
            AnswerClass userAnswer = new AnswerClass();
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
        public static QuizElement AddSingleQuestion(string question) {
            Console.WriteLine("How many possible answers do you want?");
            int howManyAnswers = Int32.Parse(Console.ReadLine());
            List <AnswerClass> userAnswers = new List<AnswerClass>();

            Console.WriteLine("Please insert the correct answer");
            userAnswers.Add(new AnswerClass(Console.ReadLine(), true));

            for(int i = 0; i < howManyAnswers; i++) 
            {
                Console.WriteLine("Please insert an answer");
                userAnswers.Add(new AnswerClass(Console.ReadLine(), false));
            }
            return new Single(question, userAnswers);
        }
    }
}
