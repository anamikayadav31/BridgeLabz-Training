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
