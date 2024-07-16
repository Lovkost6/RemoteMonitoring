using Microsoft.EntityFrameworkCore;
using Monitoring.Data.Entity;

namespace Monitoring.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<Cpu> Cpus { get; set; }
    public DbSet<Gpu> Gpus { get; set; }
    public DbSet<MotherBoard> MotherBoards { get; set; }
    public DbSet<OperationSystem> OperationSystems { get; set; }
    public DbSet<Ram> Rams { get; set; }
    public DbSet<Storage> Storages { get; set; }
    public DbSet<UserPc> UserPcs { get; set; }

}