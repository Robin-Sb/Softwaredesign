using System;

namespace Lesson7
{
    class Binary : QuizElement
    {
        public Binary (string question, bool isCorrect) 
        {
            this.question = question;
            this.truth = isCorrect;
            this.callToAction = "Type y if you think the question is correct, type n if you think it is not.";
        }
        public bool truth;

        public override void Show () 
        {
            Console.WriteLine(question);
        }

        public override bool IsRightOrWrong(string input) 
        {
            bool inputAsBool = false;
            if (input == "y")
            {
                inputAsBool = true;
            } 

            if (truth == inputAsBool) 
            {
                return true;
            } 
            return false;
        }
    }
}