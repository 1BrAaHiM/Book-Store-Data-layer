using BookStore.Data;
using BookStore.Queries;
using Microsoft.EntityFrameworkCore;

using var context = new BookStoreContext();
context.Database.Migrate();
Seeder.Seed(context);

BookStoreQueries.ListAllBooks(context);
BookStoreQueries.Top5BestSellingBooks(context);
BookStoreQueries.CustomersWithPurchaseCount(context);
BookStoreQueries.CategoriesWithMoreThan5Books(context);
BookStoreQueries.BooksAboveAveragePrice(context);
BookStoreQueries.CustomersWithNoPurchases(context);
BookStoreQueries.TotalRevenueByMonth(context);
BookStoreQueries.SearchBooksByKeyword(context, "clean");
BookStoreQueries.GetBooksPaged(context, pageNumber: 1, pageSize: 5);
BookStoreQueries.AddUpdateDeleteBook(context);
