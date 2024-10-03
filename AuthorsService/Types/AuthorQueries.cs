using HotChocolate.Fusion.SourceSchema.Types;

namespace AuthorService.Types;

[QueryType]
public static class AuthorQueries
{
    [Lookup]
    [GraphQLName("author")]
    public static Author? GetAuthor([Is("id")] string id) => FakeAuthors.AuthorsByID.GetValueOrDefault(id);

    [GraphQLName("authors")]
    public static IQueryable<Author> AllAuthors() => FakeAuthors.AuthorsByID.Values.AsQueryable();

    [Lookup, Internal]
    public static Book GetBookById([Is("id")] Guid id) => new(id);
}
