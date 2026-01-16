//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.oops.sceneriobased.AdressBookFolder
//{
//    internal class AdressBookMenu
//    {


//        public void ShowMenu()
//        {
//            IAdress system = new AddressBookSystem();
//            AdressBookUtility selectedBook = null;
//            string choice = "";
//            while (choice != "12")
//            {
//                Console.WriteLine("1. Add Address Book");
//                Console.WriteLine("2. Select Address Book");
//                Console.WriteLine("3. Add Contact");
//                Console.WriteLine("4. Edit Contact");
//                Console.WriteLine("5. Delete Contact");
//                Console.WriteLine("6. Add Multiple Contacts");
//                Console.WriteLine("7. Search by city name or state");
//                Console.WriteLine("8. ViewPerson by City");
//                Console.WriteLine("9. Count contacts by city name");
//                Console.WriteLine("10.Sort Contacts by name");
//                Console.WriteLine("11. Show Address Books");

//                Console.WriteLine("12. Exit");

//                Console.WriteLine("Enter your choice");
//                choice = Console.ReadLine();
//                switch (choice)
//                {
//                    case "1":
//                        system.AddAddressBook();
//                        break;

//                    case "2":
//                        selectedBook = system.SelectAddressBook();
//                        break;

//                    case "3":
//                        if (selectedBook != null)
//                            selectedBook.AddContact();
//                        else
//                            Console.WriteLine("Select Address Book first!");
//                        break;

//                    case "4":
//                        if (selectedBook != null)
//                            selectedBook.EditContact();
//                        else
//                            Console.WriteLine("Select Address Book first!");
//                        break;

//                    case "5":
//                        if (selectedBook != null)
//                            selectedBook.DeleteContact();
//                        else
//                            Console.WriteLine("Select Address Book first!");
//                        break;

//                    case "6":
//                        if (selectedBook != null)
//                            selectedBook.AddMultipleContact();
//                        else
//                            Console.WriteLine("Select Address Book first!");
//                        break;
//                    case "7":
//                        if (selectedBook != null)
//                            selectedBook.SearchByCityOrState();
//                        else
//                            Console.WriteLine("Select Address Book first!");
//                        break;
//                    case "8":
//                        if (selectedBook != null)
//                            selectedBook.ViewPersonsByCity();
//                        else
//                            Console.WriteLine("Select Address Book first!");
//                        break;
//                    case "9":
//                        if (selectedBook != null)
//                            selectedBook.CountByCity();
//                        else
//                            Console.WriteLine("Select Address Book first!");
//                        break;
//                    case "10":
//                        if (selectedBook != null)
//                            selectedBook.SortContactsByName();
//                        else
//                            Console.WriteLine("Select Address Book first!");
//                        break;

//                    case "11":
//                        system.DisplayAddressBooks(); 
//                        break;


//                    case "12":
//                        Console.WriteLine("Exiting...");
//                        break;

//                    default:
//                        Console.WriteLine("Invalid Choice");
//                        break;
//                }
//            }
//        }




//    }
//}
