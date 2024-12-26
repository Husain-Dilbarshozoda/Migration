namespace Domain.Models;

public class Books
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int PublishedYear { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }
    public int AuthorId { get; set; }
}