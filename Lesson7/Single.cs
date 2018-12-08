using System;
using System.Collections.Generic;

namespace Lesson7
{
    class Single : QuizElement
    {
        public Single (string question, List<AnswerClass> answers)
        {
            this.question = question;
            this.callToAction = "Type the number corresponding to the correct answer";
            this.answers = answers;
        }
        public List<AnswerClass> answers; 
        public override void Show () 
        {
            Console.WriteLine(question);

            for (int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine(i + ": " + answers[i].text);
            }
        }
        public override bool IsRightOrWrong(string input) 
        {
            int inputNumber = Int32.Parse(input);
            for (int i = 0; i < answers.Count; i++) 
            {
                if(answers[i].isCorrect && i == inputNumber)
                {
                    return true;
                }
            }
            return false;
        }

    }
}