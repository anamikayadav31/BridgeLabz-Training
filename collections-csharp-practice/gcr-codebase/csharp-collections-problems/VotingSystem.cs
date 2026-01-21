//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.Collections.collections_problems
//{
//    internal class VotingSystem
//    {



//        static void Main()
//        {
//            // Dictionary to store votes
//            Dictionary<string, int> votes = new Dictionary<string, int>();

//            // List to maintain the order of candidates (LinkedHashMap behavior)
//            List<string> candidateOrder = new List<string>();

//            Console.WriteLine("Voting System");

//            // Step 1: Enter number of candidates
//            Console.Write("Enter number of candidates: ");
//            int numCandidates;
//            while (!int.TryParse(Console.ReadLine(), out numCandidates) || numCandidates <= 0)
//            {
//                Console.Write("Invalid input. Enter a positive integer: ");
//            }

//            // Step 2: Enter candidate names
//            for (int i = 1; i <= numCandidates; i++)
//            {
//                Console.Write($"Enter name of candidate #{i}: ");
//                string candidate = Console.ReadLine();

//                if (!votes.ContainsKey(candidate))
//                {
//                    votes[candidate] = 0; // Initialize votes
//                    candidateOrder.Add(candidate); // Maintain order
//                }
//                else
//                {
//                    Console.WriteLine("Candidate already exists. Enter a unique name.");
//                    i--; // repeat this iteration
//                }
//            }

//            Console.WriteLine("\nVoting starts! Type the candidate name to vote. Type 'done' to finish.");

//            // Step 3: Accept votes
//            while (true)
//            {
//                Console.Write("Vote for: ");
//                string vote = Console.ReadLine();

//                if (vote.ToLower() == "done")
//                    break;

//                if (votes.ContainsKey(vote))
//                {
//                    votes[vote]++;
//                }
//                else
//                {
//                    Console.WriteLine("Invalid candidate name. Try again.");
//                }
//            }

//            // Step 4: Display results in order of entry
//            Console.WriteLine("\nResults in order of candidates:");
//            foreach (var candidate in candidateOrder)
//            {
//                Console.WriteLine($"{candidate}: {votes[candidate]} vote(s)");
//            }

//            // Step 5: Display results in alphabetical order
//            Console.WriteLine("\nResults in alphabetical order:");
//            SortedDictionary<string, int> sortedVotes = new SortedDictionary<string, int>(votes);
//            foreach (var kvp in sortedVotes)
//            {
//                Console.WriteLine($"{kvp.Key}: {kvp.Value} vote(s)");
//            }

//            // Step 6 (Optional): Display results by highest votes
//            Console.WriteLine("\nResults sorted by votes (highest to lowest):");
//            foreach (var kvp in votes.OrderByDescending(v => v.Value))
//            {
//                Console.WriteLine($"{kvp.Key}: {kvp.Value} vote(s)");
//            }
//        }
//    }
//}