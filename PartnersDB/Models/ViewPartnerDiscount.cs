using System;
using System.Collections.Generic;

namespace PartnersDB.Models;

public partial class ViewPartnerDiscount
{
    public short? Id { get; set; }

    public string? Name { get; set; }

    public long? TotalPurchases { get; set; }

    public int? DiscountPercent { get; set; }
}
