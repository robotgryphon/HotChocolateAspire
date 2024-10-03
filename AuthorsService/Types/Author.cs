using HotChocolate.Fusion.SourceSchema.Types;

namespace AuthorService.Types;

public class Author(string id, string name)
{
    [GraphQLName("id")]
    public string ID { get; set; } = id;


    [GraphQLName("name")]
    public string Name { get; set; } = name;

    [Internal]
    [GraphQLName("books")]
    internal ICollection<Book> Books { get; init; }
}