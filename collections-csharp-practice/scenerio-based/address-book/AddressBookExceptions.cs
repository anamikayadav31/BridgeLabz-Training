using System;
namespace AddressBookSystem
{
// Thrown when a duplicate contact is added (UC-2)
public class DuplicateContactException : Exception{
    public DuplicateContactException(string message) : base(message){}
}

// Thrown when a contact is not found (UC-3 / UC-4)
public class ContactNotFoundException : Exception{
    public ContactNotFoundException(string message) : base(message){}
}

// Thrown when user enters invalid menu choice
public class InvalidMenuChoiceException : Exception{
    public InvalidMenuChoiceException(string message) : base(message){}
}

// Thrown when required input is empty
public class EmptyInputException : Exception{
    public EmptyInputException(string message) : base(message){}
}
}