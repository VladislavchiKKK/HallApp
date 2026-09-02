using System;
using System.Collections.Generic;
using System.Text;

namespace HallApp.Entities.DatabaseEntities;

public class ServiceEntity : BaseEntity
{
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public IEnumerable<HallEntity>? HallEntities { get; set; }
}
