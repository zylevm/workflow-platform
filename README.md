# Workflow Platform

Enterprise-style платформа для управления бизнес-процессами, документами и согласованиями.

Проект разрабатывается на C# и .NET 8 как практический backend-проект с постепенным внедрением современных подходов к разработке: тестирование, базы данных, REST API, интеграции, очереди сообщений, контейнеризация и CI/CD.

## Цель проекта

Создать систему, которая позволяет моделировать реальные корпоративные процессы:

- создание и обработку документов;
- согласование документов;
- назначение задач сотрудникам;
- управление статусами;
- выполнение бизнес-процессов;
- хранение истории изменений;
- отправку уведомлений;
- интеграцию с внешними системами.

Проект развивается постепенно: каждая новая версия добавляет отдельную функциональность и новую инженерную практику.

## Технологии

### Используется сейчас

- C#
- .NET 8
- xUnit
- Git
- GitHub

### Планируется

- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- JWT Authentication
- RabbitMQ
- Redis
- Docker
- GitHub Actions
- Integration Tests
- Kubernetes
- gRPC
- CQRS
- Outbox Pattern

## Архитектура

Проект развивается по многослойной архитектуре.

На текущем этапе реализованы следующие проекты:

```text
WorkflowPlatform
│
├── src
│   ├── WorkflowPlatform.Domain
│   │   ├── Entities
│   │   └── Enums
│   │
│   └── WorkflowPlatform.Application
│       └── Documents
│           ├── Repositories
│           └── SubmitDocument
│
└── tests
    ├── WorkflowPlatform.Domain.Tests
    └── WorkflowPlatform.Application.Tests
```

В дальнейшем архитектура будет расширяться за счёт API и Infrastructure-слоёв.

### Domain Layer

`WorkflowPlatform.Domain` содержит предметную область и бизнес-правила.

В Domain реализована сущность `Document`, которая управляет собственным жизненным циклом и не зависит от Application Layer.

### Application Layer

`WorkflowPlatform.Application` содержит сценарии использования системы.

На текущем этапе реализован use case:

- `SubmitDocumentHandler` — отправка документа на согласование.

Handler отвечает за orchestration сценария, а бизнес-правила перехода состояния остаются в Domain-модели.

Для работы с документами используется абстракция:

```csharp
IDocumentRepository
```

Текущая реализация:

```csharp
InMemoryDocumentRepository
```

Таким образом, Application Layer зависит от контракта репозитория, а конкретная реализация может быть заменена без изменения `SubmitDocumentHandler`.

В проекте используется constructor injection для передачи зависимостей в Handler.

## Текущий прогресс

### Domain

- [x] Сущность `Document`
- [x] Статусы документа
- [x] Переходы между состояниями
- [x] Проверка бизнес-правил
- [x] Unit-тесты

### Application

- [x] Application Layer
- [x] Use Case `SubmitDocument`
- [x] `SubmitDocumentHandler`
- [x] Интерфейс `IDocumentRepository`
- [x] `InMemoryDocumentRepository`
- [x] Constructor Injection
- [x] Unit-тесты Application Layer

### Backend

- [ ] ASP.NET Core Web API
- [ ] PostgreSQL
- [ ] Entity Framework Core
- [ ] Аутентификация и авторизация

### Инфраструктура

- [ ] RabbitMQ
- [ ] Redis
- [ ] Docker
- [ ] CI/CD

### Продвинутые возможности

- [ ] Integration Tests
- [ ] gRPC
- [ ] CQRS
- [ ] Outbox Pattern
- [ ] Kubernetes

## Предметная область

Первая реализованная сущность — `Document`.

Документ может проходить следующий жизненный цикл:

```text
Draft
  │
  │ Submit()
  ▼
PendingApproval
  │
  ├── Approve() ──→ Approved
  │
  └── Reject()  ──→ Rejected
```

Недопустимые переходы между состояниями блокируются непосредственно в Domain-модели.

## Тестирование

Для автоматического тестирования используется `xUnit`.

### Domain Tests

Проверяются:

- начальное состояние документа;
- отправка документа на согласование;
- запрет утверждения черновика;
- утверждение документа;
- отклонение документа.

### Application Tests

Проверяется сценарий:

- получение документа через Repository;
- выполнение `SubmitDocumentHandler`;
- изменение состояния документа;
- сохранение документа через Repository.

Текущий результат:

**6 тестов — 6 пройдено, 0 ошибок.**

## Подход к разработке

Проект развивается итеративно.

Каждый этап должен:

1. Добавлять реальное бизнес-требование.
2. Реализовывать необходимую функциональность.
3. Покрываться автоматическими тестами.
4. Фиксироваться в Git.
5. Отражаться в документации проекта.

Цель — постепенно построить полноценную backend-систему, одновременно изучая C#, архитектуру, тестирование и современные инструменты разработки.