# API для загрузки измерений и расчета метрик


## Локальный запуск:
1. Создать `options.json` файлы в проектах `Store.PostgreSQL` и `Api.WebApi` в формате:
```
{
  "ConnectionString": "Host=HOST;Port=PORT;Database=DATABASE;Username=USERNAME;Password=PASSWORD"
}
```
2. Принять миграции
```
dotnet ef database update --project Store.PostgreSQL
```

`http://localhost:5165/swagger/` - Свагер

## Создание миграций:
```
dotnet ef migrations add <название_миграции> --project Store.PostgreSQL
```
