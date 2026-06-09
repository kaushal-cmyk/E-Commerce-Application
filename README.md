# E-Commerce Application

A modular E-Commerce backend application built with ASP.NET Core to explore advanced software architecture patterns and enterprise application design principles.

## Goals

This project was created to practice and experiment with:

* Clean Architecture
* Domain-Driven Design (DDD)
* Repository Pattern
* Unit of Work Pattern
* JWT Authentication
* Generic Repositories
* Result Pattern
* Value Objects
* Auditing & Soft Delete
* Layered Architecture
* Dependency Injection

---

# Architecture

The solution follows a layered Clean Architecture structure:

```text
Presentation  ─────┐
                   ↓
Infrastructure ─→ Application ─→ Domain
```

## Project Structure

```text
Core
├── Application
├── Domain
└── Shared

Infrastructure
├── Persistence
└── Integration

Presentation
├── Web.Api
└── Web.App
```

---

# Layers

## Domain Layer

Contains:

* Entities
* Aggregate Roots
* Value Objects
* Domain Errors
* Result Pattern
* Business Rules

The domain layer contains no infrastructure or framework dependencies.

---

## Application Layer

Contains:

* Service Abstractions
* DTOs
* Mapping Configurations
* Repository Contracts
* Application Logic

This layer coordinates use cases and depends only on the Domain layer.

---

## Infrastructure Layer

Contains:

* EF Core
* Repository Implementations
* JWT Authentication
* Password Hashing
* Database Context
* Entity Configurations
* Migrations

This layer handles all external technical concerns.

---

## Presentation Layer

Contains:

* ASP.NET Core API
* MVC Application
* Controllers
* Dependency Injection
* Application Startup Configuration

---

# Patterns Used

## Repository Pattern

Abstracts database operations from business logic.

## Unit of Work

Ensures transactional consistency across repositories.

## Result Pattern

Used to return explicit success/failure responses instead of throwing exceptions for expected application flow.

## Value Objects

Used for immutable domain concepts.

## Aggregate Roots

Used to enforce domain consistency boundaries.

---

# Auditing System

The project contains reusable audited base entities:

| Type                             | Description                             |
| -------------------------------- | --------------------------------------- |
| `Entity<TKey>`                   | Base entity with Id                     |
| `AuditedEntity<TKey>`            | Adds Created information                |
| `FullAuditedEntity<TKey>`        | Adds Created, Updated, Deleted tracking |
| `AggregateRoot<TKey>`            | Aggregate root behavior                 |
| `AuditedAggregateRoot<TKey>`     | Aggregate root with auditing            |
| `FullAuditedAggregateRoot<TKey>` | Full auditing + aggregate behavior      |

Additional interfaces/features:

* Soft Delete
* Metadata Support
* Tags
* Value Object Identification

---

# Authentication

Authentication is implemented using:

* JWT Access Tokens
* Refresh Tokens
* Password Hashing

---

# Technologies

* ASP.NET Core
* Entity Framework Core
* SQL Server
* JWT Authentication
* AutoMapper
* Dependency Injection
* LINQ

---

# ER Diagram

![ER Diagram](Docs/er-diagram.gif)

---

# Running the Project

## Clone Repository

```bash
git clone <repository-url>
```

## Apply Migrations

```bash
dotnet ef database update
```

## Run API

```bash
dotnet run --project Presentation/Web/Api/ECommerce.Presentation.Web.Api
```

---

# Future Improvements 

CQRS can be implemented 


---

# Learning Purpose

This project is primarily focused on learning enterprise-level .NET architecture and best practices rather than building a production-ready e-commerce platform.
