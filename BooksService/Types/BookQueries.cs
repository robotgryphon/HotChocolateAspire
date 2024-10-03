using AuthorService;
using BookService.DataLoaders;
using GreenDonut.Projections;
using HotChocolate.Execution.Processing;
using HotChocolate.Fusion.SourceSchema.Types;
using System.Collections.Immutable;

namespace BookService.Types;

[QueryType]
public static class BookQueries
{
    [Internal, Lookup]
    public static Author GetAuthor([Is("id")] string id) => new(id);

    [Lookup]
    [GraphQLName("book")]
    public static IReadOnlyCollection<Book> GetBooksByTitle([Is("id")] Guid id) => FakeBooks.BooksByID.Values
        .Where((book) => book.ID == id)
        .ToImmutableArray();

    [Lookup]
    [GraphQLName("booksByTitle")]
    public static IReadOnlyCollection<Book> GetBooksByTitle([Is("title")] string title) => FakeBooks.BooksByID.Values
        .Where(b => b.Title.Equals(title, StringComparison.InvariantCultureIgnoreCase))
        .ToImmutableArray();

    [Lookup]
    [GraphQLName("booksByAuthorID")]
    public static async Task<IReadOnlyCollection<Book>?> GetBooksByAuthor([Is("author { id }")] string authorID,
        BooksByAuthorDataLoader dl) => await dl.LoadAsync(authorID);
}
