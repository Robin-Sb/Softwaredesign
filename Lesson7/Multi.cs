using System;
using System.Collections.Generic;

namespace Lesson7
{
    class Multi : QuizElement
    {
        public Multi(string question, List<AnswerClass> answers) {
            this.question = question;
            this.answers = answers;
            this.callToAction = "Type every number corresponding to the correct answer, e.g. 3 5 1";
        }
        List <AnswerClass> answers;
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
            string [] splittedInput = input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            bool [] inputForEveryAnswer = new bool[answers.Count];

            for (int i = 0; i < answers.Count; i++) 
            {
                inputForEveryAnswer[i] = false;
                for (int j = 0; j < splittedInput.Length; j++)
                {
                    if(splittedInput[j] == i.ToString())
                    {
                        inputForEveryAnswer[i] = true;
                    }
                }
                if (inputForEveryAnswer[i] != answers[i].isCorrect)
                {
                    return false;
                }
            }
            return true;
        }
    }
}