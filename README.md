# Banking System

A simple console-based banking system built with C# and .NET 8. This project demonstrates basic object-oriented programming concepts, repository pattern, and simple analytics for bank accounts.

## Features
- Create new bank accounts
- View all accounts
- Deposit and withdraw funds
- Basic analytics (account balance ranges, sorting)

## Concepts Used
- **Generics**: The `Repository<T>` class uses generics to provide type-safe data storage and retrieval.
- **Interfaces**: The `IRepository<T>` interface defines a contract for repository operations.
- **Delegates & Events**: The `BankAccount` class uses a delegate (`TransactionHandler`) and an event (`OnTransaction`) to notify about transactions.
- **LINQ**: Used for querying and analytics on account collections (e.g., sorting, filtering, counting).
- **Lambda Expressions**: Used in LINQ queries and repository methods for concise function definitions.
- **Exception Handling**: Input validation and error messages for user interactions.
- **Object-Oriented Principles**: Encapsulation, abstraction, and separation of concerns are demonstrated throughout the codebase.

## Project Structure
- `BankAccount.cs`: Represents a bank account
- `Repository.cs` / `IRepository.cs`: Generic repository pattern for data storage
- `BankingService.cs`: Business logic and user interaction
- `Program.cs`: Entry point and menu

## Getting Started
1. **Clone the repository**
2. **Build the project**
   - Using CLI: `dotnet build`
   - Or open in Visual Studio and build
3. **Run the application**
   - Using CLI: `dotnet run --project Banking_System/Banking_System.csproj`

## Usage
Follow the on-screen menu to create accounts, deposit, withdraw, and view analytics.

## Requirements
- .NET 8 SDK
