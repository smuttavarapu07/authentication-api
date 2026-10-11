# Authentication API

A standalone ASP.NET Core Web API that implements basic user registration and login functionality using in-memory storage. This project demonstrates authentication concepts, password hashing, request validation, and HTTP status codes without requiring a database.

## Features

- **User Registration:** Register new users with a unique username.
- **Duplicate User Validation:** Prevent registration with an existing username.
- **Password Hashing:** Hash passwords before storing them.
- **User Login:** Validate usernames and passwords.
- **Input Validation:** Handle missing username and password fields.
- **HTTP Status Codes:** Return appropriate responses for successful requests and errors.
- **In-Memory Storage:** Store registered users in a static list without a database.
- **Swagger UI:** Test registration and login endpoints interactively.

## Technologies Used

- C#
- ASP.NET Core Web API
- REST APIs
- Swagger / OpenAPI
- In-memory collections

## API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| POST | `/api/auth/register` | Register a new user |
| POST | `/api/auth/login` | Validate user credentials |

## HTTP Status Codes

| Status Code | Meaning |
|---|---|
| `200 OK` | Registration or login successful |
| `400 Bad Request` | Missing fields or username already exists |
| `401 Unauthorized` | Invalid login credentials |

## How to Run

1. Clone or download this repository.
2. Open the project folder in Visual Studio Code.
3. Open a terminal in the project directory.
4. Run `dotnet restore`.
5. Run `dotnet run`.
6. Open the Swagger URL shown in the terminal, followed by `/swagger`.
7. Test the registration and login endpoints.

## Storage

User data is stored in an in-memory list. No database connection is required. Registered users are lost when the application restarts.

## Learning Outcomes

- Understanding authentication concepts.
- Creating REST API endpoints using ASP.NET Core.
- Validating user input and credentials.
- Learning password hashing and verification.
- Handling HTTP response status codes.
- Testing APIs using Swagger.

## Future Improvements

- Integrate a database for persistent user storage.
- Implement JWT-based authentication.
- Add role-based authorization.
- Improve validation and security controls.

## Author

**Sravika Muttavarapu**

GitHub: [@smuttavarapu07](https://github.com/smuttavarapu07)
