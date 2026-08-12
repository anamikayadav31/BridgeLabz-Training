using ContactsApp.Database;
using ContactsApp.Models;
using ContactsApp.Repositories;

// This is a small Web API project to manage Contacts (Name, Email, Phone)
// using ASP.NET Core Minimal API + SQL Server.

var builder = WebApplication.CreateBuilder(args);

// Register my classes so I can use them anywhere with Dependency Injection
builder.Services.AddSingleton<DbConnection>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

// Just a simple home route to check if the API is running
app.MapGet("/", () =>
{
    return "Contacts API is running!";
});

// GET all contacts
app.MapGet("/contacts", (IContactRepository repo) =>
{
    List<Contact> contacts = repo.GetAll();
    return Results.Ok(contacts);
});

// GET a single contact by Id
app.MapGet("/contacts/{id:int}", (int id, IContactRepository repo) =>
{
    Contact? contact = repo.GetById(id);

    if (contact == null)
    {
        return Results.NotFound("Contact not found");
    }
    else
    {
        return Results.Ok(contact);
    }
});

// POST - add a new contact
app.MapPost("/contacts", (Contact contact, IContactRepository repo) =>
{
    // basic validation, so we don't save empty contacts
    if (string.IsNullOrWhiteSpace(contact.Name))
    {
        return Results.BadRequest("Name is required");
    }

    repo.Add(contact);
    return Results.Created("/contacts", contact);
});

// PUT - update an existing contact
app.MapPut("/contacts/{id:int}", (int id, Contact contact, IContactRepository repo) =>
{
    Contact? existingContact = repo.GetById(id);

    if (existingContact == null)
    {
        return Results.NotFound("Contact not found");
    }

    contact.Id = id;
    repo.Update(contact);

    return Results.Ok("Contact updated successfully");
});

// DELETE - remove a contact
app.MapDelete("/contacts/{id:int}", (int id, IContactRepository repo) =>
{
    Contact? existingContact = repo.GetById(id);

    if (existingContact == null)
    {
        return Results.NotFound("Contact not found");
    }

    repo.Delete(id);
    return Results.Ok("Contact deleted successfully");
});

app.Run();
