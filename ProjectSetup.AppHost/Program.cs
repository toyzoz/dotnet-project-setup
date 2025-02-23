var builder = DistributedApplication.CreateBuilder(args);

IResourceBuilder<PostgresServerResource> postgres = builder.AddPostgres("web.api.db");
builder.AddProject<Projects.Web_Api>("web-api")
    .WithReference(postgres)
    .WaitFor(postgres);


builder.AddProject<Projects.Web2_Api>("web2-api");

builder.Build().Run();