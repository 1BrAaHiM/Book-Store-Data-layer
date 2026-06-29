# BookStore — Task 3 (EF Core Data Layer)

## Prerequisites
- .NET 10 SDK
- SQL Server (local instance)
- Visual Studio or VS Code

## Connection String
Update the connection string in `Data/BookStoreContext.cs` to match your SQL Server instance:
```
Server=.\MSSQLSERVER01;Database=BookStoreDb;Trusted_Connection=True;TrustServerCertificate=True;
```

## Run Migrations
```
dotnet ef database update
```
This creates the `BookStoreDb` database with all tables and constraints.

## Run the Application
```
dotnet run
```
On first run, the application seeds the database with sample authors, categories, books, customers, and purchases automatically.

## What the Application Demonstrates
1. List all books with their category and author (single query with `Include`)
2. Top 5 best-selling books by purchase count
3. Every customer with their purchase count
4. Categories containing more than 5 books
5. Books priced above the average book price
6. Customers who have never made a purchase
7. Total revenue grouped by month
8. Case-insensitive book title search using `EF.Functions.Like`
9. Paginated books list (page number and page size)
10. Add a new book, update its price, then delete it

## Migration Files
The `Migrations/` folder contains:
- `20240101000000_InitialCreate.cs` — creates all tables with constraints
- `BookStoreContextModelSnapshot.cs` — EF Core model snapshot

## Key Design Decisions
- `PriceAtPurchase` on `Purchase` preserves the price at the time of sale even if the book price changes later.
- `OnDelete(DeleteBehavior.Restrict)` on `Book → Category` and `Book → Author` prevents orphaned records when deleting a category or author.
- `AsNoTracking()` is used on all read-only queries to skip change tracking and improve performance.
- All list queries with related data use `Include` to avoid the N+1 problem.
- Unique index on `Customer.Email` enforces no duplicate emails at the database level.
- Check constraint `CK_Book_Price` ensures no negative prices.
