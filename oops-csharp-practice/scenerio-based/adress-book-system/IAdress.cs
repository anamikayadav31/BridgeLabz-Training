using System;
using System.Collections.Generic;
using System.Text;

namespace BridgeLabzTraining.oops.sceneriobased.AdressBookFolder
{
    internal interface IAdress
    {
        void AddContact();
        void EditContact();
        void DeleteContact();
        void AddMultipleContact();
        void AddAddressBook();
        AdressBookUtility SelectAddressBook();
        void DisplayAddressBooks();

    }
}