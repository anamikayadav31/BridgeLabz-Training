using System;
//Module-5
// Custom Exception for Duplicate Citizen
public class DuplicateResidentError : Exception
{
    public DuplicateResidentError(string errorMessage) 
        : base(errorMessage) {}
}
