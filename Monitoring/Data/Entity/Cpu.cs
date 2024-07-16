﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Monitoring.Data.Entity;

[Table("Cpu")]
public class Cpu
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int Cores { get; set; }
    public int Threads { get; set; }
    public int Freq { get; set; }
    public float Version { get; set; }
    public string Socket { get; set; }
}