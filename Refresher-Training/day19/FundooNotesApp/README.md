# Fundoo Notes App - Microservices Edition

**Day 19 milestone: the single monolith API has been split into two
independent microservices** - a User Service (registration, login,
password reset, JWT issuing) and a Notes Service (notes, tags,
reminders). Each one is a separately runnable ASP.NET Core app, with
its own database, its own port, and its own Swagger page.

## Solution layout

```
FundooNotesApp/
├── FundooNotesApp.slnx
│
├── FundooNotesApp.UserService.API/       <- runs on http://localhost:5000
│   ├── Controllers/UserController.cs
│   ├── Program.cs                          <- ISSUES JWT tokens
│   └── appsettings.json                    <- owns "FundooUserServiceDb"
│
├── FundooNotesApp.NotesService.API/      <- runs on http://localhost:5100
│   ├── Controllers/
│   │   ├── NoteController.cs
│   │   ├── TagController.cs
│   │   └── ReminderController.cs
│   ├── Program.cs                          <- only VALIDATES JWT tokens
│   └── appsettings.json                    <- owns "FundooNotesServiceDb"
│
├── FundooNotesApp.BusinessLayer/         <- "BL" = business rules (shared library)
│   ├── Interfaces/ + Services/  (UserBL, NoteBL, TagBL, ReminderBL)
│   └── Helpers/ (PasswordHelper, TokenGenerator)
│
├── FundooNotesApp.ModelLayer/            <- pure data shapes, no logic (shared library)
│   ├── Entities/  (UserEntity, NoteEntity, TagEntity, NoteTagEntity, ReminderEntity)
│   ├── Models/, DTOs/, Exceptions/
│
├── FundooNotesApp.RepositoryLayer/       <- "RL" = database access only (shared library)
│   ├── Context/
│   │   ├── UserDbContext.cs                <- ONLY the Users table
│   │   └── NotesDbContext.cs               <- Notes/Tags/NoteTags/Reminders tables
│   ├── Interfaces/ + Services/  (UserRL, NoteRL, TagRL, ReminderRL)
│
└── FundooNotesApp.Tests/                 <- unit tests (unaffected by the split)
```

**Why does BusinessLayer/ModelLayer/RepositoryLayer stay as ONE shared
library instead of splitting into two as well?** Day 19 says "*begin*
decomposing" - splitting the two API hosts and their databases apart
is the big architectural step (network boundary + data ownership).
Fully separating the class libraries too (so the two services can't
even accidentally share code) is a natural "part 2" of this refactor.

## Why two separate databases?

This is one of the core rules of microservices: **a service should
never reach directly into another service's tables.** Before this
change, one `FundooContext` held Users AND Notes AND Tags AND
Reminders together - any code, anywhere, could join across them. Now:

- `UserDbContext` → only knows about `Users`
- `NotesDbContext` → only knows about `Notes`, `Tags`, `NoteTags`, `Reminders`

Notice `NoteEntity.UserId` is still just a plain `int` - the Notes
Service records WHO owns a note, but it can never load "that user's
full profile" itself, because that row doesn't even live in its
database. If it ever needed that data, it would have to ask the User
Service over the network (a real service-to-service HTTP call) -
we haven't needed that yet since nothing here requires it.

## How the two services trust each other's logins (JWT, no network call)

```
 User Service                          Notes Service
 (issues tokens)                       (validates tokens)
┌──────────────────┐                  ┌──────────────────┐
│ POST /login       │                  │ [Authorize]       │
│  -> TokenGenerator│   same secret    │  reads the token, │
│     signs a JWT   │◄────key─────────►│  checks the       │
│     with the      │   in both        │  signature - no   │
│     shared secret │   appsettings    │  API call needed  │
└──────────────────┘                  └──────────────────┘
```

Both services read `JwtSettings:SecretKey` from their own
`appsettings.json` - **these two values must be IDENTICAL** or the
Notes Service will reject every token as invalid. This is what lets
two completely independent applications trust the same login without
ever talking to each other for every single request - only the secret
needs to match.

## Why 4+ separate PROJECTS instead of folders?

Each layer is its own `.csproj`, and project REFERENCES enforce the
direction of dependency at compile time — you physically cannot make
a mistake like calling the database straight from a Controller,
because neither API project references RepositoryLayer directly.

```
UserService.API   --references-->  BusinessLayer  --references-->  RepositoryLayer  --references-->  ModelLayer
NotesService.API   -------------->        ^                              ^
                              (BusinessLayer also references ModelLayer directly)
```

## Request flow (Register example)

```
POST http://localhost:5000/api/user/register
        |
        v
UserController.Register()          <- only handles HTTP status codes
        |
        v
IUserBL.Register()  ->  UserBL     <- checks email isn't taken, hashes password
        |
        v
IUserRL.Register()  ->  UserRL     <- saves the row via UserDbContext
        |
        v
   FundooUserServiceDb "Users" table
```

## User Service Endpoints (http://localhost:5000)

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

## Notes Service Endpoints (http://localhost:5100)

Everything below used to live in the same API as the User endpoints -
now it's a separate app on its own port. **Log in via the User
Service first**, then paste that same token into the Notes Service's
Swagger Authorize button - that one token works on both services.

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
   SQL Server / SQL Server Express.
2. **Set the SAME JWT secret in BOTH services** - open
   `FundooNotesApp.UserService.API/appsettings.json` AND
   `FundooNotesApp.NotesService.API/appsettings.json`, and set
   `JwtSettings:SecretKey` to the exact same long random string
   (32+ characters) in both files. If these don't match, the Notes
   Service will reject every token as invalid.
3. Check `ConnectionStrings` in both files match your SQL Server setup
   (default assumes `localhost\SQLEXPRESS`).
4. Create each service's database - they're independent, so this is
   two separate sets of commands:

   **User Service:**
   ```
   cd FundooNotesApp.UserService.API
   dotnet tool install --global dotnet-ef   (only needed once)
   dotnet ef migrations add InitialCreate --project ../FundooNotesApp.RepositoryLayer --startup-project . --context UserDbContext
   dotnet ef database update --project ../FundooNotesApp.RepositoryLayer --startup-project . --context UserDbContext
   ```

   **Notes Service** (open a second terminal):
   ```
   cd FundooNotesApp.NotesService.API
   dotnet ef migrations add InitialCreate --project ../FundooNotesApp.RepositoryLayer --startup-project . --context NotesDbContext
   dotnet ef database update --project ../FundooNotesApp.RepositoryLayer --startup-project . --context NotesDbContext
   ```

   The `--context` flag matters now - `RepositoryLayer` has TWO
   DbContexts in it, so EF Core needs to be told which one you mean.

5. **Run both services at once** - one terminal per service:
   ```
   # Terminal 1
   cd FundooNotesApp.UserService.API
   dotnet run
   # -> http://localhost:5000/swagger

   # Terminal 2
   cd FundooNotesApp.NotesService.API
   dotnet run
   # -> http://localhost:5100/swagger
   ```
6. In the User Service's Swagger, register + log in, and copy the
   token from the `data` field. Paste that same `Bearer <token>` into
   the Notes Service's Swagger Authorize button too - one login now
   works across both independent applications.

## Notes for beginners

- **BCrypt** (`PasswordHelper.cs`) is the real, production-grade way to
  hash passwords — unlike a plain SHA256 hash, it automatically adds
  random "salt" so identical passwords never produce identical hashes.
- **JWT** (`TokenGenerator.cs`) means the server doesn't need to
  remember who's logged in — the token itself proves identity until
  it expires (2 hours here).
- Read the files in this order to follow the logic top-to-bottom:
  `UserController.cs` → `UserBL.cs` → `UserRL.cs` → `FundooContext.cs`.
