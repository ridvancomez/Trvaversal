# Traversal Tur Sitesi

## Proje Hakkında  
Bu proje portföy amaçlı geliştirilmiş bir dinamik web sitesidir. Müşterilere turlar listelenir ve müşteriler bu turlara kayıt olabilir. Müşterilerin yaptığı tüm işlemler veritabanında kayıt altında tutulur. Ayrıca, sistemde **Member** ve **Admin** olmak üzere iki farklı kullanıcı rolü bulunmaktadır. **Member** kullanıcıları turlara katılabilirken, **Admin** kullanıcıları web sitesinin tasarımını yapabilir, yeni turlar oluşturabilir ve kullanıcılar üzerinde rol atamaları gerçekleştirebilir.

## Özellikler  
- Kullanıcıların turları listeleyip kayıt olabilmesi  
- Admin kullanıcıları yeni turlar oluşturabilir ve mevcut turları düzenleyebilir  
- Admin paneli üzerinden kullanıcı rol yönetimi yapılabilir  
- Kullanıcı ve Admin işlemleri veritabanına kaydedilir  
- Dinamik ve kullanıcı dostu bir arayüz  
- **Member** ve **Admin** rolleriyle farklı yetkilendirme seviyeleri

## Kullanılan Teknolojiler  
- **Backend**: ASP.NET Core, N-tier mimarisi, Repository Pattern, Dependency Injection (DI)  
- **Veritabanı**: MSSQL, Code First yaklaşımı ile veritabanı tasarımı  
- **Frontend**: Bootstrap, Ajax  
- **Veritabanı Yönetimi**: Migration kullanılarak veritabanı işlemleri yapılmıştır

## Roller ve Yetkilendirme  
- **Member**: Kullanıcılar turlara kaydolabilir ve kendilerine ait bilgilerle giriş yapabilir.  
- **Admin**: Admin kullanıcıları, yeni turlar oluşturabilir, mevcut turları düzenleyebilir ve kullanıcılara roller atayabilir. Web sitesinin yönetiminden sorumludurlar.

## Ekran Görüntüleri
### Ana Sayfa Arayüzü
![Ana Sayfa](ScreenShots/UI1.png)

### Ana Sayfa Turlar Listesi
![Ana Sayfa Turlar](ScreenShots/UI2.png)

### Login Ekranı
![Login](ScreenShots/Login.png)

### Register Ekranı
![Register](ScreenShots/Register.png)

### Member Dashboard
![Member Dashboard](ScreenShots/MemberDashboard.png)

### Member Rezervasyon Sayfası
![Member Rezervasyon](ScreenShots/MemberReservation.png)

### Admin Dashboard
![Admin Dashboard](ScreenShots/AdminDashboard.png)

### Admin Rota Sayfası
![Admin Rota](ScreenShots/Destination.png)

### Admin Rezervasyon Sayfası
![Admin Rezervasyon](ScreenShots/AdminReservation.png)

### Admin Rol Sayfası
![Admin Rol](ScreenShots/AdminRole.png)

### Admin Rol Atama Sayfası
![Admin Rol Atama](ScreenShots/AdminAssignRole.png)

## Kurulum ve Çalıştırma  
1. Projeyi [GitHub Repository] üzerinden indirip bilgisayarınıza çekin.  
2. Veritabanı için migration işlemini gerçekleştirin:  
   ```bash
   dotnet ef database update

   
