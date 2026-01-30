using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.examProctor
{
        internal class Question
        {
            private int questionId;
            private string correctAnswer;

            public int QuestionId
            {
                get { return questionId; }
                set { questionId = value; }
            }

            public string CorrectAnswer
            {
                get { return correctAnswer; }
                set { correctAnswer = value; }
            }

            public Question(int id, string answer)
            {
                questionId = id;
                correctAnswer = answer;
            }
        }
    }




