# 📝 TaskFlow API

## 📌 Açıklama

TaskFlow, kullanıcı bazlı görev yönetimi sağlayan bir .NET Web API projesidir.  
Projede kimlik doğrulama (JWT), yetkilendirme (Role-based), kullanıcıya özel erişim ve CRUD işlemleri yer almaktadır.

---

## 🔐 Özellikler

- Kullanıcı Kaydı (Register) ve Girişi (Login)
- JWT ile Kimlik Doğrulama
- Role Bazlı Yetkilendirme (`Admin`, `User`)
- Kullanıcıya özel görev işlemleri (`Create`, `Read`, `Update`, `Delete`)
- Admin paneli: tüm kullanıcıların görevlerini listeleme
- DTO kullanımı ve AutoMapper
- Swagger UI ile test desteği

---

## 🛠️ Teknolojiler

- .NET 8 Web API
- Entity Framework Core
- SQL Server
- AutoMapper
- Swagger
- JWT Authentication

---

## 🔐 JWT Token

Giriş sonrası access token döner.  
Token, Swagger’daki “Authorize” kısmına `"Bearer eyJ..."` şeklinde girilerek kullanılabilir.

---

## 📂 Proje Yapısı

- `Entities` – Entity sınıfları (User, Gorev)
- `DTOs` – Veri transfer nesneleri
- `Services` – Business logic
- `Repositories` – DB işlemleri
- `Controllers` – API endpoint’leri

---

## ⚙️ İlk Kurulum

1. Projeyi klonla:

   git clone https://github.com/FurkanEmreSaygin/TaskFlow-API.git
   cd TaskFlow-API

2. Appsettings.json içinde JWT anahtarı ve veritabanı bağlantı cümlesi ekle

   "Jwt": {
   "Key": "mySuperSecretKey123!",
   "Issuer": "TaskFlowAPI",
   "Audience": "TaskFlowUsers",
   "ExpirationMinutes": 60
   },
   "ConnectionStrings": {
   "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TaskFlowDb;Trusted_Connection=True;"
   }

3. NuGet paketlerini yükle

   dotnet restore

4. Veritabanını oluştur

   dotnet ef database update

5. Uygulamayı başlat

   dotnet run

## 🔐 JWT Kullanımı

Kullanıcı /api/auth/login ile giriş yapar ve JWT token alır.
Bu token, Swagger arayüzünde Authorize kısmına şu formatla girilmelidir:

"eyJhbGciOi..."

## 🛡️ Notlar

appsettings.json içindeki Jwt:Key ve DefaultConnection bilgileri güvenlik nedeniyle örnek bırakılmıştır.
Her geliştirici kendi veritabanı bağlantısını ve token key’ini sağlamalıdır.

## 👤 Geliştirici

Furkan Emre Saygın
