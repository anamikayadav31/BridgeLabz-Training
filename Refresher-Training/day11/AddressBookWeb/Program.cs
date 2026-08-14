using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Dtos;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;



// Create the application
var builder = WebApplication.CreateBuilder(args);

// Add OpenAPI support
builder.Services.AddOpenApi();


// Connect application to SQL Server
builder.Services.AddDbContext<AddressBookDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AddressBookDb")
    ));


// Register Repository Layer
builder.Services.AddScoped<IAddressBookRL, AddressBookRL>();

// Register Business Layer
builder.Services.AddScoped<IAddressBookBL, AddressBookBL>();


var app = builder.Build();


// Apply any pending migrations and create database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
                  .GetRequiredService<AddressBookDbContext>();

    db.Database.Migrate();
}


// Enable OpenAPI only in Development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();


// ================= GET ALL =================

// Get all contacts
app.MapGet("/api/addressbook", (IAddressBookBL bl) =>
{
    return Results.Ok(bl.GetAll());
});


// ================= GET BY ID =================

// Get one contact by ID
app.MapGet("/api/addressbook/{id}", (int id, IAddressBookBL bl) =>
{
    var contact = bl.GetById(id);

    return contact is not null
        ? Results.Ok(contact)
        : Results.NotFound("Contact not found");
});


// ================= ADD =================

// Add a new contact
app.MapPost("/api/addressbook", (AddressBookDTO dto, IAddressBookBL bl) =>
{
    var created = bl.Add(dto);

    return Results.Created(
        $"/api/addressbook/{created.Id}",
        created
    );
});


// ================= UPDATE =================

// Update an existing contact
app.MapPut("/api/addressbook/{id}",
    (int id, AddressBookDTO dto, IAddressBookBL bl) =>
{
    var updated = bl.Update(id, dto);

    return updated is not null
        ? Results.Ok(updated)
        : Results.NotFound("Contact not found");
});


// ================= DELETE =================

// Delete a contact
app.MapDelete("/api/addressbook/{id}", (int id, IAddressBookBL bl) =>
{
    var deleted = bl.Delete(id);

    return deleted
        ? Results.Ok("Deleted")
        : Results.NotFound("Contact not found");
});


// Start the application
app.Run();