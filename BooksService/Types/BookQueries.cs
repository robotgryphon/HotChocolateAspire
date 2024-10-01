namespace BooksService.Types;

[QueryType]
public static class BookQueries
{
	public static Book GetBook()
		=> new Book("C# in depth.", new Author("00001"));
}