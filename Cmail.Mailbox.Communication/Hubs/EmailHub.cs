using Cgmail.Common.Middlewares;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace Cmail.Mailbox.Communication.Hubs;

public class EmailHub : Hub
{
    private readonly IHmacService _hmacService;
    private readonly IConfiguration _configuration;


    public EmailHub(IHmacService hmacService, IConfiguration configuration)
    {
        _hmacService = hmacService;
        _configuration = configuration;
    }


    public async Task NotifyEmailSent(string message)
    {
        string key = _configuration.GetValue<string>("SecretKey") ?? string.Empty;

        var secureResponse = _hmacService.EncryptData(message, key);

        var encryptedPayload = $"{secureResponse.EncryptedData}(/=/){secureResponse.Iv}(/=/){secureResponse.Hmac}";

        await Clients.All.SendAsync("ReceiveEmailNotification", encryptedPayload);
    }
}
