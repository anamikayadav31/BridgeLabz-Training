using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.DataStructuresAndAlgorithm.linkedList
{
   

    class UserNode
    {
        public int UserId;
        public string Name;
        public int Age;
        public List<int> Friends;   // Stores Friend IDs
        public UserNode Next;

        // Constructor
        public UserNode(int id, string name, int age)
        {
            UserId = id;
            Name = name;
            Age = age;
            Friends = new List<int>();
            Next = null;
        }
    }

    // Singly Linked List class
    class UserList
    {
        private UserNode head;

        // Add new user
        public void AddUser(int id, string name, int age)
        {
            UserNode node = new UserNode(id, name, age);
            node.Next = head;
            head = node;
            Console.WriteLine("User added.");
        }

        // Find user by ID
        private UserNode FindUserById(int id)
        {
            UserNode temp = head;
            while (temp != null)
            {
                if (temp.UserId == id)
                    return temp;
                temp = temp.Next;
            }
            return null;
        }

        // Add friend connection
        public void AddFriend(int id1, int id2)
        {
            UserNode u1 = FindUserById(id1);
            UserNode u2 = FindUserById(id2);

            if (u1 == null || u2 == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            if (!u1.Friends.Contains(id2))
                u1.Friends.Add(id2);
            if (!u2.Friends.Contains(id1))
                u2.Friends.Add(id1);

            Console.WriteLine("Friend connection added.");
        }

        // Remove friend connection
        public void RemoveFriend(int id1, int id2)
        {
            UserNode u1 = FindUserById(id1);
            UserNode u2 = FindUserById(id2);

            if (u1 == null || u2 == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            u1.Friends.Remove(id2);
            u2.Friends.Remove(id1);
            Console.WriteLine("Friend connection removed.");
        }

        // Display friends of a user
        public void DisplayFriends(int id)
        {
            UserNode user = FindUserById(id);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.WriteLine("Friends of " + user.Name + ":");
            foreach (int fid in user.Friends)
                Console.WriteLine("Friend ID: " + fid);
        }

        // Find mutual friends
        public void MutualFriends(int id1, int id2)
        {
            UserNode u1 = FindUserById(id1);
            UserNode u2 = FindUserById(id2);

            if (u1 == null || u2 == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.WriteLine("Mutual Friends:");
            bool found = false;

            foreach (int f in u1.Friends)
            {
                if (u2.Friends.Contains(f))
                {
                    Console.WriteLine("Friend ID: " + f);
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No mutual friends.");
        }

        // Search user by ID or Name
        public void Search(string key)
        {
            UserNode temp = head;
            bool found = false;

            while (temp != null)
            {
                if (temp.UserId.ToString() == key ||
                    temp.Name.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    DisplayUser(temp);
                    found = true;
                }
                temp = temp.Next;
            }

            if (!found)
                Console.WriteLine("User not found.");
        }

        // Count friends for each user
        public void CountFriends()
        {
            UserNode temp = head;
            while (temp != null)
            {
                Console.WriteLine(temp.Name + " has " + temp.Friends.Count + " friends.");
                temp = temp.Next;
            }
        }

        // Display single user
        private void DisplayUser(UserNode u)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("User ID: " + u.UserId);
            Console.WriteLine("Name   : " + u.Name);
            Console.WriteLine("Age    : " + u.Age);
            Console.WriteLine("Friends: " + u.Friends.Count);
        }
    }

    // MAIN CLASS
    class SocialMediaFriendConnections
    {
        static void Main()
        {
            UserList list = new UserList();
            int choice;

            do
            {
                Console.WriteLine("\n--- Social Media Friend Connections ---");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Add Friend Connection");
                Console.WriteLine("3. Remove Friend Connection");
                Console.WriteLine("4. Display Friends of User");
                Console.WriteLine("5. Find Mutual Friends");
                Console.WriteLine("6. Search User");
                Console.WriteLine("7. Count Friends for Each User");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("User ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Age: ");
                        int age = int.Parse(Console.ReadLine());
                        list.AddUser(id, name, age);
                        break;

                    case 2:
                        Console.Write("User ID 1: ");
                        int u1 = int.Parse(Console.ReadLine());
                        Console.Write("User ID 2: ");
                        int u2 = int.Parse(Console.ReadLine());
                        list.AddFriend(u1, u2);
                        break;

                    case 3:
                        Console.Write("User ID 1: ");
                        int r1 = int.Parse(Console.ReadLine());
                        Console.Write("User ID 2: ");
                        int r2 = int.Parse(Console.ReadLine());
                        list.RemoveFriend(r1, r2);
                        break;

                    case 4:
                        Console.Write("User ID: ");
                        list.DisplayFriends(int.Parse(Console.ReadLine()));
                        break;

                    case 5:
                        Console.Write("User ID 1: ");
                        int m1 = int.Parse(Console.ReadLine());
                        Console.Write("User ID 2: ");
                        int m2 = int.Parse(Console.ReadLine());
                        list.MutualFriends(m1, m2);
                        break;

                    case 6:
                        Console.Write("Enter User ID or Name: ");
                        list.Search(Console.ReadLine());
                        break;

                    case 7:
                        list.CountFriends();
                        break;
                }

            } while (choice != 0);
        }
    }

}
