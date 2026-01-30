using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.dataStructures.linkedList
{ 
    // friend id node
    class FriendNode
    {
        public int FriendId;
        public FriendNode Next;

        public FriendNode(int id)
        {
            FriendId = id;
            Next = null;
        }
    }

    // user node
    class UserNode
    {
        public int UserId;
        public string Name;
        public int Age;
        public FriendNode Friends;
        public UserNode Next;

        public UserNode(int id, string name, int age)
        {
            UserId = id;
            Name = name;
            Age = age;
            Friends = null;
            Next = null;
        }
    }

    // logic class
    class SocialMediaSystem
    {
        private UserNode head;

        // add user
        public void AddUser(int id, string name, int age)
        {
            UserNode newUser = new UserNode(id, name, age);

            if (head == null)
            {
                head = newUser;
                return;
            }

            UserNode temp = head;
            while (temp.Next != null)
                temp = temp.Next;

            temp.Next = newUser;
        }

        // add friend connection
        public void AddFriend(int id1, int id2)
        {
            UserNode u1 = FindUser(id1);
            UserNode u2 = FindUser(id2);

            if (u1 == null || u2 == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            AddFriendId(u1, id2);
            AddFriendId(u2, id1);

            Console.WriteLine("Friend connection added");
        }

        // remove friend connection
        public void RemoveFriend(int id1, int id2)
        {
            UserNode u1 = FindUser(id1);
            UserNode u2 = FindUser(id2);

            if (u1 == null || u2 == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            RemoveFriendId(u1, id2);
            RemoveFriendId(u2, id1);

            Console.WriteLine("Friend connection removed");
        }

        // display friends
        public void DisplayFriends(int id)
        {
            UserNode user = FindUser(id);

            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            Console.Write("Friends of " + user.Name + ": ");
            FriendNode temp = user.Friends;

            if (temp == null)
            {
                Console.WriteLine("No friends");
                return;
            }

            while (temp != null)
            {
                Console.Write(temp.FriendId + " ");
                temp = temp.Next;
            }

            Console.WriteLine();
        }

        // mutual friends
        public void MutualFriends(int id1, int id2)
        {
            UserNode u1 = FindUser(id1);
            UserNode u2 = FindUser(id2);

            if (u1 == null || u2 == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            Console.Write("Mutual friends: ");
            bool found = false;

            FriendNode f1 = u1.Friends;
            while (f1 != null)
            {
                if (HasFriend(u2, f1.FriendId))
                {
                    Console.Write(f1.FriendId + " ");
                    found = true;
                }
                f1 = f1.Next;
            }

            if (!found)
                Console.Write("None");

            Console.WriteLine();
        }

        // search user
        public void Search(string key)
        {
            UserNode temp = head;

            while (temp != null)
            {
                if (temp.UserId.ToString().Equals(key) ||
                    temp.Name.Equals(key, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(
                        "ID: " + temp.UserId +
                        ", Name: " + temp.Name +
                        ", Age: " + temp.Age);
                    return;
                }
                temp = temp.Next;
            }

            Console.WriteLine("User not found");
        }

        // count friends
        public void CountFriends()
        {
            UserNode temp = head;

            while (temp != null)
            {
                int count = 0;
                FriendNode f = temp.Friends;

                while (f != null)
                {
                    count++;
                    f = f.Next;
                }

                Console.WriteLine(temp.Name + " has " + count + " friends");
                temp = temp.Next;
            }
        }

        // helper methods
        private UserNode FindUser(int id)
        {
            UserNode temp = head;

            while (temp != null)
            {
                if (temp.UserId.Equals(id))
                    return temp;

                temp = temp.Next;
            }

            return null;
        }

        private void AddFriendId(UserNode user, int fid)
        {
            FriendNode newFriend = new FriendNode(fid);

            if (user.Friends == null)
            {
                user.Friends = newFriend;
                return;
            }

            FriendNode temp = user.Friends;
            while (temp.Next != null)
                temp = temp.Next;

            temp.Next = newFriend;
        }

        private void RemoveFriendId(UserNode user, int fid)
        {
            FriendNode temp = user.Friends;
            FriendNode prev = null;

            while (temp != null)
            {
                if (temp.FriendId.Equals(fid))
                {
                    if (prev == null)
                        user.Friends = temp.Next;
                    else
                        prev.Next = temp.Next;

                    return;
                }
                prev = temp;
                temp = temp.Next;
            }
        }

        private bool HasFriend(UserNode user, int fid)
        {
            FriendNode temp = user.Friends;

            while (temp != null)
            {
                if (temp.FriendId.Equals(fid))
                    return true;

                temp = temp.Next;
            }

            return false;
        }
    }

    // MAIN CLASS
    class SocialMedia
    {
        public static void Main(string[] args)
        {
            SocialMediaSystem sm = new SocialMediaSystem();
            int choice;

            do
            {
                Console.WriteLine("\nSocial Media Menu");
                Console.WriteLine("1 Add User");
                Console.WriteLine("2 Add Friend");
                Console.WriteLine("3 Remove Friend");
                Console.WriteLine("4 Display Friends");
                Console.WriteLine("5 Mutual Friends");
                Console.WriteLine("6 Search User");
                Console.WriteLine("7 Count Friends");
                Console.WriteLine("0 Exit");
                Console.Write("Choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("User ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Age: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        sm.AddUser(id, name, age);
                        break;

                    case 2:
                        Console.Write("First User ID: ");
                        int a = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Second User ID: ");
                        int b = Convert.ToInt32(Console.ReadLine());
                        sm.AddFriend(a, b);
                        break;

                    case 3:
                        Console.Write("First User ID: ");
                        int r1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Second User ID: ");
                        int r2 = Convert.ToInt32(Console.ReadLine());
                        sm.RemoveFriend(r1, r2);
                        break;

                    case 4:
                        Console.Write("User ID: ");
                        sm.DisplayFriends(Convert.ToInt32(Console.ReadLine()));
                        break;

                    case 5:
                        Console.Write("First User ID: ");
                        int m1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Second User ID: ");
                        int m2 = Convert.ToInt32(Console.ReadLine());
                        sm.MutualFriends(m1, m2);
                        break;

                    case 6:
                        Console.Write("Name or ID: ");
                        sm.Search(Console.ReadLine());
                        break;

                    case 7:
                        sm.CountFriends();
                        break;
                }

            } while (!choice.Equals(0));
        }
    }
}
