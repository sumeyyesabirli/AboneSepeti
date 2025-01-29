# Abone Sepeti API Projesi

Bu proje, kullanıcı yönetimi ve abonelik işlemlerini yöneten bir .NET Core Web API projesidir.

## Proje Yapısı

Proje, Clean Architecture prensiplerine uygun olarak katmanlı bir mimari ile geliştirilmiştir:

### Katmanlar

1. **Abonesepeti.Api**
   - API endpoints
   - Swagger entegrasyonu
   - JWT authentication yapılandırması

2. **Abonesepeti.Business**
   - İş mantığı katmanı
   - Servis implementasyonları
   - Request modelleri
   - Kullanıcı ve JWT servisleri

3. **Abonesepeti.Core**
   - Temel varlıklar
   - Enum tanımlamaları
   - Response modelleri
   - Ortak bileşenler

4. **Abonesepeti.DataAccess**
   - Veritabanı işlemleri
   - Entity Framework yapılandırması
   - Repository pattern implementasyonu

5. **Abonesepeti.Entity**
   - Veritabanı varlık modelleri
   - Entity konfigürasyonları

## Özellikler

- JWT tabanlı kimlik doğrulama
- Refresh token desteği
- Kullanıcı kayıt ve giriş işlemleri
- Telefon numarası ile kullanıcı doğrulama
- Swagger UI ile API dokümantasyonu

## Teknolojiler

- .NET Core
- Entity Framework Core
- JWT Authentication
- Swagger/OpenAPI
- Clean Architecture
- Repository Pattern

## Kurulum

1. Projeyi klonlayın
2. MongoDB'yi bilgisayarınıza yükleyin ve çalıştırın
3. Veritabanı bağlantı ayarlarını `appsettings.json` dosyasında yapılandırın:
   ```json
   "MongoDbSettings": {
     "ConnectionString": "mongodb://localhost:27017",
     "DatabaseName": "AuthenticationDb",
     "UsersCollectionName": "Users"
   }
   ```
4. Projeyi çalıştırın ve Swagger UI üzerinden API'yi test edin

## API Endpoints

### Kullanıcı İşlemleri
- POST /api/auth/register - Yeni kullanıcı kaydı
- POST /api/auth/login - Kullanıcı girişi
- POST /api/auth/refresh-token - Token yenileme

## Güvenlik

- Tüm şifreler hash'lenerek saklanır
- JWT token kullanılarak güvenli iletişim sağlanır
- Refresh token mekanizması ile sürekli oturum desteği
