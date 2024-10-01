namespace BooksService.Types;

public class Book(string Title, Author Author)
{
	public string Title { get; init; } = Title;
	public Author Author { get; init; } = Author;
}