using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    internal class Contact
    {
        // UC1: Contact details for Address Book

        // Private Fields (Data Storage)
        
        
        // These variables store the actual data.
        // They are private so they cannot be accessed directly from outside the class.

        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private string zip;
        private string phone;
        private string email;

        
        
        // Public Properties
        
        
        // Properties provide controlled access to private fields.
        // "get" returns value, "set" assigns value.

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        
        
        // Constructor
        
        
        // A constructor is used to initialize the object
        // when a new Contact is created.

        public Contact(string firstName, string lastName, string address,
                       string city, string state, string zip,
                       string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            Phone = phone;
            Email = email;
        }

        
        
        // Utility Method
        // Returns the full name by combining first and last name.

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        
        
        // Display Method
        
        
        // Overrides ToString() to print contact details
        // in a clean and readable format.

        public override string ToString()
        {
            return $"Name    : {FirstName} {LastName}\n" +
                   $"Address : {Address}\n" +
                   $"City    : {City}\n" +
                   $"State   : {State}\n" +
                   $"Zip     : {Zip}\n" +
                   $"Phone   : {Phone}\n" +
                   $"Email   : {Email}\n";
        }
    }
}
