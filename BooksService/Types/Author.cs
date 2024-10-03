using BookService.DataLoaders;

namespace BookService.Types;

public class Author(string id)
{
    [GraphQLName("id")]
    public string ID { get; set; } = id;

    [GraphQLName("books")]
    public async Task<IReadOnlyCollection<Book>> Books(BooksByAuthorDataLoader dl) 
        => await dl.LoadAsync(ID) ?? []; 
}