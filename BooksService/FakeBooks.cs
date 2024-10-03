using Bogus;
using BookService.Types;
using System.Collections.Immutable;

namespace AuthorService;

public class FakeBooks
{
    public static Dictionary<Guid, Book> BooksByID = [];
    public static Dictionary<string, ImmutableHashSet<Guid>> BooksByAuthorID = [];

    static FakeBooks() {
        BuildBookAuthorMap();
    }

    private static void BuildBookAuthorMap()
    {
        var bookMaker = new Faker<Book>()
            .UseSeed(76)
            .RuleFor(b => b.ID, f => f.Random.Uuid())
            .RuleFor(b => b.Title, f => f.Lorem.Sentence());

        Dictionary<Guid, Book> bookDict = [];
        Dictionary<string, ImmutableHashSet<Guid>> bookAuthorMap = [];
        foreach(var i in Enumerable.Range(1, 5))
        {
            string authorID = i.ToString().PadLeft(5, '0');
            var author = new Author(authorID);

            var books = ImmutableHashSet.CreateBuilder<Guid>();

            foreach(var bookID in Enumerable.Range(1, 5)) {

                var randomBook = bookMaker.Generate() with
                {
                    Author = author
                };

                bookDict.Add(randomBook.ID, randomBook);
                books.Add(randomBook.ID);
            }

            bookAuthorMap.Add(authorID, books.ToImmutable());
        }

        BooksByID = bookDict;
        BooksByAuthorID = bookAuthorMap;
    }
}
