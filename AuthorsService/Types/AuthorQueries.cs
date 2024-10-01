using HotChocolate.Fusion.SourceSchema.Types;
using HotChocolate.Types;

namespace AuthorsService.Types;

[QueryType]
public static class AuthorQueries
{
	
	private static readonly Dictionary<string, Author> Authors = new()
	{
		{ "00001", new Author("00001", "Stephen King") },
		{ "00002", new Author("00002", "JK Rowling") },
		{ "00003", new Author("00003", "George RR Martin") },
		{ "00004", new Author("00004", "Danielle Steele") },
		{ "00005", new Author("00005", "Eiichiro Oda") },
	};
	
	[Lookup]
	public static Author? GetAuthor([Is("author { id }")] string id) => Authors.GetValueOrDefault(id);
}