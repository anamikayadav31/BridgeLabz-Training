# Fundoo Notes App - User Module (4-Project Solution)

Same layered architecture as your working project: one solution split
into 4 separate class-library projects, wired together with
Dependency Injection. Functionality: **Register → Login (JWT) →
Forgot Password → Reset Password**.

## Solution layout

```
FundooNotesApp/
├── FundooNotesApp.slnx
│
├── FundooNotesApp.API/                  <- the web host (Controllers + Program.cs)
│   ├── Controllers/UserController.cs
│   ├── Program.cs
│   └── appsettings.json
│
├── FundooNotesApp.BusinessLayer/        <- "BL" = business rules
│   ├── Interfaces/IUserBL.cs
│   ├── Services/UserBL.cs
│   └── Helpers/
│       ├── PasswordHelper.cs             <- wraps BCrypt hashing
│       └── TokenGenerator.cs             <- builds JWT tokens
│
├── FundooNotesApp.ModelLayer/            <- pure data shapes, no logic
│   ├── Entities/UserEntity.cs             <- DB row shape
│   ├── Models/UserModel.cs                <- safe "no password" copy of a user
│   ├── DTOs/
│   │   ├── RequestDTO/  (RegistrationDTO, LoginDTO, ForgotPasswordDTO, ResetPasswordDTO)
│   │   └── ResponseDTO/ (ResponseDTO<T> - the standard API envelope)
│   └── Exceptions/ (UserAlreadyExistsException, UserNotFoundException, InvalidCredentialsException)
│
└── FundooNotesApp.RepositoryLayer/       <- "RL" = database access only
    ├── Context/FundooContext.cs           <- EF Core DbContext
    ├── Interfaces/IUserRL.cs
    └── Services/UserRL.cs
```

## Why 4 separate PROJECTS instead of folders?

This is a step up from a single-project layout: each layer is its own
`.csproj`, and project REFERENCES enforce the direction of dependency
at compile time — you physically cannot make a mistake like calling
the database straight from a Controller, because the API project never
references RepositoryLayer directly.

```
API  --references-->  BusinessLayer  --references-->  RepositoryLayer  --references-->  ModelLayer
                              \_______________________________________________________/
                                       (BusinessLayer also references ModelLayer directly)
```

## Request flow (Register example)

```
POST /api/user/register
        |
        v
UserController.Register()          <- only handles HTTP status codes
        |
        v
IUserBL.Register()  ->  UserBL     <- checks email isn't taken, hashes password
        |
        v
IUserRL.Register()  ->  UserRL     <- saves the row via FundooContext
        |
        v
   SQL Server "Users" table
```

## Endpoints

| Method | URL                          | What it does                              |
|--------|-------------------------------|---------------------------------------------|
| POST   | `/api/user/register`          | Create a new account                        |
| POST   | `/api/user/login`             | Log in, get back a JWT token                |
| GET    | `/api/user/profile` 🔒        | **Protected** - only works with a valid JWT |
| POST   | `/api/user/forget-password`   | Get a reset token (valid 30 minutes)        |
| POST   | `/api/user/reset-password`    | Set a new password using the reset token    |

### Testing the protected `/profile` endpoint
1. Call `/api/user/login` and copy the token from the `data` field.
2. In Swagger, click the padlock/Authorize button near the top and paste:
   `Bearer <your-token>`
3. Now call `GET /api/user/profile` - it will read the `UserId` and
   `Email` straight out of your token (no extra database lookup) and
   echo them back. Without the token, this endpoint returns 401
   automatically - ASP.NET Core's `[Authorize]` attribute blocks it
   before our own code even runs.

## Notes Management Module

Every endpoint under `/api/notes/...` requires you to be logged in -
the whole `NoteController` is marked `[Authorize]`. Notes are always
linked to whoever's token you used; there is no way to view, edit, or
delete a note "as" someone else.

| Method | URL                             | What it does                                    |
|--------|-----------------------------------|----------------------------------------------------|
| POST   | `/api/notes/create`               | Create a note owned by the logged-in user           |
| GET    | `/api/notes/all`                  | List all your notes, pinned-first, newest-first     |
| GET    | `/api/notes/{noteId}`             | Get one note by id                                  |
| DELETE | `/api/notes/{noteId}`             | Permanently delete - only works if already trashed  |
| PATCH  | `/api/notes/{noteId}/pin`         | Toggle pinned on/off (un-archives it automatically) |
| PATCH  | `/api/notes/{noteId}/archive`     | Toggle archived on/off (un-pins it automatically)   |
| PATCH  | `/api/notes/{noteId}/trash`       | Move to trash (soft delete)                         |
| PATCH  | `/api/notes/{noteId}/restore`     | Bring a trashed note back                           |
| GET    | `/api/notes/search?keyword=...`   | Search notes by **title**                           |
| GET    | `/api/notes/filter?keyword=...`   | Search notes by **title or description**            |
| GET    | `/api/notes/summary`              | Counts: active / pinned / archived / trashed        |

### Create a note (body)
```json
{
  "title": "Grocery List",
  "description": "Milk, eggs, bread",
  "reminder": "2026-08-25T09:00:00Z",
  "backgroundColor": "#FFE08A"
}
```

### Business rules worth knowing
- **Pin and Archive are mutually exclusive** - pinning a note
  automatically un-archives it, and vice versa.
- **A trashed note can't be pinned or archived** - restore it first.
- **Permanent delete only works from the trash** - this is a safety
  net, same idea as Gmail: trash first, delete for good second.
- All ownership checks compare the note's `UserId` against the
  `UserId` claim baked into your JWT - never against anything the
  client sends in the request body.

**Folder additions for this module:**
```
ModelLayer/Entities/NoteEntity.cs
ModelLayer/Models/NoteModel.cs
ModelLayer/Models/NotesSummaryModel.cs
ModelLayer/DTOs/RequestDTO/CreateNoteDTO.cs
ModelLayer/Exceptions/NoteNotFoundException.cs
RepositoryLayer/Interfaces/INoteRL.cs
RepositoryLayer/Services/NoteRL.cs
BusinessLayer/Interfaces/INoteBL.cs
BusinessLayer/Services/NoteBL.cs
API/Controllers/NoteController.cs
```

Since the `Notes` table's columns changed (new fields like Reminder,
BackgroundColor, IsPinned, IsArchived, IsTrashed, LastEditedOn), you
need a fresh migration before this works - see "How to run it" below.

## Tags / Labels Module

Simple many-to-many tagging - one tag (like "Work" or "Urgent") can be
attached to many notes, and one note can have many tags. Every
endpoint requires login, and both the tag AND the note must belong to
you before you can link them together.

| Method | URL                              | What it does                          |
|--------|-------------------------------------|--------------------------------------------|
| POST   | `/api/tags/create`                  | Create a new tag                            |
| GET    | `/api/tags/all`                     | List all your tags                          |
| GET    | `/api/tags/{tagId}`                 | Get a single tag by id                      |
| PUT    | `/api/tags/{tagId}`                 | Rename a tag                                |
| DELETE | `/api/tags/{tagId}`                 | Delete a tag (also unlinks it from notes)   |
| POST   | `/api/tags/{tagId}/attach/{noteId}` | Attach a tag to a note                      |
| DELETE | `/api/tags/{tagId}/detach/{noteId}` | Remove a tag from a note                    |

**New files:** `ModelLayer/Entities/TagEntity.cs`,
`ModelLayer/Entities/NoteTagEntity.cs` (the join table),
`ModelLayer/DTOs/RequestDTO/CreateTagDTO.cs`, `ModelLayer/Models/TagModel.cs`,
`ModelLayer/Exceptions/TagNotFoundException.cs`,
`RepositoryLayer/Interfaces/ITagRL.cs`, `RepositoryLayer/Services/TagRL.cs`,
`BusinessLayer/Interfaces/ITagBL.cs`, `BusinessLayer/Services/TagBL.cs`,
`API/Controllers/TagController.cs`.

## Reminder Module

Lets you set one or more reminders on a note. Every endpoint requires
login, and setting a reminder on a note you don't own is blocked the
same way tagging is.

| Method | URL                          | What it does                              |
|--------|--------------------------------|-----------------------------------------------|
| POST   | `/api/reminders/create`        | Set a reminder on one of your notes            |
| GET    | `/api/reminders/all`           | List all your reminders, soonest first         |
| DELETE | `/api/reminders/{reminderId}`  | Remove a reminder                              |

### Create a reminder (body)
```json
{ "noteId": 5, "reminderTime": "2026-08-30T09:00:00Z" }
```

### Why a separate Reminders table instead of a field on Note?
A reminder date used to live directly on `NoteEntity`. Pulling it out
into its own table like this is a small design upgrade: it leaves
room to support multiple reminders per note later (e.g. a repeating
reminder, or a snooze history) without ever having to reshape the
Notes table again.

**New files:** `ModelLayer/Entities/ReminderEntity.cs`,
`ModelLayer/DTOs/RequestDTO/CreateReminderDTO.cs`, `ModelLayer/Models/ReminderModel.cs`,
`ModelLayer/Exceptions/ReminderNotFoundException.cs`,
`RepositoryLayer/Interfaces/IReminderRL.cs`, `RepositoryLayer/Services/ReminderRL.cs`,
`BusinessLayer/Interfaces/IReminderBL.cs`, `BusinessLayer/Services/ReminderBL.cs`,
`API/Controllers/ReminderController.cs`.

## Unit Testing with MSTest

A new `FundooNotesApp.Tests` project holds unit tests for the
Business layer - `NoteBLTests`, `UserBLTests`, `TagBLTests`, and
`ReminderBLTests`. Instead of a mocking library, these tests use small hand-written
"fake" repositories (`FundooNotesApp.Tests/Fakes/`) that store data in
a plain in-memory list - fast, no database needed, and easy to read
for beginners.

Run all tests from the solution root:
```
dotnet test
```

Example tests included:
- `Register_ShouldThrow_WhenEmailAlreadyExists`
- `Register_ShouldNeverStoreThePlainPassword` (checks BCrypt hashing actually happened)
- `TogglePin_ShouldAlsoUnarchiveTheNote` (checks the mutual-exclusion business rule)
- `DeleteNote_ShouldThrow_WhenNoteIsNotYetTrashed` (checks the safety-net rule)
- `AttachTagToNote_ShouldThrow_WhenTheNoteBelongsToSomeoneElse` (checks tag ownership security)

### Register (body)
```json
{ "firstName": "Riya", "lastName": "Sharma", "email": "riya@example.com", "password": "MySecret123" }
```

### Login (body) → response `data` field contains your JWT
```json
{ "email": "riya@example.com", "password": "MySecret123" }
```

### Forget password (body)
```json
{ "email": "riya@example.com" }
```

### Reset password (body) - token comes from the forget-password response
```json
{ "token": "the-token-you-got-back", "newPassword": "MyNewSecret456" }
```

## How to run it

1. Install the [.NET 8 SDK](https://dotnet.microsoft.com/download) and
   SQL Server / LocalDB (comes with Visual Studio).
2. Open `FundooNotesApp.API/appsettings.json` and:
   - Update `ConnectionStrings:FundooDbConnection` if your SQL Server
     setup is different.
   - Replace `JwtSettings:SecretKey` with your own long random string
     (32+ characters).
3. From the `FundooNotesApp.API` folder, create the database table:
   ```
   dotnet tool install --global dotnet-ef   (only needed once)
   dotnet ef migrations add InitialCreate --project ../FundooNotesApp.RepositoryLayer --startup-project .
   dotnet ef database update --project ../FundooNotesApp.RepositoryLayer --startup-project .
   ```
4. Run the API:
   ```
   dotnet run
   ```
5. Open `/swagger` in your browser to try every endpoint. After
   logging in, click the padlock icon and paste `Bearer <your-token>`
   to test any endpoints that require authentication later.

## Notes for beginners

- **BCrypt** (`PasswordHelper.cs`) is the real, production-grade way to
  hash passwords — unlike a plain SHA256 hash, it automatically adds
  random "salt" so identical passwords never produce identical hashes.
- **JWT** (`TokenGenerator.cs`) means the server doesn't need to
  remember who's logged in — the token itself proves identity until
  it expires (2 hours here).
- Read the files in this order to follow the logic top-to-bottom:
  `UserController.cs` → `UserBL.cs` → `UserRL.cs` → `FundooContext.cs`.
