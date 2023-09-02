using System;
using System.Collections.Generic;

namespace DBProject.Entities;

/// <summary>
/// Справочник типов валют
/// </summary>
public partial class DictCurrency
{
    /// <summary>
    /// Код значения справочника
    /// </summary>
    public int IdCode { get; set; }

    /// <summary>
    /// Значение справочника сокращенное
    /// </summary>
    public string? ValueShort { get; set; }

    /// <summary>
    /// Значение справочника полное
    /// </summary>
    public string? ValueFull { get; set; }

    /// <summary>
    /// Комментарии
    /// </summary>
    public string? Remarks { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
