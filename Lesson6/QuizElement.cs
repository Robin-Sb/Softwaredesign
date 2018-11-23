using System;
using System.Collections.Generic; 

namespace Lesson6
{
    class QuizElement {

        public QuizElement (string question, List<PossibleAnswer> possibleAnswers) {
            this.question = question;
            this.possibleAnswers = possibleAnswers;
        }
        private string question;
        private List<PossibleAnswer> possibleAnswers;
        
        public string GetCorrectAnswer() 
        {
            foreach(PossibleAnswer answer in possibleAnswers) 
            {
                if(answer.GetIsCorrect()) 
                {
                    return answer.GetPossibleAnswer();
                }
            }
            return null;
        }

        public string GetQuestion()
        {
            return this.question;
        }

        public void GetQuestion(string question)
        {
            this.question = question;
        }

        public List<PossibleAnswer> GetPossibleAnswers()
        {
            return this.possibleAnswers;
        }

        public void SetPossibleAnswers(List<PossibleAnswer> possibleAnswers)
        {
            this.possibleAnswers = possibleAnswers;
        }


    }
}
