namespace AddressBookSystem{
    internal interface IAddressBook
    {
            void AddContact();     // UC2 + UC7
            void EditContact();    // UC3
            void DeleteContact();  // UC4
            void AddMultipleContacts(); // UC5

            void SearchByCityOrState();   // UC8
            void ViewPersonsByCityOrState();   // UC9
            void CountPersonsByCityOrState();   // UC10

            void SortContactsByName();   // UC-11

            void SortContactsByCity();  //UC-12
            void SortContactsByState();  //UC-12
            void SortContactsByZip();    //UC-12


            void WriteContactsToFile();  //UC-13
            void ReadContactsFromFile();  //UC-13

            void WriteContactsToCSV();   //UC-14
            void ReadContactsFromCSV();  //UC-14

            void WriteContactsToJSON(); //UC-15
            void ReadContactsFromJSON(); //UC-15




    }
}

