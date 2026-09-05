# HallApp API

API для управління бронюванням залів.

## Технології
- .NET 10, EF Core, SQL Server
- AutoMapper, Swagger

## Запуск
1. `dotnet restore`
2. `dotnet ef database update --project HallApp.Infrastructure --startup-project HallApp.Api`
3. `dotnet run --project HallApp.Api`
4. Swagger: `https://localhost:7221/swagger`

## Структура проєкту
- `HallApp.Entities` — сутності бази даних
- `HallApp.BusinessLogic` — сервіси, DTO, бізнес-логіка
- `HallApp.Infrastructure` — репозиторії, EF Core
- `HallApp.Api` — контролери, конфігурація застосунку

Детальний опис бізнес-задачі та технічних рішень — у [DOCUMENTATION.md](./DOCUMENTATION.md)
