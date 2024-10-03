using AuthorService;
using BookService.Types;
using System.Collections.Immutable;

namespace BookService.DataLoaders;

public class BooksByAuthorDataLoader(DataLoaderOptions? opts = null)
    : CacheDataLoader<string, ImmutableHashSet<Book>>(opts)

{ 
    protected override async Task<ImmutableHashSet<Book>> LoadSingleAsync(string key, CancellationToken cancellationToken)
    {
        return FakeBooks.BooksByAuthorID.GetValueOrDefault(key, [])
            .Select(bookID => FakeBooks.BooksByID[bookID])
            .ToImmutableHashSet();
    }
}
