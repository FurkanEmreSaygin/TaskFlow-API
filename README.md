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

## 🧪 Swagger Test

1. `/api/auth/register` ile kullanıcı kaydı
2. `/api/auth/login` ile token al
3. Token’ı `Authorize` kısmına gir
4. `/api/gorev` işlemlerini test et

---

## 👤 Geliştirici

Furkan Emre Saygın
