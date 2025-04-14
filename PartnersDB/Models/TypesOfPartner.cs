using System;
using System.Collections.Generic;

namespace PartnersDB.Models;

/// <summary>
/// Справочник типов партнеров
/// </summary>
public partial class TypesOfPartner
{
    public short Id { get; set; }

    public string TypeOfPartner { get; set; } = null!;

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
