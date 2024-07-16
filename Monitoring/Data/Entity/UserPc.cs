using System.ComponentModel.DataAnnotations.Schema;

namespace Monitoring.Data.Entity;

[Table("UserPc")]
public class UserPc
{
    public long Id { get; set; }
    
    public long CpuId { get; set; }
    public Cpu Cpu { get; set; }
    
    public long MotherBoardId { get; set; }
    public MotherBoard MotherBoard { get; set; }
    
    public long GpuId { get; set; }
    public Gpu Gpu { get; set; }
    
    public long OsId { get; set; }
    public OperationSystem Os { get; set; }

    public List<Storage> Storages { get; set; } = new();
    public List<Ram> Rams { get; set; } = [];
}