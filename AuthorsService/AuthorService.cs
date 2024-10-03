using ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddGraphQL().AddTypes();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapDefaultEndpoints();
app.MapGraphQL();

app.RunWithGraphQLCommands(args);
