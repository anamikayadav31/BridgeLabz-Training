using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    internal class Contact
    {
        // UC-1
        // Private data members (store contact details internally)
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private string zip;
        private string phone;
        private string email;

        // Public properties (allow controlled access to private fields)

        // Get or set first name
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        // Get or set last name
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        // Get or set address
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        // Get or set city
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        // Get or set state
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        // Get or set ZIP code
        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        // Get or set phone number
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        // Get or set email
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        // Constructor - initializes contact when object is created
        public Contact(
            string firstName,
            string lastName,
            string address,
            string city,
            string state,
            string zip,
            string phone,
            string email)
        {
            // Assign values using properties
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            Phone = phone;
            Email = email;
        }

        // Utility method to return full name
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        // Override ToString() to display contact nicely
        public override string ToString()
        {
            return
                $"Name    : {FirstName} {LastName}\n" +
                $"Address : {Address}\n" +
                $"City    : {City}\n" +
                $"State   : {State}\n" +
                $"Zip     : {Zip}\n" +
                $"Phone   : {Phone}\n" +
                $"Email   : {Email}\n";
        }
    }
}
