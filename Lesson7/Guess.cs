using System;

namespace Lesson7
{
    class Guess : QuizElement
    {
        public Guess (string question, int answer) 
        {
            this.question = question;
            this.answer = answer;
            this.min = answer*0.9;
            this.max = answer*1.1;
            this.callToAction = "Guess the correct number!";
        }
        public double min;
        public double max;
        public int answer;
        public override void Show () 
        {
            Console.WriteLine(question);
        }

        public override bool IsRightOrWrong(string input) 
        {
            int inputNumber = Int32.Parse(input);

            if (inputNumber > min && inputNumber < max) 
            {
                return true;
            }
            return false;
        }

    }
}