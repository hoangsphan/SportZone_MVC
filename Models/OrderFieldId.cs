using System;
using System.Collections.Generic;

namespace SportZone_MVC.Models;

public partial class OrderFieldId
{
    public int OrderFieldId1 { get; set; }

    public int? OrderId { get; set; }

    public int? FieldId { get; set; }

    public virtual Field? Field { get; set; }

    public virtual Order? Order { get; set; }
}
