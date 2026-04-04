using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.scenerioBased
{
    internal class LibraryManagement
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter no. of books:");
            int books = int.Parse(Console.ReadLine());
            string[] title = new string[books];
            string[] author = new string[books];
            string[] status = new string[books];

            // Taking book-wise input
            for (int i = 0; i < books; i++)
            {
                Console.WriteLine($"\nEnter details for Book {i + 1}");
                Console.Write("Title  : ");
                title[i] = Console.ReadLine();

                Console.Write("Author : ");
                author[i] = Console.ReadLine();

                Console.Write("Status : ");
                status[i] = Console.ReadLine();
            }

            Console.WriteLine("User Type \n");
            Console.WriteLine("Enter 1 if you are a  Librarian");
            Console.WriteLine("Enter 2. if you are a Student");
           
            string adminChoice = Console.ReadLine();

            if (adminChoice.Equals("1"))
            {
                Console.WriteLine("1. Search Book");
                Console.WriteLine("2. Display Books");
                Console.WriteLine("3. Update Book Status");
                Console.WriteLine("Enter 1. if you want to search a book in library");
                Console.WriteLine("Enter 2. if you want to display books details");
                Console.WriteLine("Enter 3. if you want to update status");
            }
            else
            {
                Console.WriteLine("1. Search Book");
                Console.WriteLine("2. Display Books");
                Console.WriteLine("Enter 1. if you want to search a book in library");
                Console.WriteLine("Enter 2. if you want to display books details");
            }
            


            string choice = Console.ReadLine();
            switch (adminChoice)
            {
                case "1"://for librarian
                    switch (choice)
                    {
                        case "1":                         
                            Console.WriteLine(Searching(title, author, status));
                            break;
                        case "2":                         
                            Console.WriteLine(Displaying(title, author));
                            break;
                        case "3":                          
                            Console.WriteLine(Updating(title, status));
                            break;
                        default:
                            Console.WriteLine("Invalid");
                            break;
                    }
                    break;
                case "2"://for student
                    switch (choice)
                    {
                        case "1":                        
                            Console.WriteLine(Searching(title, author, status));
                            break;
                        case "2":
                            Console.WriteLine(Displaying(title, author));
                            break;
                        default:
                            Console.WriteLine("Invalid");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;




            }
        }
            

               
            
        //create a function to search a book
        
        public static string Searching(string[] title, string[] author, string[] status)
        {
            Console.WriteLine("Enter BookName that you want to search:");
            String bookName = Console.ReadLine();
            Console.WriteLine("Enter AuthorName that you want to search:");
            String  authorName= Console.ReadLine();
            for (int i = 0; i < title.Length; i++)
            {
                if (title[i].Equals(bookName) && author[i].Equals(authorName))
                {
                    
                    return "status of book is : "+status[i];
                }

               

            }

            return "Status of book is: no book found";

        }
        //create a function to print books with author names
        public static  string Displaying(string []title, string[] author)
        {
            string result = " ";
            for(int i=0; i < title.Length; i++)
            {
                result+= title[i] + " : " + author[i]+"\n";
            }
            Console.WriteLine("List of books and their respected authors :");
            return result;
        }
        //create a function to update the status of book
        public static string Updating(string[] title, string[] status)
        {
            Console.WriteLine("Enter book name to update status:");
            string bName = Console.ReadLine();
            for (int i = 0; i < title.Length; i++)
            {
                if (title[i].Equals(bName))
                {
                    Console.WriteLine("Enter new status:");
                    status[i] = Console.ReadLine();
                    Console.WriteLine("status of book updation:");
                    return "Status updated successfully";
                }
            }

            return "Book not found";
        }

    }
}
        