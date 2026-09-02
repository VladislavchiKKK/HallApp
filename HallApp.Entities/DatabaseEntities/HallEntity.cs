using System;
using System.Collections.Generic;
using System.Text;

namespace HallApp.Entities.DatabaseEntities;

public class HallEntity : BaseEntity
{
    public string Name { get; set; } = null!;

    public int Capacity { get; set; }

    public decimal PricePerHour { get; set; }

    public IEnumerable<ServiceEntity>? ServiceEntities { get; set; }
}
