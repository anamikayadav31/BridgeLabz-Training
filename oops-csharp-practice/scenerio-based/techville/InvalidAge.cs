using System;
//Module-5
// Custom Exception for Invalid Age
public class InvalidAge : Exception
{
    public InvalidAge(string errorMessage) 
        : base(errorMessage) {}
}
