using Cgmail.Common.Exceptions;
using Cgmail.Common.Extensions;
using Cgmail.Common.Middlewares;
using Cgmail.Common.Model;
using Cmail.Mailbox.Application;
using Cmail.Mailbox.Communication.Hubs;
using Cmail.Mailbox.Dmain.Data;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.CustomAddControllers();

configuration.AddEnvironmentVariables("CLONE_");

string connectionString = configuration.GetValue<string>("MailBoxConnectionString") ?? string.Empty;

string? assemblyName = Assembly.GetExecutingAssembly().GetName().Name ?? string.Empty;

builder.Services.CustomAddCors(configuration);

builder.Services.AddMailboxApplicationExtension(connectionString, assemblyName);

builder.CustomAddSeriLog(configuration, connectionString);

builder.Services.CustomAddRedisCache(configuration, "MailBox:");

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddAuthorization();

builder.Services.AddSignalR();

var app = builder.Build();

app.MigrateDatabase<MailboxContext>();

app.CustomUseSwagger();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.CustomUseForwardedHeaders();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapHub<EmailHub>("/emailHub");

app.UseWhen(
    context => !context.Request.Path.StartsWithSegments("/emailHub"),
    appBuilder => appBuilder.UseMiddleware<EncryptionMiddleware>()
);

app.MapControllers();

app.Run();