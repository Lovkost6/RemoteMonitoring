using System.ComponentModel.DataAnnotations.Schema;

namespace Monitoring.Data.Entity;


[Table("Ram")]
public class Ram
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Speed { get; set; }
    public int Capacity { get; set; }
    
    public long UserPcId { get; set; }
    public UserPc UserPc { get; set; }
}