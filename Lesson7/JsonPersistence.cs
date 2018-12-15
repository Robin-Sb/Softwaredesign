using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Lesson7 
{
    class JsonPersistence 
    {
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects,
            Formatting = Formatting.Indented
        };

        public void serializeQuizElementToJson (List<QuizElement> quizElements) 
        {
            string jsonQuestion = JsonConvert.SerializeObject(quizElements, settings);
            System.IO.File.WriteAllText(@"..\Lesson7\quiz.json", jsonQuestion);
        }

        public List<QuizElement> deserializeQuizElements()
        {
            List<QuizElement> quizElements = JsonConvert.DeserializeObject<List<QuizElement>>(File.ReadAllText(@"..\Lesson7\quiz.json"), settings);
            return quizElements;
        }
    }
}
