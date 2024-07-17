﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Monitoring.Data.Entity;

[Table("Gpu")]
public class Gpu
{
    public long? Id { get; set; }
    public string Name { get; set; }
    public int AdapterRam { get; set; }
    public string Driver { get; set; }
}