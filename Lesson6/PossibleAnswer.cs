using System;

namespace Lesson6
{
    class PossibleAnswer {

        public PossibleAnswer (string possibleAnswer, bool isCorrect) {
            this.possibleAnswer = possibleAnswer;
            this.isCorrect = isCorrect;
        }

        public PossibleAnswer () { }

        private string possibleAnswer;
        private bool isCorrect;

        public string GetPossibleAnswer()
        {
            return this.possibleAnswer;
        }

        public void SetPossibleAnswer(string possibleAnswer)
        {
            this.possibleAnswer = possibleAnswer;
        }

        public bool GetIsCorrect()
        {
            return this.isCorrect;
        }

        public void SetIsCorrect(bool isCorrect)
        {
            this.isCorrect = isCorrect;
        }
    }
}