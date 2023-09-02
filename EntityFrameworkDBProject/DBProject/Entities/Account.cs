using System;
using System.Collections.Generic;

namespace DBProject.Entities;

/// <summary>
/// Счета
/// </summary>
public partial class Account
{
    /// <summary>
    /// Идентификатор счета
    /// </summary>
    public int AccountId { get; set; }

    /// <summary>
    /// Номер счета
    /// </summary>
    public string AccountNumber { get; set; } = null!;

    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public int ClientId { get; set; }

    /// <summary>
    /// Идентификатор продукта
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Валюта счета
    /// </summary>
    public int Currency { get; set; }

    /// <summary>
    /// Дата открытия счета
    /// </summary>
    public DateOnly OpeningDate { get; set; }

    /// <summary>
    /// Дата закрытия счета
    /// </summary>
    public DateOnly? ClosingDate { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual DictCurrency CurrencyNavigation { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
