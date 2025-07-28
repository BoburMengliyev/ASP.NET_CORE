📘 README.md — Workplace Project
markdown
Copy
Edit

# Workplace Management System

**Workplace** — bu kompaniyalar, ularning filiallari (branches), bo‘limlari (departments) va xodimlari (employees) ma’lumotlarini boshqarish uchun yaratilgan RESTful Web API. Loyiha Dapper yordamida yozilgan bo‘lib, engil va tezkor ma’lumotlar bazasi bilan ishlashni ta’minlaydi.

---

## Texnologiyalar

- ASP.NET Core 9.0 Web API
- Dapper (SQL mapping)
- PostgreSQL (ma’lumotlar bazasi)
- Npgsql (PostgreSQL .NET provider)
- C# (OOP, clean architecture)

---

## Loyiha tuzilmasi

Workplace/
│
├── Workplace.Api # API layer (controllers, program)
├── Workplace.Domain # Model layer (entities)
├── Workplace.Infrastructure # Service layer (Dapper-based CRUD)
└── Workplace.sln # Solution file

yaml
Copy
Edit

---

## Asosiy modellar

- `Company`: Kompaniya ma’lumotlari
- `Branch`: Kompaniyaga tegishli filiallar
- `Department`: Kompaniyaga tegishli bo‘limlar
- `Employee`: Xodimlar (branch, department, company bilan bog‘langan)

---

## Bog‘lanishlar (Relationships)

| Model                 | Aloqa turi  | Tavsif                     |
| --------------------- | ----------- | -------------------------- |
| Company → Branch      | One-to-Many | Kompaniyada ko‘p filiallar |
| Company → Department  | One-to-Many | Kompaniyada ko‘p bo‘limlar |
| Company → Employee    | One-to-Many | Kompaniyada ko‘p xodimlar  |
| Branch → Employee     | One-to-Many | Filialda ko‘p xodimlar     |
| Department → Employee | One-to-Many | Bo‘limda ko‘p xodimlar     |

---
