using System;
using System.Collections.Generic; // Added for List

// Education service that extends EducationService
public class Education : EducationService
{
    // Collection to store multiple extra course titles for premium users
    private List<string> additionalCourses = new List<string>();

    public Education(int serviceId, string instituteName, string courseName)
        : base(serviceId, instituteName) //
    {
        this.additionalCourses.Add(courseName); // Initialize collection with first course
    }

    public override void ProvideService()
    {
        base.ProvideService(); // call parent behavior
        // Iterate through the collection to show all premium courses
        Console.WriteLine("Premium Courses: " + string.Join(", ", additionalCourses));
    }
}