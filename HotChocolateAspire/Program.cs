using HotChocolate.Fusion.Aspire;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var authors = builder.AddProject<AuthorsService>("authors", "aspire")
	.WithHttpEndpoint()
	.WithHttpsEndpoint();

var books = builder.AddProject<BooksService>("books", "aspire")
	.WithHttpEndpoint()
	.WithHttpsEndpoint();

var gateway = builder.AddFusionGateway<Gateway>("gateway")
	.WithHttpsEndpoint(port: 5200)
	.WithSubgraph(authors)
	.WithSubgraph(books);
	
builder.Build()
	.Compose()
	.Run();