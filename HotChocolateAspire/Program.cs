using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var authors = builder.AddProject<AuthorsService>("authors");

var books = builder.AddProject<BooksService>("books");

var gateway = builder.AddFusionGateway<Gateway>("gateway")
	.WithSubgraph(authors)
	.WithSubgraph(books);
	
builder.Build()
	.Compose()
	.Run();