# 💇‍♀️ SalonAPI - מערכת ניהול מספרה

> **Web API מקצועי לניהול מספרה** - קביעת תורים, ניהול לקוחות, ספרים וטיפולים

[![.NET](https://img.shields.io/badge/.NET-6.0-blue)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)

---

## 📖 תוכן עניינים

- [אודות הפרויקט](#אודות-הפרויקט)
- [טכנולוגיות](#טכנולוגיות)
- [ישויות](#ישויות)
- [API Endpoints](#api-endpoints)
- [התקנה והרצה](#התקנה-והרצה)
- [שימוש ב-API](#שימוש-ב-api)
- [דוגמאות](#דוגמאות)

---

## 🎯 אודות הפרויקט

**SalonAPI** היא מערכת ניהול מספרה מקיפה המאפשרת:

✅ ניהול לקוחות  
✅ ניהול צוות הספרים  
✅ קטלוג סוגי טיפולים  
✅ קביעת תורים ומעקב אחריהם  
✅ בדיקת שעות פנויות  

---

## 🛠️ טכנולוגיות

- **ASP.NET Core Web API** - .NET 6.0+
- **C#** - שפת התכנות
- **RESTful API** - ארכיטקטורה
- **Swagger/OpenAPI** - תיעוד אינטראקטיבי
- **Entity Framework Core** (בקרוב)
- **SQL Server** (בקרוב)

---

## 📋 ישויות

### 🧑 Customer (לקוח/ה)
```csharp
- Id: int                    // מזהה ייחודי
- Name: string               // שם מלא
- Phone: string              // טלפון
- Email: string?             // אימייל (אופציונלי)
- Notes: string?             // הערות (אופציונלי)
- IsActive: bool             // סטטוס פעיל
```

### ✂️ Hairdresser (ספר/ית)
```csharp
- Id: int                    // מזהה ייחודי
- Name: string               // שם מלא
- Phone: string              // טלפון
- Specialization: string?    // התמחות (אופציונלי)
- IsActive: bool             // סטטוס פעיל
```

### 💆 TreatmentType (סוג טיפול)
```csharp
- Id: int                    // מזהה ייחודי
- Name: string               // שם הטיפול
- DurationMinutes: int       // משך הטיפול בדקות
- Price: decimal             // מחיר
```

### 📅 Appointment (תור)
```csharp
- Id: int                    // מזהה ייחודי
- CustomerId: int            // מזהה לקוח
- HairdresserId: int         // מזהה ספר
- TreatmentTypeId: int       // מזהה טיפול
- Date: DateTime             // תאריך
- Time: TimeSpan             // שעה
- Status: AppointmentStatus  // סטטוס (ממתין/מאושר/בוצע/בוטל)
- Notes: string?             // הערות (אופציונלי)
```

---

## 🔗 API Endpoints

### 👥 Customers (לקוחות)

| Method | Endpoint | תיאור |
|--------|----------|-------|
| `GET` | `/api/customers` | שליפת כל הלקוחות |
| `GET` | `/api/customers/{id}` | שליפת לקוח לפי מזהה |
| `POST` | `/api/customers` | הוספת לקוח חדש |
| `PUT` | `/api/customers/{id}` | עדכון לקוח |
| `PUT` | `/api/customers/{id}/status` | עדכון סטטוס לקוח |
| `DELETE` | `/api/customers/{id}` | מחיקת לקוח |

### ✂️ Hairdressers (ספרים)

| Method | Endpoint | תיאור |
|--------|----------|-------|
| `GET` | `/api/hairdressers` | שליפת כל הספרים |
| `GET` | `/api/hairdressers/{id}` | שליפת ספר לפי מזהה |
| `POST` | `/api/hairdressers` | הוספת ספר חדש |
| `PUT` | `/api/hairdressers/{id}` | עדכון ספר |
| `PUT` | `/api/hairdressers/{id}/status` | עדכון סטטוס ספר |

### 💆 TreatmentTypes (סוגי טיפולים)

| Method | Endpoint | תיאור |
|--------|----------|-------|
| `GET` | `/api/treatmenttypes` | שליפת כל סוגי הטיפולים |
| `GET` | `/api/treatmenttypes/{id}` | שליפת טיפול לפי מזהה |
| `POST` | `/api/treatmenttypes` | הוספת טיפול חדש |
| `PUT` | `/api/treatmenttypes/{id}` | עדכון טיפול |
| `DELETE` | `/api/treatmenttypes/{id}` | מחיקת טיפול |

### 📅 Appointments (תורים)

| Method | Endpoint | תיאור |
|--------|----------|-------|
| `GET` | `/api/appointments` | שליפת כל התורים |
| `GET` | `/api/appointments/{id}` | שליפת תור לפי מזהה |
| `POST` | `/api/appointments` | יצירת תור חדש |
| `PUT` | `/api/appointments/{id}` | עדכון תור |
| `PUT` | `/api/appointments/{id}/status` | עדכון סטטוס תור |
| `DELETE` | `/api/appointments/{id}` | מחיקת תור |
| `GET` | `/api/appointments/available` | שליפת שעות פנויות |

---

## 🚀 התקנה והרצה

### דרישות מקדימות
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download) או גבוה יותר
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (מומלץ)
- [Git](https://git-scm.com/)

### שלבי התקנה

1. **שכפול הפרויקט:**
```bash
git clone https://github.com/talya21597/SalonAPI.git
cd SalonAPI
```

2. **בנייה:**
```bash
dotnet build
```

3. **הרצה:**
```bash
dotnet run
```

4. **פתיחת Swagger:**
   - הדפדפן ייפתח אוטומטית ב: `https://localhost:7245/swagger`
   - או גש ידנית לכתובת הנ"ל

---

## 📘 שימוש ב-API

### דרך Swagger UI (מומלץ למתחילים)
1. הרץ את הפרויקט
2. פתח: `https://localhost:7245/swagger`
3. בחר Endpoint
4. לחץ `Try it out`
5. מלא פרמטרים
6. לחץ `Execute`

### דרך Postman / Thunder Client
- **Base URL:** `https://localhost:7245`
- **Headers:** `Content-Type: application/json`

---

## 💡 דוגמאות

### הוספת לקוח חדש

**Request:**
```http
POST /api/customers
Content-Type: application/json

{
  "name": "שרה כהן",
  "phone": "050-1234567",
  "email": "sarah@example.com",
  "notes": "לקוחה VIP",
  "isActive": true
}
```

**Response:** `201 Created`
```json
{
  "id": 3,
  "name": "שרה כהן",
  "phone": "050-1234567",
  "email": "sarah@example.com",
  "notes": "לקוחה VIP",
  "isActive": true
}
```

---

### יצירת תור חדש

**Request:**
```http
POST /api/appointments
Content-Type: application/json

{
  "customerId": 1,
  "hairdresserId": 2,
  "treatmentTypeId": 3,
  "date": "2025-12-01T00:00:00",
  "time": "14:00:00",
  "status": 0,
  "notes": "לקוחה רגישה לצבע"
}
```

**Response:** `201 Created`
```json
{
  "id": 5,
  "customerId": 1,
  "hairdresserId": 2,
  "treatmentTypeId": 3,
  "date": "2025-12-01T00:00:00",
  "time": "14:00:00",
  "status": 0,
  "notes": "לקוחה רגישה לצבע"
}
```

---

### בדיקת שעות פנויות

**Request:**
```http
GET /api/appointments/available?date=2025-12-01&hairdresserId=1
```

**Response:** `200 OK`
```json
[
  "09:00:00",
  "11:00:00",
  "12:00:00",
  "14:00:00",
  "15:00:00"
]
```

---

## 📊 מבנה הפרויקט
```
SalonAPI/
├── Controllers/              # API Controllers
│   ├── CustomersController.cs
│   ├── HairdressersController.cs
│   ├── TreatmentTypesController.cs
│   └── AppointmentsController.cs
├── Entities/                 # Data Models
│   ├── Customer.cs
│   ├── Hairdresser.cs
│   ├── TreatmentType.cs
│   └── Appointment.cs
├── Properties/
├── appsettings.json
├── Program.cs
└── README.md
```

---

## 🔮 תכונות עתידיות

- [ ] חיבור למסד נתונים (Entity Framework)
- [ ] Authentication & Authorization (JWT)
- [ ] Validation מתקדם
- [ ] Unit Tests
- [ ] Logging
- [ ] Pagination & Filtering
- [ ] Email Notifications
- [ ] SMS Reminders
- [ ] Analytics Dashboard

---

## 📝 רישיון

MIT License - ראה קובץ [LICENSE](LICENSE) לפרטים נוספים.

---

## 👩‍💻 מפתחת

**Talya** - [GitHub](https://github.com/talya21597)

---

## 🤝 תרומה לפרויקט

רוצה לתרום? מעולה! 
1. Fork את הפרויקט
2. צור branch חדש (`git checkout -b feature/AmazingFeature`)
3. Commit את השינויים (`git commit -m 'Add some AmazingFeature'`)
4. Push ל-branch (`git push origin feature/AmazingFeature`)
5. פתח Pull Request

---

## 📧 יצירת קשר

יש שאלות? פתח Issue או צור קשר דרך GitHub!

---

<div align="center">
  <strong>נוצר עם ❤️ למען מספרות מקצועיות</strong>
</div>
