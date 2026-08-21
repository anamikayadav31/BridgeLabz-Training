using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Dtos;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------------------------------
// 1. Add Swagger
// ----------------------------------------------------

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ----------------------------------------------------
// 2. Connect to SQL Server
// ----------------------------------------------------

// Get the connection string from appsettings.json
builder.Services.AddDbContext<AddressBookDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AddressBookDb")
    );
});


// ----------------------------------------------------
// 3. Register Repository Layer
// ----------------------------------------------------

// When we ask for IAddressBookRL,
// .NET will give us AddressBookRL
builder.Services.AddScoped<IAddressBookRL, AddressBookRL>();


// ----------------------------------------------------
// 4. Register Business Layer
// ----------------------------------------------------

// When we ask for IAddressBookBL,
// .NET will give us AddressBookBL
builder.Services.AddScoped<IAddressBookBL, AddressBookBL>();


// ----------------------------------------------------
// 5. Create the Web Application
// ----------------------------------------------------

var app = builder.Build();


// ----------------------------------------------------
// 6. Create Database / Apply Migrations
// ----------------------------------------------------

using (var scope = app.Services.CreateScope())
{
    // Get our DbContext
    var db = scope.ServiceProvider
                   .GetRequiredService<AddressBookDbContext>();

    // Create database if it does not exist
    // and apply pending migrations
    db.Database.Migrate();
}


// ----------------------------------------------------
// 7. Enable Swagger
// ----------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}


// ----------------------------------------------------
// 8. Use HTTPS
// ----------------------------------------------------

app.UseHttpsRedirection();


// ====================================================
// GET ALL CONTACTS
// ====================================================

app.MapGet("/api/addressbook", (IAddressBookBL bl) =>
{
    // Call Business Layer
    var contacts = bl.GetAll();

    // Return contacts
    return Results.Ok(contacts);
});


// ====================================================
// GET CONTACT BY ID
// ====================================================

app.MapGet("/api/addressbook/{id}", (int id, IAddressBookBL bl) =>
{
    // Find contact using ID
    var contact = bl.GetById(id);

    // If contact exists, return it
    if (contact != null)
    {
        return Results.Ok(contact);
    }

    // If contact does not exist
    return Results.NotFound("Contact not found");
});


// ====================================================
// ADD NEW CONTACT
// ====================================================

app.MapPost("/api/addressbook", (AddressBookDTO dto, IAddressBookBL bl) =>
{
    // Send contact data to Business Layer
    var contact = bl.Add(dto);

    // Return newly created contact
    return Results.Created(
        $"/api/addressbook/{contact.Id}",
        contact
    );
});


// ====================================================
// UPDATE CONTACT
// ====================================================

app.MapPut("/api/addressbook/{id}",
    (int id, AddressBookDTO dto, IAddressBookBL bl) =>
{
    // Update contact
    var contact = bl.Update(id, dto);

    // Check whether contact was found
    if (contact != null)
    {
        return Results.Ok(contact);
    }

    // Contact was not found
    return Results.NotFound("Contact not found");
});


// ====================================================
// DELETE CONTACT
// ====================================================

app.MapDelete("/api/addressbook/{id}", (int id, IAddressBookBL bl) =>
{
    // Delete contact
    var deleted = bl.Delete(id);

    // Check if deletion was successful
    if (deleted)
    {
        return Results.Ok("Contact deleted successfully");
    }

    // Contact was not found
    return Results.NotFound("Contact not found");
});


// ----------------------------------------------------
// 9. Start the Application
// ----------------------------------------------------

app.Run();