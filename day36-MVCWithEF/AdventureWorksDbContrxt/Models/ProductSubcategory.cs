using System;
using System.Collections.Generic;

namespace AdventureWorksDbContrxt.Models;

/// <summary>
/// Product subcategories. See ProductCategory table.
/// </summary>
public partial class ProductSubcategory
{
    /// <summary>
    /// Primary key for ProductSubcategory records.
    /// </summary>
    public int ProductSubcategoryID { get; set; }

    /// <summary>
    /// Product category identification number. Foreign key to ProductCategory.ProductCategoryID.
    /// </summary>
    public int ProductCategoryID { get; set; }

    /// <summary>
    /// Subcategory description.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
    /// </summary>
    public Guid rowguid { get; set; }

    /// <summary>
    /// Date and time the record was last updated.
    /// </summary>
    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Product> Product { get; set; } = new List<Product>();

    public virtual ProductCategory ProductCategory { get; set; } = null!;
}
