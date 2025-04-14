using System;
using System.Collections.Generic;

namespace PartnersDB.Models;

public partial class ViewSalesHistory
{
    public short? Id { get; set; }

    public string? PartnerName { get; set; }

    public string? ProductName { get; set; }

    public int? Count { get; set; }

    public DateTime? DateSelling { get; set; }

    public decimal? TotalPrice { get; set; }
}
