# Employee API & Quality Assurance Platform

A .NET-based Quality Assurance project designed to demonstrate API development, database testing, API automation, SQL querying, integration testing, and UI testing.

This repository was created as a practical learning project covering several key QA and Software Engineering concepts including:

- REST API Development
- Entity Framework Core
- SQLite Database Management
- SQL Querying & Validation
- API Testing with Postman
- Integration Testing
- Unit Testing
- UI Testing
- Swagger Documentation

---

# Solution Structure

```text
QualityPlatform
│
├── EmployeeApi
│   ├── Controllers
│   ├── Models
│   ├── Services
│   ├── Data
│   ├── Migrations
│   └── employees.db
│
├── EmployeeApi.IntegrationTests
├── EmployeeTracker
├── EmployeeTracker.Tests
├── TaxCalculator
└── UITests
```

---

# Employee API

The Employee API provides a simple RESTful service for managing employee records.

## Features

- Get all employees
- Get employee by ID
- Create employee
- Update employee
- Delete employee
- Filter employees by department
- Update employee salary

---

# Technology Stack

## Backend

- ASP.NET Core 8
- C#
- Entity Framework Core

## Database

- SQLite

## Testing

- Postman
- Integration Tests
- Unit Tests
- UI Tests

## Documentation

- Swagger / OpenAPI

---

# Database

This project uses SQLite as its database provider.

## Connection String

```csharp
builder.Services.AddDbContext<EmployeeDbContext>(
    options => options.UseSqlite("Data Source=employees.db"));
```

## Database File

```text
employees.db
```

Located inside:

```text
EmployeeApi/
```

---

# Accessing the Database

The database can be viewed and managed using **DB Browser for SQLite**.

Download:

https://sqlitebrowser.org/

### Steps

1. Open DB Browser for SQLite
2. Click **Open Database**
3. Select `employees.db`
4. Open the **Browse Data** tab
5. Select the **Employees** table

---

# Employee Model

```csharp
public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Department { get; set; }

    public int Salary { get; set; }
}
```

---

# API Endpoints

## Get All Employees

```http
GET /api/employees
```

## Get Employee By ID

```http
GET /api/employees/{id}
```

Example:

```http
GET /api/employees/1
```

## Create Employee

```http
POST /api/employees
```

Request Body:

```json
{
  "name": "John",
  "department": "IT",
  "salary": 3000
}
```

## Update Employee

```http
PUT /api/employees/{id}
```

## Update Employee Salary

```http
PATCH /api/employees/{id}/salary
```

## Delete Employee

```http
DELETE /api/employees/{id}
```

## Get Employees By Department

```http
GET /api/employees/department/{department}
```

Example:

```http
GET /api/employees/department/IT
```

---

# Swagger Documentation

Run the API and navigate to:

```text
https://localhost:7228/swagger
```

Swagger provides:

- Endpoint documentation
- Request examples
- Response examples
- Interactive API testing

---

# Postman Collection

A Postman collection was created containing 10 automated requests.

## Requests Included

1. Get All Employees
2. Get Employee By ID
3. Create Employee
4. Non-existing Employee
5. Invalid Employee
6. Swagger Health Check
7. Employees Response Time Validation
8. Employee Header Validation
9. Employee Schema Validation
10. Employees Count Validation

## Automated Validations

Each request contains automated tests validating:

- Status Code
- Response Headers
- Response Body
- JSON Schema
- Response Time

Example:

```javascript
pm.test("Status code is 200", function () {
    pm.response.to.have.status(200);
});
```

---

# SQL Exercises

The project includes SQL exercises demonstrating multiple database concepts.

## Fundamentals

Extracting and filtering data:

```sql
SELECT *
FROM Employees
WHERE Salary > 2500;
```

## Aggregation & Grouping

Summarising employee salaries by department:

```sql
SELECT Department,
       AVG(Salary) AS AverageSalary
FROM Employees
GROUP BY Department;
```

## Joins & Relationships

Combining data from multiple tables:

```sql
SELECT
    e.Name,
    e.Salary,
    d.DepartmentName
FROM Employees e
INNER JOIN Departments d
ON e.Department = d.DepartmentName;
```

## CTE Example

Using Common Table Expressions:

```sql
WITH EmployeeRanking AS
(
    SELECT
        Name,
        Salary,
        RANK() OVER (ORDER BY Salary DESC) AS Ranking
    FROM Employees
)
SELECT *
FROM EmployeeRanking;
```

## Window Functions

Ranking employees by salary:

```sql
SELECT
    Name,
    Salary,
    RANK() OVER (ORDER BY Salary DESC) AS SalaryRank
FROM Employees;
```

## Transaction Management

Demonstrating rollback functionality:

```sql
BEGIN TRANSACTION;

UPDATE Employees
SET Salary = Salary + 500;

ROLLBACK;
```

This verifies that changes can be safely reverted.

---

# Testing Projects

## EmployeeApi.IntegrationTests

Integration tests validating API behaviour against the actual application and database.

Examples:

- Employee creation
- Employee retrieval
- API response validation
- End-to-end testing

## EmployeeTracker.Tests

Unit tests validating business logic independently from infrastructure dependencies.

Examples:

- Validation rules
- Business calculations
- Error handling
- Service testing

## UITests

UI automation tests validating user workflows and application behaviour.

Examples:

- Navigation testing
- Form validation
- User interaction testing
- Workflow verification

## TaxCalculator

Sample application used to demonstrate testing strategies and validation techniques.

Examples:

- Tax calculations
- Boundary testing
- Positive scenarios
- Negative scenarios

---

# Testing Strategy

The solution demonstrates multiple levels of software testing.

## Unit Testing

Tests individual methods and business logic in isolation.

## Integration Testing

Tests interactions between:

- API
- Services
- Database
- Application layers

## API Testing

Tests REST endpoints through Postman.

Validation includes:

- Status codes
- Headers
- Response bodies
- Performance
- Schema validation

## Database Testing

SQL validation against SQLite database.

Validation includes:

- Data accuracy
- Aggregations
- Relationships
- Data integrity

## UI Testing

Automated verification of user-facing functionality.

---

# Running the Project

Navigate to the API project:

```bash
cd EmployeeApi
```

Restore dependencies:

```bash
dotnet restore
```

Run the API:

```bash
dotnet run
```

Swagger UI:

```text
https://localhost:5053/swagger
```

## Database

The project uses SQLite.

The database file is included in the repository:

```text
EmployeeApi/employees.db
```

If the database is deleted, it can be recreated using Entity Framework migrations:

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update
```

---

# Future Improvements

Potential future enhancements:

- OAuth 2.0 Authentication
- JWT Authentication
- SQL Server Integration
- Docker Support
- CI/CD Pipeline
- GitHub Actions
- Test Reporting Dashboard
- API Versioning

---

# Author

**Pedro Ranito**

Quality Assurance & Software Testing Practice Project

---

This project was developed as part of a hands-on learning journey covering API development, SQL, automation testing, integration testing, and quality assurance best practices.
