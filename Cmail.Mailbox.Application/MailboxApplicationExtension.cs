using Cgmail.Common.Extensions;
using Cgmail.Common.Middlewares;
using Cmail.Mailbox.Application.Services.Mails;
using Cmail.Mailbox.Application.Services.Master;
using Cmail.Mailbox.Dmain.Data;
using Cmail.Mailbox.Dmain.Repositoy.Mails;
using Cmail.Mailbox.Dmain.Repositoy.Master;
using Microsoft.Extensions.DependencyInjection;

namespace Cmail.Mailbox.Application;

public static class MailboxApplicationExtension
{
    public static IServiceCollection AddMailboxApplicationExtension(this IServiceCollection services,
       string connectionString,
       string assemblyName)
    {
        services.CustomAddDBContext<MailboxContext>(connectionString, assemblyName);

        services.AddScoped<IHmacService, HmacService>();

        services.AddScoped<IEmailRepositoy, EmailRepositoy>();

        services.AddScoped<IFolderRepository, FolderRepository>();

        services.AddScoped<IEmailService, EmailService>();

        services.AddScoped<IFolderService, FolderService>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
