var builder = DistributedApplication.CreateBuilder(args);

_ = builder.AddProject<Projects.YANLib_HttpApi_Host>("yanlibapi");

builder.Build().Run();
