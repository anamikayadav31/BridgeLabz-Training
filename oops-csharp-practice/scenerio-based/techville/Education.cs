using System;

// Education service that extends EducationService
public class Education : EducationService
{
    // Stores extra course info for premium users
    private string additionalCourse;

    // Constructor passes base details and sets extra course
    public Education(int serviceId, string instituteName, string courseName)
        : base(serviceId, instituteName)
    {
        this.additionalCourse = courseName;
    }

    // Override to include extra course access
    public override void ProvideService()
    {
        base.ProvideService(); // call parent behavior
        Console.WriteLine("Extra Course Access: " + additionalCourse);
    }
}
