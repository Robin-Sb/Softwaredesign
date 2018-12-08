using System;

namespace Lesson7
{
    class Free : QuizElement
    {
        public Free(string question, string answerWord)
        {
            this.question = question;
            this.answerWord = answerWord;
            this.callToAction = "Type the correct word!";
        }
        public string answerWord;
        public override void Show () 
        {
            Console.WriteLine(question);
        }

        public override bool IsRightOrWrong(string input) 
        {
            if(input.ToUpper() == answerWord.ToUpper())
            {
                return true;
            }
            return false;
        }
    }
}