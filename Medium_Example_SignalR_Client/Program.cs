// See https://aka.ms/new-console-template for more information

using Medium_Example_SignalR_Shared;
using Microsoft.AspNetCore.SignalR.Client;

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5038/messagehub")
    .Build();

try
{
    await connection.StartAsync();
    Console.WriteLine("Connected to SignalR Hub");
    
    connection.On<NotifyMessage>("ReceiveMessage", (message) =>
    {
        Console.WriteLine($"{message.Username}: {message.Message}");
    });
    
    var notifyMessage = new NotifyMessage
    {
        Username = "John Doe"
    };
    while (true)
    {
        Console.WriteLine("Enter a message to send to the server");
        var message = Console.ReadLine();
        notifyMessage.Message = message;
        await connection.InvokeAsync("SendMessage", notifyMessage);
        Console.WriteLine("Message sent");
        Console.ReadLine();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}