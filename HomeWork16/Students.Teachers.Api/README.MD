# 🎓 Students & Teachers API

ASP.NET Core Web API that manages Students and Teachers with:

- ✅ One-to-One relationship (`Student` ↔ `Passport`)
- ✅ Many-to-Many relationship (`Student` ↔ `Teacher` through `StudentTeacher`)
- ✅ PostgreSQL as database
- ✅ Dapper ORM for database operations
- ✅ Three-layer architecture: API, Domain, Infrastructure

---

## 📦 Project Structure

Students/

├── Students.API # Controllers, Program.cs, Swagger

├── Students.Application # Services, DTOs, Interfaces

├── Students.Infrastructure # Database access via Dapper

├── Students.Domain # Models/Entities

## 🛠 Technologies Used

- **ASP.NET Core 9.0+**
- **PostgreSQL**
- **Dapper**
- **Scalar**
- **AutoMapper** (optional)

## 🔗 Relationships

### 🧑‍🎓 Student ↔ Passport (One-to-One)

Each student has **exactly one** passport.

```csharp
// Student.cs
public class Student {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Passport Passport { get; set; }
}

// Passport.cs
public class Passport {
    public Guid Id { get; set; }
    public string Series { get; set; }
    public string Number { get; set; }

    public Guid StudentId { get; set; }
    public Student Student { get; set; }
}
```

```csharp
🧑‍🎓 Student ↔ 🧑‍🏫 Teacher (Many-to-Many)
// Student.cs
public List<StudentTeacher> StudentTeachers { get; set; }

// Teacher.cs
public List<StudentTeacher> StudentTeachers { get; set; }

// StudentTeacher.cs
public Guid StudentId { get; set; }
public Guid TeacherId { get; set; }
```
