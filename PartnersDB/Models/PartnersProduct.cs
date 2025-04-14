using System;
using System.Collections.Generic;

namespace PartnersDB.Models;

/// <summary>
/// Журнал продаж продукции партнерам
/// </summary>
public partial class PartnersProduct
{
    public short Id { get; set; }

    public short IdPartner { get; set; }

    public short IdProduct { get; set; }

    public int Count { get; set; }

    public DateTime DateSelling { get; set; }

    public virtual Partner IdPartnerNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
