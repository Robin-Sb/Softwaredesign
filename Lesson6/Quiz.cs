using System;
using System.Collections.Generic; 

namespace Lesson6
{
    class Quiz {
        private int score = 0;
        private int amountQuestions = 0;

        private List<QuizElement> quizElements = new List<QuizElement>();

        public bool EvaluateAnswer (QuizElement quizElement, int indexOfAnswer) 
        {
            amountQuestions++;
            if (quizElement.GetPossibleAnswers()[indexOfAnswer].GetPossibleAnswer() == quizElement.GetCorrectAnswer()) 
            {
                score++;
                return true;
            }
            else 
            {
                return false;
            }
        }

        public void AddQuizElement (QuizElement quizElement) {
            quizElements.Add(quizElement);
        }

        public void AddAmountQuestions() {
            amountQuestions++;
        }

        public QuizElement GetQuizElement(int index) {
            return quizElements[index];
        }

        public int GetScore()
        {
            return this.score;
        }

        public void SetScore(int score)
        {
            this.score = score;
        }

        public int GetAmountQuestions()
        {
            return this.amountQuestions;
        }

        public void SetAmountQuestions(int amountQuestions)
        {
            this.amountQuestions = amountQuestions;
        }

        public List<QuizElement> GetQuizElements() 
        {
            return this.quizElements;
        }

    }
}