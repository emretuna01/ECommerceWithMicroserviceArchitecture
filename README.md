# ECommerceWithMicroserviceArchitecture
Microservis mimarisyle oluşturulmuş, redis ve rabbitmq implemantasyonları bulunan örnek e-ticaret api uygulamasıdır.


Projenin Katmanları
-------
- ApiGateWays
  - WebApiGateway // İmplemantasyonu yapılmadı Ocelot ve Consul'la beraber çalışması sağlanacak.
- BuildingBlocks
  - EventBus //  İmplemantasyonu yapılmadı Rabbitmq ve Azure'la beraber çalışması sağlanacak.
- Services
   - LoginService
      - LoginService.Core
        - LoginService.Core.Domain  // Projedeki tüm entitler burada tutulur. 
        - LoginService.Core.Application // Projedeki tüm Interface, Dto, Mapping Configurasyonları burada  tutulur. 
      - LoginService.Infrastructure
        - LoginService.Infrastructure.Persistance // Projedeki tüm veritabanı operasyonları bu katmandan sağlanır. 
      - LoginService.Presantation
        - LoginService.Presantation.Api  //Projenin api servislerinin bulunduğu katmandır.

Diğer Mikroservis katmanlarının yapısı da aynı şekildedir.


Kullanılan Teknolojiler / Yaklaşımlar / Mimariler
 -----------------
 - Microsevice Architecture
 - Onion Architecture
 - Redis
 - RabbitMq
 - CQRS Patern
 - JWT Token
 - Code First
 - Entity Framework Core
 - Postgresql 
 - UnitOfWork Repository Patern
 - AutoMapper
 - Asp.net Core Web Api
 - Net Core 5 

Kurulum
 -----------------
 - Projede Docker desteği henüz yok bu sebeple database'de scaffolding'i yapabilmek için OrderService.Infrastructure.Persistance katmanının appsettings dosyasına 
   veritabanı connection bilgisi girilmeli. OrderService.Presantation.Api katmanı set as startup project olarak seçilmelidir. Diğer microservis katmanlarının 
   appsettings dosyalarına da veritabanı bilgisi girilmeldir.
 
 Uygulama İçi Notlar
 -----------------
 - k.adı: admin şifre:admin girerek direkt token bilgisini alabilirsiniz. Token Bilgisini swagger ekranında ```Bearer jwt_token_key``` şeklinde kaydedip request
   gönderilebilir.
   
![alt text](https://user-images.githubusercontent.com/42046428/158149426-4f947e77-f862-4441-932d-e68b1a0c587b.png)

      
