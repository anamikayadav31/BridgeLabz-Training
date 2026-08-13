using System;

namespace ContactsApp.Models;

// This class is our "model" - it represents one contact
// with its basic details (id, name, email, phone).


public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
}
