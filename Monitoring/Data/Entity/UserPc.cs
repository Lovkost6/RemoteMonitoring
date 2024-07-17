using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Monitoring.Data.Entity;

[Table("UserPc")]
public class UserPc
{
    public long? Id { get; set; }
    
    [JsonPropertyName("Cpu")]
    public Cpu Cpu { get; set; }
    
    [JsonPropertyName("MotherBoard")]
    public MotherBoard MotherBoard { get; set; }
    
    [JsonPropertyName("Gpu")]
    public Gpu Gpu { get; set; }
    
    [JsonPropertyName("Os")]
    public OperationSystem Os { get; set; }

    [JsonPropertyName("Storages")]
    public List<Storage> Storages { get; set; } = new();
    
    [JsonPropertyName("Rams")]
    public List<Ram> Rams { get; set; } = [];
}