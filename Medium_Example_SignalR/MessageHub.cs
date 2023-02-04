using Medium_Example_SignalR_Shared;
using Microsoft.AspNetCore.SignalR;

namespace Medium_Example_SignalR;

public class MessageHub: Hub    
{
    public async Task SendMessage(NotifyMessage notifyMessage)
    {
        await Clients.All.SendAsync("ReceiveMessage", notifyMessage);
    }
}