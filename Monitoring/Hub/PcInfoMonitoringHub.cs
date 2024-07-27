using System.Text.Json;
using HardWareMonitorService.Entity.Monitoring;

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
        await Clients.Caller.SendAsync("UserOnline", connections.Keys.ToList());
    }

    public async Task StartMonitoring(string userPcId)
    {
        Console.WriteLine("Мониторинг старт");
        var connectionId = connections[userPcId];
        await Clients.Client(connectionId).SendAsync("GetUserRTInfo");
    }

    public async Task StopMonitoring(string userPcId)
    {
        Console.WriteLine("Мне надо перестать мониторить " + userPcId);
        var connectionId = connections[userPcId];
        
        Console.WriteLine(connectionId);
        await Clients.Client(connectionId).SendAsync("SendingStop");
    }
    
    public async Task Monitoring(string pcMonitoringInfo)
    {
        Console.WriteLine("Мониторинг пришёл");
        var pcInfoDeserialize = JsonSerializer.Deserialize<PcMonitoringInfo>(pcMonitoringInfo);
        await Clients.All.SendAsync("ReceiveMonitoringInfo", pcInfoDeserialize);
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