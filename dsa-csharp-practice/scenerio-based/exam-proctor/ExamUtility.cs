using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.scenarioBased.examProctor
{
    internal class ExamUtility: IExamOperations
    {
            CustomStack navigationStack = new CustomStack(10);
            CustomHashMap answerMap = new CustomHashMap(10);

            Question[] questions =
            {
            new Question(1, "A"),
            new Question(2, "B"),
            new Question(3, "C")
        };

            int currentQuestionId;
            string currentAnswer;

            public void VisitQuestion()
            {
                Console.Write("Enter Question ID: ");
                currentQuestionId = int.Parse(Console.ReadLine());

                navigationStack.Push(currentQuestionId);
                Console.WriteLine("Visited Question: " + currentQuestionId);
            }

            public void SubmitAnswer()
            {
                Console.Write("Enter Question ID: ");
                currentQuestionId = int.Parse(Console.ReadLine());

                Console.Write("Enter Answer: ");
                currentAnswer = Console.ReadLine();

                answerMap.Put(currentQuestionId, currentAnswer);
                Console.WriteLine("Answer Stored Successfully");
            }

            public void EvaluateExam()
            {
                int score = 0;

                foreach (Question q in questions)
                {
                    string studentAnswer = answerMap.Get(q.QuestionId);
                    if (studentAnswer != null && studentAnswer == q.CorrectAnswer)
                    {
                        score++;
                    }
                }

                Console.WriteLine("Final Score: " + score);
            }

            public static void Main(string[] args)
            {
                ExamUtility exam = new ExamUtility();
                int choice;

                do
                {
                    Console.WriteLine("\n--- Exam Proctor Menu ---");
                    Console.WriteLine("1. Visit Question");
                    Console.WriteLine("2. Submit Answer");
                    Console.WriteLine("3. Submit Exam");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter choice: ");

                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            exam.VisitQuestion();
                            break;

                        case 2:
                            exam.SubmitAnswer();
                            break;

                        case 3:
                            exam.EvaluateExam();
                            break;
                    }

                } while (choice != 4);
            }
        }
    }



