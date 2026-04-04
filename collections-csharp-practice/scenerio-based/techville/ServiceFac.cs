using System;

// Factory class to create different types of services
public static class ServiceFac
{
    // Method to create service based on type
    public static Services CreateService(string serviceType)
    {
        if (serviceType.ToLower() == "healthcare")
            return new HealthService(401, "City Hospital"); // Standard healthcare

        else if (serviceType.ToLower() == "education")
            return new EducationService(402, "City College"); // Standard education

        else if (serviceType.ToLower() == "premiumhealthcare")
            return new HealthCare(403,
                "Super Hospital", "24/7 Doctor Access"); // Premium healthcare

        else if (serviceType.ToLower() == "premiumeducation")
            return new Education(404,
                "Elite Institute", "AI Certification"); // Premium education

        return null; // Return null if type not recognized
    }
}
