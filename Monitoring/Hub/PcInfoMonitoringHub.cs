using System.Collections.Concurrent;
using HardWareMonitorService.Entity.Monitoring;
using Microsoft.IdentityModel.Tokens;

namespace Monitoring.Hub;

using Microsoft.AspNetCore.SignalR;

public class PcInfoMonitoringHub : Hub
{
    private static Dictionary<string, string> connections = [];

    public async Task GetOnlineUser()
    {
        foreach (var x in connections.Keys.ToList())
        {
            Console.WriteLine(x);
        }
        await Clients.Caller.SendAsync("UserOnline",connections.Keys.ToList());
    }
    
    public async Task StartMonitoring(string userPcId)
    {
        Console.WriteLine("Мониторинг старт");
        var connectionId = connections[userPcId];
        await Clients.Client(connectionId).SendAsync("GetUserRTInfo");
    }

    public async Task StopMonitoring(string userPcId)
    {
        var connectionId = connections[userPcId];
        await Clients.Client(connectionId).SendAsync("Stop");
    }
    
    public async Task Monitoring(PcMonitoringInfo pcMonitoringInfo)
    {
        Console.WriteLine("Мониторинг пришёл");
        await Clients.All.SendAsync("ReceiveMonitoringInfo", pcMonitoringInfo);
    }
    
    public async Task Init(string userPcId)
    {
        Console.WriteLine($"Юзер: {userPcId} подключился");
        
        connections.TryAdd(userPcId, Context.ConnectionId);
        
        await Clients.All.SendAsync("UpdateStatus", userPcId, true);
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