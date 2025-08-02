# Oddiy Bank Tizimi - Web API

Bu loyiha .NET Core (ASP.NET Web API) yordamida ishlab chiqilgan oddiy bank tizimidir. Foydalanuvchilar mijozlar (customers) va ularning hisoblarini (accounts) CRUD operatsiyalari orqali boshqarishlari mumkin. Loyihada Dependency Injection, fayl yuklash, try-catch xatoliklarni boshqarish kabi zamonaviy yondashuvlar ishlatilgan.

---

## Asosiy imkoniyatlar

- **Mijozlar uchun CRUD**: Mijoz ma'lumotlarini qo‘shish, o‘qish, tahrirlash va o‘chirish
- **Hisoblar uchun CRUD**: Bank hisoblarini yaratish, o‘zgartirish, bog‘lash, o‘chirish
- **Profil rasmi yuklash**: Har bir mijoz uchun rasm faylini yuklash va saqlash
- **Dependency Injection**: Servislarni modullarga ajratish va ularni DI orqali tizimga kiritish
- **Xatoliklarni boshqarish**: Try-catch bloklar va foydalanuvchi uchun tushunarli javoblar

---

## Loyihaning tuzilishi

### BankApi/

#### Controllers/

- CustomerController.cs
- AccountController.cs

#### Models/

- Customer.cs
- Account.cs

#### Services/

- Interfaces/
- ICustomerService.cs
- IAccountService.cs
- CustomerService.cs
- AccountService.cs

Program.cs

- appsettings.json

- uploads/

- Yuklangan rasm fayllari saqlanadigan papka

---

## API Endpointlar

### Mijozlar (`/api/customer`)

| Metod    | Endpoint             | Tavsifi                                                         |
| -------- | -------------------- | --------------------------------------------------------------- |
| `GET`    | `/api/customer`      | Barcha mijozlarni ko‘rish                                       |
| `GET`    | `/api/customer/{id}` | ID bo‘yicha mijozni ko‘rish                                     |
| `POST`   | `/api/customer`      | Yangi mijoz qo‘shish (multipart/form-data bilan rasm yuklanadi) |
| `PUT`    | `/api/customer/{id}` | Mijoz ma’lumotlarini yangilash                                  |
| `DELETE` | `/api/customer/{id}` | Mijozni o‘chirish                                               |

### Hisoblar (`/api/account`)

| Metod    | Endpoint                             | Tavsifi                           |
| -------- | ------------------------------------ | --------------------------------- |
| `GET`    | `/api/account`                       | Barcha hisoblarni ko‘rish         |
| `GET`    | `/api/account/{id}`                  | ID bo‘yicha hisobni ko‘rish       |
| `GET`    | `/api/account/customer/{customerId}` | Muayyan mijozga tegishli hisoblar |
| `POST`   | `/api/account`                       | Yangi hisob yaratish              |
| `PUT`    | `/api/account/{id}`                  | Hisobni yangilash                 |
| `DELETE` | `/api/account/{id}`                  | Hisobni o‘chirish                 |

---

## Ishga tushirish

1. .NET SDK 6.0 yoki undan yuqori versiyani o‘rnating
2. Loyihani yuklang yoki `git clone` orqali nusxa oling
3. Terminalda quyidagilarni bajarish:

   ```bash
   dotnet restore
   dotnet build
   dotnet run

   https://localhost:5001/scalar orqali Scalar UI orqali API ni sinab ko‘ring
   ```

Profil rasmi yuklash

- POST /api/customer endpoint orqali fayl (profil rasmi) yuklash uchun multipart/form-data turida quyidagi formatda yuboring:

- Parametr nomi Tavsif

- fullName F.I.Sh

- email Mijoz email

- phoneNumber Telefon raqam

- address Manzil

- profileImage JPG/PNG rasm fayli

### Xatoliklarni boshqarish

- Kiritilgan ma’lumotlar noto‘g‘ri bo‘lsa → 400 BadRequest

- Ma’lumot topilmasa → 404 NotFound

- Server xatosi → 500 InternalServerError

### Texnologiyalar

- ASP.NET Core Web API

- Dependency Injection

- File Upload (IFormFile)

- In-Memory Service (mock)
