using System.Collections.Concurrent;
using Microsoft.IdentityModel.Tokens;

namespace Monitoring.Hub;

using Microsoft.AspNetCore.SignalR;

public class PcInfoMonitoringHub : Hub
{
    private static Dictionary<string, string> connections = [];

    public async Task Init(string userPcId)
    {
        Console.WriteLine($"Юзер: {userPcId} подключился");
        
        connections.TryAdd(userPcId, Context.ConnectionId);
        
        await Clients.All.SendAsync("UpdateStatus", userPcId, true);
        // await Clients.Caller.SendAsync("qwe", "abobaTi");
    }

    public override Task OnConnectedAsync()
    {
        Console.WriteLine("Я подключился " + Context.ConnectionId);
        Clients.Caller.SendAsync("GetUserPcId");
        return base.OnConnectedAsync();
    }
    

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        foreach (var x in connections.Where(x => x.Value == Context.ConnectionId))
        {
            connections.Remove(x.Key);
            Clients.All.SendAsync("UpdateStatus", x.Key, false);
        }
        
        Console.WriteLine("Я отключился: " + Context.ConnectionId);
        return base.OnDisconnectedAsync(exception);
    }
}