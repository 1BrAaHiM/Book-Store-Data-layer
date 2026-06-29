using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data;

public static class Seeder
{
    public static void Seed(BookStoreContext context)
    {
        if (context.Books.Any())
            return;

        var fiction = new Category { Name = "Fiction" };
        var science = new Category { Name = "Science" };
        var history = new Category { Name = "History" };
        var tech = new Category { Name = "Technology" };
        var philosophy = new Category { Name = "Philosophy" };
        var selfHelp = new Category { Name = "Self-Help" };

        context.Categories.AddRange(fiction, science, history, tech, philosophy, selfHelp);

        var orwell = new Author { Name = "George Orwell" };
        var hawking = new Author { Name = "Stephen Hawking" };
        var yuval = new Author { Name = "Yuval Noah Harari" };
        var martin = new Author { Name = "Robert C. Martin" };
        var nietzsche = new Author { Name = "Friedrich Nietzsche" };
        var carnegie = new Author { Name = "Dale Carnegie" };

        context.Authors.AddRange(orwell, hawking, yuval, martin, nietzsche, carnegie);

        var books = new List<Book>
        {
            new Book { Title = "1984", Price = 12.99m, Category = fiction, Author = orwell },
            new Book { Title = "Animal Farm", Price = 9.99m, Category = fiction, Author = orwell },
            new Book { Title = "A Brief History of Time", Price = 14.99m, Category = science, Author = hawking },
            new Book { Title = "The Universe in a Nutshell", Price = 19.99m, Category = science, Author = hawking },
            new Book { Title = "Sapiens", Price = 17.99m, Category = history, Author = yuval },
            new Book { Title = "Homo Deus", Price = 16.99m, Category = history, Author = yuval },
            new Book { Title = "Clean Code", Price = 34.99m, Category = tech, Author = martin },
            new Book { Title = "The Clean Coder", Price = 29.99m, Category = tech, Author = martin },
            new Book { Title = "Clean Architecture", Price = 39.99m, Category = tech, Author = martin },
            new Book { Title = "Thus Spoke Zarathustra", Price = 11.99m, Category = philosophy, Author = nietzsche },
            new Book { Title = "Beyond Good and Evil", Price = 10.99m, Category = philosophy, Author = nietzsche },
            new Book { Title = "How to Win Friends", Price = 13.99m, Category = selfHelp, Author = carnegie },
        };

        context.Books.AddRange(books);

        var customers = new List<Customer>
        {
            new Customer { Name = "Alice Johnson", Email = "alice@example.com" },
            new Customer { Name = "Bob Smith", Email = "bob@example.com" },
            new Customer { Name = "Carol White", Email = "carol@example.com" },
            new Customer { Name = "David Brown", Email = "david@example.com" },
            new Customer { Name = "Eve Davis", Email = "eve@example.com" },
            new Customer { Name = "Frank Wilson", Email = "frank@example.com" },
        };

        context.Customers.AddRange(customers);
        context.SaveChanges();

        var purchases = new List<Purchase>
        {
            new Purchase { CustomerId = customers[0].Id, BookId = books[0].Id, PriceAtPurchase = books[0].Price, Date = new DateTime(2024, 1, 10) },
            new Purchase { CustomerId = customers[0].Id, BookId = books[2].Id, PriceAtPurchase = books[2].Price, Date = new DateTime(2024, 2, 14) },
            new Purchase { CustomerId = customers[0].Id, BookId = books[4].Id, PriceAtPurchase = books[4].Price, Date = new DateTime(2024, 2, 20) },
            new Purchase { CustomerId = customers[1].Id, BookId = books[0].Id, PriceAtPurchase = books[0].Price, Date = new DateTime(2024, 3, 5) },
            new Purchase { CustomerId = customers[1].Id, BookId = books[6].Id, PriceAtPurchase = books[6].Price, Date = new DateTime(2024, 3, 18) },
            new Purchase { CustomerId = customers[2].Id, BookId = books[0].Id, PriceAtPurchase = books[0].Price, Date = new DateTime(2024, 4, 2) },
            new Purchase { CustomerId = customers[2].Id, BookId = books[7].Id, PriceAtPurchase = books[7].Price, Date = new DateTime(2024, 4, 15) },
            new Purchase { CustomerId = customers[2].Id, BookId = books[8].Id, PriceAtPurchase = books[8].Price, Date = new DateTime(2024, 4, 22) },
            new Purchase { CustomerId = customers[3].Id, BookId = books[4].Id, PriceAtPurchase = books[4].Price, Date = new DateTime(2024, 5, 8) },
            new Purchase { CustomerId = customers[3].Id, BookId = books[9].Id, PriceAtPurchase = books[9].Price, Date = new DateTime(2024, 5, 19) },
            new Purchase { CustomerId = customers[4].Id, BookId = books[11].Id, PriceAtPurchase = books[11].Price, Date = new DateTime(2024, 6, 3) },
        };

        context.Purchases.AddRange(purchases);
        context.SaveChanges();
    }
}
