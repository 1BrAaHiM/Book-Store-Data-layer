namespace BookStore.Models;

public class Purchase
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal PriceAtPurchase { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}
