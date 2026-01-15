using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.AdressBookFolder
{
    internal class AdressBookMenu
    {
        

        public void ShowMenu()
        {
            AdressBookUtility utility = new AdressBookUtility();
            string choice = "";
            while (choice!="5")
            {
                Console.WriteLine("1.Add Contacts in AdressBook");
                Console.WriteLine("2.Edit Contact in AdressBook");
                Console.WriteLine("3.Delete Contact in AdressBook");
                Console.WriteLine("4.Add multiple contacts in AdressBook");
                Console.WriteLine("5.Exit");
                Console.WriteLine("Enter your choice");
                choice =Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        utility.AddContact();
                        break;
                    case "2":
                        utility.EditContact();
                        break;
                    case "3":
                        utility.DeleteContact();
                        break;
                    case "4":
                        utility.AddMultipleContact();
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }


                
            }
        }
    }
}
