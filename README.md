# BlogApp

BlogApp, ASP.NET Core MVC kullanılarak geliştirilmiş basit bir blog uygulamasıdır.  
Kategoriler, gönderiler ve yorumlar yönetilebilir. Kullanıcılar kayıt olabilir, giriş yapabilir, gönderilere yorum bırakabilir.

---

## Teknolojiler ve Paketler

- .NET 8.0 (SDK ve Runtime)
- ASP.NET Core MVC
- Entity Framework Core 8.0
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.AspNetCore.Authentication.Cookies
- Bootstrap 5 (CDN üzerinden)
- Bootstrap Icons (CDN üzerinden)

---

## Kurulum ve Çalıştırma

### Gereksinimler

- .NET 8.0 SDK: https://dotnet.microsoft.com/en-us/download/dotnet/8.0
- SQL Server (veya SQL Server Express) kurulumu
- Git (isteğe bağlı)

### Adımlar

1. Projeyi klonlayın:
   ```bash
   git clone <repo_url>
   cd BlogApp
   ```

2. Bağımlılıkları yükleyin:
      ```bash
   dotnet restore
   ```

3. Veritabanını oluşturun ve güncelleyin:
     ```bash
   dotnet ef database update
   ```

4. Uygulamayı çalıştırın:
   ```bash
   dotnet run
   ```

5. Tarayıcıda 8008 portuna gidin

### Seed Veri
Projede başlangıç için 3 kategori, 2 gönderi ve her gönderiye 1'er yorum eklenmiştir.
Bunlar otomatik olarak veritabanına yüklenir.


### Proje Yapısı ve Açıklamalar

- Controllers/: MVC controller'lar
- Models/: Veri modelleri (Category, Post, Comment, User)
- Views/: Razor sayfaları
- Services/: İş mantığı servisleri
- Data/ApplicationDbContext.cs: EF Core DbContext



      

