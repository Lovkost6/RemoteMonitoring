using System.ComponentModel.DataAnnotations.Schema;

namespace Monitoring.Data.Entity;

[Table("Storage")]
public class Storage
{
    public long? Id { get; set; }
    public string Name { get; set; }
    
    public long UserPcId { get; set; }
    public UserPc UserPc { get; set; }
    public int TotalSize { get; set; }
}