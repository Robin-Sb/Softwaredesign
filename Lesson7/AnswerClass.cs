using System;

namespace Lesson7
{
    public class AnswerClass 
    {
        public AnswerClass() {}
        public AnswerClass (string text, bool isCorrect) {
            this.text = text;
            this.isCorrect = isCorrect;
        }

        public string text;
        public bool isCorrect;
    }
}