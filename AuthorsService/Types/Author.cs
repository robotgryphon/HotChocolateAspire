namespace AuthorsService.Types;

public class Author(string id, string name)
{
	public string ID { get; init; } = id;

	public string Name { get; init; } = name;
}