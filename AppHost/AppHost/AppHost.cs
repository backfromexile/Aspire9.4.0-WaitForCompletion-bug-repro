using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

var runner = builder.AddProject<Projects.IRunBeforeAnythingElse>("runner")
    .WithEnvironment("I_SHOULD_THROW", builder.Configuration["Runner:ThrowException"]);


var webapi = builder.AddProject<Projects.WebApi>("webapi")
    .WaitForCompletion(runner);

var yarp = builder.AddYarp("yarp");
if (builder.Configuration.GetValue("AppHost:YarpAsParent", false))
{
    webapi.WithParentRelationship(yarp);
}

builder.Build().Run();
