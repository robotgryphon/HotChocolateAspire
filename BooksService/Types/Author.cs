using BookService.DataLoaders;
using GreenDonut.Projections;
using HotChocolate.Execution.Processing;

namespace BookService.Types;

public class Author(string id)
{
    [GraphQLName("id")]
    public string ID { get; set; } = id;

    [GraphQLName("books")]
    public async Task<IReadOnlyCollection<Book>> Books(ISelection selection, BooksByAuthorDataLoader dl) 
        => await dl.Select(selection).LoadAsync(ID) ?? []; 
}