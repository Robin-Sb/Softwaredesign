using System;

namespace Lesson7
{
    abstract class QuizElement 
    {
        public string question;
        public string callToAction; 

        public abstract void Show ();

        public abstract bool IsRightOrWrong (string input);
        public void EditHighscore () 
        {

        }
    }
}
