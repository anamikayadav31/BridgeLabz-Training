using System;
namespace  HealthCheckPro
{


// Marks method as public API
[AttributeUsage(AttributeTargets.Method)]
public class PublicAPIAttribute : Attribute
{
    public string Description { get; }
    public PublicAPIAttribute(string description = "") => Description = description;
}

// Marks method as requiring authorization
[AttributeUsage(AttributeTargets.Method)]
public class RequiresAuthAttribute : Attribute
{
    public string Role { get; }
    public RequiresAuthAttribute(string role = "User") => Role = role;
}
}
