namespace BookService.Types;

public record Book([property: GraphQLName("id")] Guid ID, string Title, Author Author)
{
    public Book() : this(Guid.Empty, null, null) { }

}
