using System;
using System.Collections.Generic;

namespace DBProject.Entities;

/// <summary>
/// Продукты
/// </summary>
public partial class Product
{
    /// <summary>
    /// Идентификатор продукта
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Название продукта
    /// </summary>
    public string ProductName { get; set; } = null!;

    /// <summary>
    /// Комментарии
    /// </summary>
    public string? Remarks { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
